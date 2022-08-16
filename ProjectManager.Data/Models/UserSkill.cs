using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class UserSkill
{
    public int UserSkillId { get; set; }
    [Required]
    public string UserId { get; set; } = null!;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    [Required]
    public int SkillId { get; set; }
    public Skill Skill { get; set; } = null!;
    public int? Level { get; set; }
    public bool IsAreaOfInterest { get; set; }
    public string? Note { get; set; }
}
