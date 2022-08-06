using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Skill
{
    public int SkillId { get; set; }
    [Search(SearchMethod = SearchAttribute.SearchMethods.Contains)]
    public string Name { get; set; } = null!;
    public ICollection<UserSkill> Users { get; set; } = null!;
    public ICollection<AssignmentSkill> Assignments { get; set; } = null!;
}
