using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;
using IntelliTect.Coalesce;

namespace ProjectManager.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<OrganizationUser> OrganizationUsers => Set<OrganizationUser>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectRole> ProjectRoles => Set<ProjectRole>();
    public DbSet<ProjectNote> ProjectNotes => Set<ProjectNote>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSkill> AssignmentSkills => Set<AssignmentSkill>();
    public DbSet<BillingPeriod> BillingPeriods => Set<BillingPeriod>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            if (property.GetColumnType() == null)
                property.SetColumnType("decimal(13,4)");
        }
    }

    /// <summary>
    /// Migrates the database and sets up items that need to be set up from scratch.
    /// </summary>
    public void Initialize()
    {
        try
        {
            this.Database.Migrate();

            // TODO: Or, use Database.EnsureCreated() instead:
            // this.Database.EnsureCreated();
        }
        catch (InvalidOperationException e) when (e.Message == "No service for type 'Microsoft.EntityFrameworkCore.Migrations.IMigrator' has been registered.")
        {
            // this exception is expected when using an InMemory database
        }
    }
}
