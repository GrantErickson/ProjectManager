using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class AssignmentSkill
{
    public int AssignmentSkillId { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; } = null!;
    public int? Level { get; set; }
}
