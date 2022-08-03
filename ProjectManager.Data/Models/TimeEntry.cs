using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models;

public class TimeEntry: TrackingBase
{
    public int TimeEntryId { get; set; }
    public int OrganizationUserId { get; set; }
    [ForeignKey(nameof(OrganizationUserId))]
    public OrganizationUser User { get; set; } = null!;
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public decimal Hours { get; set; }
    public bool IsBillable { get; set; }
    public string Description { get; set; } = null!;
    public DateTimeOffset? ApprovedDate { get; set; }
}
