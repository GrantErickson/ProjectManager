using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class OrganizationUser : TrackingBase
{
    public enum EmploymentStatusEnum
    {
        FullTime,
        PartTime,
        Contractor,
    }


    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string OrganizationUserId { get; set; } = null!;
    public string OrganizationId { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    public string AppUserId { get; set; } = null!;
    [ForeignKey(nameof(AppUserId))]
    public ApplicationUser AppUser { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal DefaultRate { get; set; }
    public bool IsActive { get; set; }
    public bool IsOrganizationAdmin { get;set; }
    public EmploymentStatusEnum EmploymentStatus { get; set; }

    [InverseProperty(nameof(Assignment.User))]
    public ICollection<Assignment> Assignments { get; set; } = null!;
    [InverseProperty(nameof(ProjectRole.User))] 
    public ICollection<ProjectRole> ProjectRoles { get; set; } = null!;
    [InverseProperty(nameof(UserSkill.User))] 
    public ICollection<UserSkill> Skills { get; set; } = null!;

}
