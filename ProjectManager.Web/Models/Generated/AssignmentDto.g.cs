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
        private int? _OrganizationUserId;
        private ProjectManager.Web.Models.OrganizationUserDtoGen _User;
        private string _Name;
        private decimal? _Rate;
        private string _RateRange;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private decimal? _PercentAllocated;
        private string _Note;
        private bool? _isLongTerm;
        private bool? _IsFlagged;
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
        public int? OrganizationUserId
        {
            get => _OrganizationUserId;
            set { _OrganizationUserId = value; Changed(nameof(OrganizationUserId)); }
        }
        public ProjectManager.Web.Models.OrganizationUserDtoGen User
        {
            get => _User;
            set { _User = value; Changed(nameof(User)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public decimal? Rate
        {
            get => _Rate;
            set { _Rate = value; Changed(nameof(Rate)); }
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
            this.OrganizationUserId = obj.OrganizationUserId;
            this.Name = obj.Name;
            this.Rate = obj.Rate;
            this.RateRange = obj.RateRange;
            this.StartDate = obj.StartDate;
            this.EndDate = obj.EndDate;
            this.PercentAllocated = obj.PercentAllocated;
            this.Note = obj.Note;
            this.isLongTerm = obj.isLongTerm;
            this.IsFlagged = obj.IsFlagged;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

            if (tree == null || tree[nameof(this.User)] != null)
                this.User = obj.User.MapToDto<ProjectManager.Data.Models.OrganizationUser, OrganizationUserDtoGen>(context, tree?[nameof(this.User)]);

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
            if (ShouldMapTo(nameof(OrganizationUserId))) entity.OrganizationUserId = OrganizationUserId;
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Rate))) entity.Rate = Rate;
            if (ShouldMapTo(nameof(RateRange))) entity.RateRange = RateRange;
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = StartDate;
            if (ShouldMapTo(nameof(EndDate))) entity.EndDate = EndDate;
            if (ShouldMapTo(nameof(PercentAllocated))) entity.PercentAllocated = PercentAllocated;
            if (ShouldMapTo(nameof(Note))) entity.Note = Note;
            if (ShouldMapTo(nameof(isLongTerm))) entity.isLongTerm = (isLongTerm ?? entity.isLongTerm);
            if (ShouldMapTo(nameof(IsFlagged))) entity.IsFlagged = (IsFlagged ?? entity.IsFlagged);
        }
    }
}
