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
    }

    public int ProjectId { set; get; }
    public string Name { set; get; } = null!;
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime? StartDate { get; set; }
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime? EndDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Note { get; set; }
    public string? ContractUrl { get; set; }
    public ProjectStateEnum ProjectState { get; set; } = ProjectStateEnum.Unknown;
    [Range(0D, 100D)]
    public Decimal? Probablility { get; set; }
    public string? PrimaryContact { get; set; }
    public string? BillingContact { get; set; }
    public string? BillingInformation { get; set; }
    public bool IsBillableDefault { get; set; }


    public ICollection<ProjectRole> Roles { get; set; } = null!;
    public ICollection<ProjectNote> Notes { get; set; } = null!;
    public ICollection<TimeEntry> TimeEntries { get; set; } = null!;
    public ICollection<Assignment> Assignments { get; set; } = null!;

    [DefaultDataSource]
    public class ProjectWithAssignments : StandardDataSource<Project, AppDbContext>
    {
        public ProjectWithAssignments(CrudContext<AppDbContext> context) : base(context) { }

        public override IQueryable<Project> GetQuery(IDataSourceParameters parameters)
            => Db.Projects
            .Include(f => f.Assignments).ThenInclude(f => f.User).ThenInclude(f => f!.AppUser)
            .Include(f => f.Client);

    }

}
