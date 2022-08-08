using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using Microsoft.EntityFrameworkCore;
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
    public string? AppUserId { get; set; } = null!;
    [ForeignKey(nameof(AppUserId))]
    public ApplicationUser? AppUser { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal DefaultRate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsOrganizationAdmin { get; set; }
    public EmploymentStatusEnum EmploymentStatus { get; set; }

    [InverseProperty(nameof(Assignment.User))]
    public ICollection<Assignment> Assignments { get; set; } = null!;
    [InverseProperty(nameof(ProjectRole.User))]
    public ICollection<ProjectRole> ProjectRoles { get; set; } = null!;
    [InverseProperty(nameof(UserSkill.User))]
    public ICollection<UserSkill> Skills { get; set; } = null!;
    [InverseProperty(nameof(Project.Lead))]
    public ICollection<Project> Projects { get; set; } = null!;



    [DefaultDataSource]
    public class OrganizationUserWithAssignments : StandardDataSource<OrganizationUser, AppDbContext>
    {
        public OrganizationUserWithAssignments(CrudContext<AppDbContext> context) : base(context) { }

        public override IQueryable<OrganizationUser> GetQuery(IDataSourceParameters parameters)
        {
            IQueryable<OrganizationUser> result = Db.OrganizationUsers
            .Include(f => f.Assignments).ThenInclude(f => f.Project.Lead)
            .Include(f => f.Assignments).ThenInclude(f => f.Project.Client)
            .Include(f => f.Assignments).ThenInclude(f => f.Project).ThenInclude(f => f.Client)
            .Include(f => f.Assignments).ThenInclude(f => f.Skills).ThenInclude(f => f.Skill)
            .Include(f => f.Skills).ThenInclude(f => f.Skill);

            return result;
        }
    }
}
