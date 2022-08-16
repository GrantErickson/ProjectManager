using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using IntelliTect.Coalesce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [Search]
        public User? User { get; set; } = null!;
        [DisplayName]
        [Search]
        [Required]
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
        public IEnumerable<User> GetUsersWithSkills(AppDbContext db)
        {
            // TODO: Add security

            // Get all skills
            var skillIds = db.AssignmentSkills
                .Where(f => f.AssignmentId == this.AssignmentId)
                .Select(f => f.SkillId)
                .ToList();

            // Get all users with skills
            // TODO: Add where for assignments only with current dates
            var users = db.Users
                .Include(f => f.Skills).ThenInclude(f => f.Skill)
                .Include(f=>f.Assignments).ThenInclude(f=>f.Project.Client)
                .Where(ou => ou.Skills.Where(s => skillIds.Contains(s.SkillId)).Count() == skillIds.Count()).ToList();
            return users;
        }

        [Coalesce]
        public class AssignmentBehaviors : StandardBehaviors<Assignment, AppDbContext>
        {
            public AssignmentBehaviors(CrudContext<AppDbContext> context) : base(context) { }

            public override ItemResult BeforeSave(SaveKind kind, Assignment? oldItem, Assignment item)
            {

                if (item.UserId != null && oldItem?.UserId != item.UserId)
                {
                    if (item.Rate == null) item.Rate = Context.DbContext.Users.First(f => f.UserId == item.UserId).DefaultRate;
                }
                return true;
            }
        }


    }
}