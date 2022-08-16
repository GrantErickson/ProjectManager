using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Data.Models;

// TODO: This is insufficient security for a multi-tenant arrangement.
[Edit(Roles.OrgAdmin)]
[Create(Roles.OrgAdmin)]
[Delete(PermissionLevel = SecurityPermissionLevels.DenyAll)]
public class User : TrackingBase
{
    public enum EmploymentStatusEnum
    {
        Unknown = 0,
        FullTime = 1,
        PartTime = 2,
        Contractor = 3,
    }


    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UserId { get; set; } = null!;
    [Required]
    public string OrganizationId { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    public string? AppUserId { get; set; } = null!;
    [ForeignKey(nameof(AppUserId))]
    public ApplicationUser? AppUser { get; set; } = null!;
    [Edit(Roles = Roles.OrgAdmin)]
    [Required]
    public string Name { get; set; } = null!;
    public decimal? DefaultRate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsOrganizationAdmin { get; set; }
    [Required]
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
    public class UserWithAssignments : StandardDataSource<User, AppDbContext>
    {
        public UserWithAssignments(CrudContext<AppDbContext> context) : base(context) { }

        public override IQueryable<User> GetQuery(IDataSourceParameters parameters)
        {
            IQueryable<User> result = Db.Users
            .Include(f => f.Assignments).ThenInclude(f => f.Project.Lead)
            .Include(f => f.Assignments).ThenInclude(f => f.Project.Client)
            .Include(f => f.Assignments).ThenInclude(f => f.Project).ThenInclude(f => f.Client)
            .Include(f => f.Assignments).ThenInclude(f => f.Skills).ThenInclude(f => f.Skill)
            .Include(f => f.Skills).ThenInclude(f => f.Skill);

            return result;
        }
    }
}
