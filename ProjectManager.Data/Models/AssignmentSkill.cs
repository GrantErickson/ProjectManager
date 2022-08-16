using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class AssignmentSkill
{
    public int AssignmentSkillId { get; set; }
    [Required]
    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    [Required]
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; } = null!;
    public int? Level { get; set; }
}
