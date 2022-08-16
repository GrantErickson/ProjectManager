using IntelliTect.Coalesce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Services;

[Coalesce, Service]
public class UserService
{
    [Coalesce]
    public UserInfo GetUserInfo(ClaimsPrincipal user)
    {
        var userInfo = new UserInfo(
            user.Claims.First(f => f.Type == "name").Value,
            user.Identity!.Name!,
            user.Claims.Where(f => f.Type == ClaimTypes.Role).Select(f => f.Value));
        return userInfo;
    }

    public class UserInfo
    {
        public UserInfo(string name, string email, IEnumerable<string> roles)
        {
            Name = name;
            Email = email;
            Roles = new List<string>(roles);
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; }
    }
}
