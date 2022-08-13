using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Project : TrackingBase
{
    public enum ProjectStateEnum
    {
        Unknown = 0,
        Active = 1,
        Contracting = 2,
        Completed = 3,
        Potential = 4,
        Lost = 5,
    }

    public int ProjectId { set; get; }
    [Search(SearchMethod = SearchAttribute.SearchMethods.Contains)]
    [Required]
    public string Name { set; get; } = null!;
    [Required]
    public int ClientId { get; set; }
    [Search]
    public Client Client { get; set; } = null!;
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime? StartDate { get; set; }
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime? EndDate { get; set; }
    public string? LeadId { get; set; }
    public OrganizationUser? Lead { get; set; }
    public decimal? Amount { get; set; }
    public string? Note { get; set; }
    public string? ContractUrl { get; set; }
    public ProjectStateEnum ProjectState { get; set; } = ProjectStateEnum.Unknown;
    [Range(0D, 100D)]
    public Decimal? Probability { get; set; }
    public string? PrimaryContact { get; set; }
    public string? BillingContact { get; set; }
    public string? BillingInformation { get; set; }
    public bool IsBillableDefault { get; set; }


    public ICollection<ProjectRole> Roles { get; set; } = null!;
    public ICollection<ProjectNote> Notes { get; set; } = null!;
    public ICollection<TimeEntry> TimeEntries { get; set; } = null!;
    [Search]
    public ICollection<Assignment> Assignments { get; set; } = null!;

    [DefaultDataSource]
    public class ProjectWithAssignments : StandardDataSource<Project, AppDbContext>
    {
        public ProjectWithAssignments(CrudContext<AppDbContext> context) : base(context) { }

        // TODO: Put a note in docs that if this property matches a property name it can get set inadvertently and cause saves to fail. Need a bit more research on root cause.
        [Coalesce]
        public string? FilterLeadId { get; set; }
        [Coalesce]
        public bool HideCompleted { get; set; }

        public override IQueryable<Project> GetQuery(IDataSourceParameters parameters)
        {
            IQueryable<Project> result = Db.Projects;
            result = result
                .Include(f => f.Assignments).ThenInclude(f => f.User).ThenInclude(f => f!.AppUser)
                .Include(f => f.Assignments).ThenInclude(f => f.Skills).ThenInclude(f => f.Skill)
                .Include(f => f.Client)
                .Include(f => f.Notes)
                .Include(f => f.Lead!.AppUser);
            if (FilterLeadId != null) result = result.Where(f => f.LeadId == FilterLeadId);
            if (HideCompleted) result = result.Where(f => f.ProjectState != ProjectStateEnum.Completed && f.ProjectState != ProjectStateEnum.Lost);
            return result;
        }

    }

}
