using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class ProjectRole
{
    public int ProjectRoleId { get; set; }
    [Required]
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    [Required]
    public string OrganizationUserId { get; set; } = null!;
    [ForeignKey(nameof(OrganizationUserId))]
    public OrganizationUser User { get; set; } = null!;
    public bool IsManager { get; set; }
}
