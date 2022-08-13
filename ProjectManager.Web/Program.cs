using IntelliTect.Coalesce;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using ProjectManager.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ProjectManager.Web.Models;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Explicit declaration prevents ASP.NET Core from erroring if wwwroot doesn't exist at startup:
    WebRootPath = "wwwroot"
});

// This exists so that we can access the app in the AAD Login callback.
// TODO: Maybe there is a better way.
WebApplication app = null!;

builder.Logging
    .AddConsole()
    // Filter out Request Starting/Request Finished noise:
    .AddFilter<ConsoleLoggerProvider>("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Warning);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

// Add services to the container. AAD Auth
// TODO: Potentially support auth from any AAD domain.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    //.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))

    .AddMicrosoftIdentityWebApp(options =>
    {
        options.ClientId = "98597cea-972a-409b-98f6-e81af7b3b7d0";
        options.TenantId = "37321907-14a5-4390-987d-ec0c66c655cd";
        options.Instance = "https://login.microsoftonline.com/";
        options.Domain = "IntelliTect.com";
        options.CallbackPath = "/signin-oidc";
        options.ClientSecret = "mtH8Q~-_FysagKUBMEEg3DNRwuM94vYjnGxAndhj";
        options.Events.OnTicketReceived = (TicketReceivedContext trc) =>
        {
            // Get Email and check to make sure they are allowed to log in
            // TODO: This needs to be reworked to support multiple orgs per email (appUser)
            string? email = trc.Principal?.Identity?.Name;
            if (email == null) trc.Fail(new Exception("Invalid login"));
            else
            {
                using var scope = app.Services.CreateScope();
                var serviceScope = scope.ServiceProvider;

                // Set up a database context to handle the database check
                using var db = serviceScope.GetRequiredService<AppDbContext>();
                var appUser = db.ApplicationUsers
                    .Include(f => f.Organizations).ThenInclude(f => f.Organization)
                    .Include(f => f.Organizations).ThenInclude(f => f.ProjectRoles)
                    .First(f => f.Email.ToLower() == email.ToLower());
                if (appUser == null) trc.Fail(new Exception("User not found"));
                else
                {
                    // TODO: This is hard coded for IntelliTect
                    var orgUser = appUser.Organizations.First(f => f.Organization.Name == "IntelliTect" && f.IsActive);
                    if (orgUser == null) trc.Fail(new Exception("IntelliTect user not found"));
                    else
                    {
                        trc.Success();
                        var claims = new List<Claim>();
                        // Add the OrgAdmin Role claim.
                        if (orgUser.IsOrganizationAdmin) claims.Add(new Claim(ClaimTypes.Role, Roles.OrgAdmin));
                        // Add the OrganizationId.
                        claims.Add(new Claim("OrgId", orgUser.OrganizationId));
                        // Add CSV list of all projects they are an admin for.
                        claims.Add(new Claim("ProjectAdminIds", string.Join(",", orgUser.ProjectRoles.Select(f => f.ProjectId))));
                        trc.Principal!.AddIdentity(new ClaimsIdentity(claims));
                        Console.WriteLine($"Successfully Logged in user: {trc.Principal.Identity!.Name}");
                    }
                }
            }

            return Task.CompletedTask;
        };

    })
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
        .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
        .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();


#region Configure Services

var services = builder.Services;

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt => opt
        .EnableRetryOnFailure()
        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
    ));

services.AddCoalesce<AppDbContext>();

services
    .AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//        .AddCookie();

#endregion



#region Configure HTTP Pipeline

app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseViteDevelopmentServer(c =>
    {
        c.DevServerPort = 5002;
    });

}

app.MapCoalesceSecurityOverview("coalesce-security");

// TODO: Dummy authentication for initial development.
// Replace this with ASP.NET Core Identity, Windows Authentication, or some other scheme.
// This exists only because Coalesce restricts all generated pages and API to only logged in users by default.
//app.Use(async (context, next) =>
//{
//    Claim[] claims = new[] { new Claim(ClaimTypes.Name, "developmentuser") };

//    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//    await context.SignInAsync(context.User = new ClaimsPrincipal(identity));

//    await next.Invoke();
//});
// End Dummy Authentication.


app.UseAuthentication();
app.UseAuthorization();

var containsFileHashRegex = new Regex(@"\.[0-9a-fA-F]{8}\.[^\.]*$", RegexOptions.Compiled);
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // vite puts 8-hex-char hashes before the file extension.
        // Use this to determine if we can send a long-term cache duration.
        if (containsFileHashRegex.IsMatch(ctx.File.Name))
        {
            ctx.Context.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue { Public = true, MaxAge = TimeSpan.FromDays(30) };
        }
    }
});

// For all requests that aren't to static files, disallow caching by default.
// Individual endpoints may override this.
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new CacheControlHeaderValue { NoCache = true, NoStore = true, };

    await next();
});

app.MapRazorPages();
app.MapControllers();

// API fallback to prevent serving SPA fallback to 404 hits on API endpoints.
app.Map("/api/{**any}", () => Results.NotFound());

app.MapFallbackToController("Index", "Home");

#endregion



#region Launch

// Initialize/migrate database.
using (var scope = app.Services.CreateScope())
{
    var serviceScope = scope.ServiceProvider;

    // Run database migrations.
    using var db = serviceScope.GetRequiredService<AppDbContext>();
    db.Initialize();
    ProjectManager.Data.DatabaseSeed.Seed(db);
}

app.Run();

#endregion
