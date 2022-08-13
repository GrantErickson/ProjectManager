using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models;

public class TimeEntry: TrackingBase
{
    public int TimeEntryId { get; set; }
    [Required]
    public string OrganizationUserId { get; set; } = null!;
    [ForeignKey(nameof(OrganizationUserId))]
    public OrganizationUser User { get; set; } = null!;
    [Required]
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    [Required]
    public DateTimeOffset StartDate { get; set; }
    [Required]
    public decimal Hours { get; set; }
    public bool IsBillable { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? ApprovedDate { get; set; }
}
