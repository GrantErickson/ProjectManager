using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class AssignmentDtoGen : GeneratedDto<ProjectManager.Data.Models.Assignment>
    {
        public AssignmentDtoGen() { }

        private int? _AssignmentId;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private string _UserId;
        private ProjectManager.Web.Models.UserDtoGen _User;
        private string _Role;
        private decimal? _Rate;
        private ProjectManager.Data.Models.Assignment.AssignmentStateEnum? _AssignmentState;
        private string _RateRange;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private decimal? _PercentAllocated;
        private string _Note;
        private bool? _isLongTerm;
        private bool? _IsFlagged;
        private bool? _IsBillable;
        private bool? _IsPublic;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentSkillDtoGen> _Skills;

        public int? AssignmentId
        {
            get => _AssignmentId;
            set { _AssignmentId = value; Changed(nameof(AssignmentId)); }
        }
        public int? ProjectId
        {
            get => _ProjectId;
            set { _ProjectId = value; Changed(nameof(ProjectId)); }
        }
        public ProjectManager.Web.Models.ProjectDtoGen Project
        {
            get => _Project;
            set { _Project = value; Changed(nameof(Project)); }
        }
        public string UserId
        {
            get => _UserId;
            set { _UserId = value; Changed(nameof(UserId)); }
        }
        public ProjectManager.Web.Models.UserDtoGen User
        {
            get => _User;
            set { _User = value; Changed(nameof(User)); }
        }
        public string Role
        {
            get => _Role;
            set { _Role = value; Changed(nameof(Role)); }
        }
        public decimal? Rate
        {
            get => _Rate;
            set { _Rate = value; Changed(nameof(Rate)); }
        }
        public ProjectManager.Data.Models.Assignment.AssignmentStateEnum? AssignmentState
        {
            get => _AssignmentState;
            set { _AssignmentState = value; Changed(nameof(AssignmentState)); }
        }
        public string RateRange
        {
            get => _RateRange;
            set { _RateRange = value; Changed(nameof(RateRange)); }
        }
        public System.DateTime? StartDate
        {
            get => _StartDate;
            set { _StartDate = value; Changed(nameof(StartDate)); }
        }
        public System.DateTime? EndDate
        {
            get => _EndDate;
            set { _EndDate = value; Changed(nameof(EndDate)); }
        }
        public decimal? PercentAllocated
        {
            get => _PercentAllocated;
            set { _PercentAllocated = value; Changed(nameof(PercentAllocated)); }
        }
        public string Note
        {
            get => _Note;
            set { _Note = value; Changed(nameof(Note)); }
        }
        public bool? isLongTerm
        {
            get => _isLongTerm;
            set { _isLongTerm = value; Changed(nameof(isLongTerm)); }
        }
        public bool? IsFlagged
        {
            get => _IsFlagged;
            set { _IsFlagged = value; Changed(nameof(IsFlagged)); }
        }
        public bool? IsBillable
        {
            get => _IsBillable;
            set { _IsBillable = value; Changed(nameof(IsBillable)); }
        }
        public bool? IsPublic
        {
            get => _IsPublic;
            set { _IsPublic = value; Changed(nameof(IsPublic)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentSkillDtoGen> Skills
        {
            get => _Skills;
            set { _Skills = value; Changed(nameof(Skills)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Assignment obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.AssignmentId = obj.AssignmentId;
            this.ProjectId = obj.ProjectId;
            this.UserId = obj.UserId;
            this.Role = obj.Role;
            this.Rate = obj.Rate;
            this.AssignmentState = obj.AssignmentState;
            this.RateRange = obj.RateRange;
            this.StartDate = obj.StartDate;
            this.EndDate = obj.EndDate;
            this.PercentAllocated = obj.PercentAllocated;
            this.Note = obj.Note;
            this.isLongTerm = obj.isLongTerm;
            this.IsFlagged = obj.IsFlagged;
            this.IsBillable = obj.IsBillable;
            this.IsPublic = obj.IsPublic;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

            if (tree == null || tree[nameof(this.User)] != null)
                this.User = obj.User.MapToDto<ProjectManager.Data.Models.User, UserDtoGen>(context, tree?[nameof(this.User)]);

            var propValSkills = obj.Skills;
            if (propValSkills != null && (tree == null || tree[nameof(this.Skills)] != null))
            {
                this.Skills = propValSkills
                    .OrderBy(f => f.AssignmentSkillId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.AssignmentSkill, AssignmentSkillDtoGen>(context, tree?[nameof(this.Skills)])).ToList();
            }
            else if (propValSkills == null && tree?[nameof(this.Skills)] != null)
            {
                this.Skills = new AssignmentSkillDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Assignment entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(AssignmentId))) entity.AssignmentId = (AssignmentId ?? entity.AssignmentId);
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(UserId))) entity.UserId = UserId;
            if (ShouldMapTo(nameof(Role))) entity.Role = Role;
            if (ShouldMapTo(nameof(Rate))) entity.Rate = Rate;
            if (ShouldMapTo(nameof(AssignmentState))) entity.AssignmentState = (AssignmentState ?? entity.AssignmentState);
            if (ShouldMapTo(nameof(RateRange))) entity.RateRange = RateRange;
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = StartDate;
            if (ShouldMapTo(nameof(EndDate))) entity.EndDate = EndDate;
            if (ShouldMapTo(nameof(PercentAllocated))) entity.PercentAllocated = PercentAllocated;
            if (ShouldMapTo(nameof(Note))) entity.Note = Note;
            if (ShouldMapTo(nameof(isLongTerm))) entity.isLongTerm = (isLongTerm ?? entity.isLongTerm);
            if (ShouldMapTo(nameof(IsFlagged))) entity.IsFlagged = (IsFlagged ?? entity.IsFlagged);
            if (ShouldMapTo(nameof(IsBillable))) entity.IsBillable = (IsBillable ?? entity.IsBillable);
            if (ShouldMapTo(nameof(IsPublic))) entity.IsPublic = (IsPublic ?? entity.IsPublic);
        }
    }
}
