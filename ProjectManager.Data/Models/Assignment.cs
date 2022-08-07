using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models
{
    public class Assignment : TrackingBase
    {
        public enum AssignmentStateEnum
        {
            Unknown = 0,
            Active = 1,
            Contracting = 2,
            Completed = 3,
            Potential = 4,
            Lost = 5,
            Paused = 6,            
        }

        public int AssignmentId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string? OrganizationUserId { get; set; }
        [ForeignKey(nameof(OrganizationUserId))]
        [Search]
        public OrganizationUser? User { get; set; } = null!;
        [DisplayName]
        [Search]
        public string Role { get; set; } = null!;
        [Search]
        public decimal? Rate { get; set; }
        public AssignmentStateEnum AssignmentState { get; set; }
        public string? RateRange { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PercentAllocated { get; set; }
        public string? Note { get; set; }
        public bool isLongTerm { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsBillable { get; set; } = true;

        public ICollection<AssignmentSkill> Skills { get; set; } = null!;

        [Coalesce]
        public class AssignmentBehaviors : StandardBehaviors<Assignment, AppDbContext>
        {
            public AssignmentBehaviors(CrudContext<AppDbContext> context) : base(context) { }

            public override ItemResult BeforeSave(SaveKind kind, Assignment? oldItem, Assignment item)
            {
                if (item.User != null)
                {
                    if (item.Rate == null) item.Rate = item.User.DefaultRate;
                }
                return true;
            }
        }
    }
}