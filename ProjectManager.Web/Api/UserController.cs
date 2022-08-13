using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Api;

// TODO: This is a test controller to make sure things are working right.
[Route("api/User")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet()]
    //[Authorize(Roles = Roles.OrgAdmin)]
    public string? Get()
    {
        return User!.Identity!.Name + Environment.NewLine +
            string.Join(Environment.NewLine, User!.Claims.Select(f => $"{f.Type}: {f.Value}"));
    }
}
