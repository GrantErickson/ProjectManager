using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models
{
    public class Assignment: TrackingBase
    {
        public int AssignmentId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public int? OrganizationUserId { get; set; }
        [ForeignKey(nameof(OrganizationUserId))]
        public OrganizationUser? User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal? Rate { get; set; }
        public string? RateRange { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PercentAllocated { get; set; }
        public string? Note { get; set; }
        public bool isLongTerm { get; set; }
        public bool IsFlagged { get; set; }
        
        public ICollection<AssignmentSkill> Skills { get; set; } = null!;
        
    }
}