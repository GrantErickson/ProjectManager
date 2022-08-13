using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Data.Models;

[Edit(Roles.AppAdmin)]
[Create(Roles.AppAdmin)]
[Delete(PermissionLevel = SecurityPermissionLevels.DenyAll)]
public class ApplicationUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ICollection<OrganizationUser> Organizations { get; set; } = null!;

    public bool IsAppAdmin { get; set; }

}
