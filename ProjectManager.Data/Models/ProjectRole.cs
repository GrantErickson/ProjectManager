using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class ProjectRole
{
    public int ProjectRoleId { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public string UserId { get; set; } = null!;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    public bool IsManager { get; set; }
}
