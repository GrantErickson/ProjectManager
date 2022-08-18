using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class AssignmentInfoDtoGen : GeneratedDto<ProjectManager.Data.Services.ProjectService.AssignmentInfo>
    {
        public AssignmentInfoDtoGen() { }

        private string _Name;
        private decimal? _PercentAllocated;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.SkillInfoDtoGen> _Skills;
        private bool? _IsLongTerm;

        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public decimal? PercentAllocated
        {
            get => _PercentAllocated;
            set { _PercentAllocated = value; Changed(nameof(PercentAllocated)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.SkillInfoDtoGen> Skills
        {
            get => _Skills;
            set { _Skills = value; Changed(nameof(Skills)); }
        }
        public bool? IsLongTerm
        {
            get => _IsLongTerm;
            set { _IsLongTerm = value; Changed(nameof(IsLongTerm)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Services.ProjectService.AssignmentInfo obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Name = obj.Name;
            this.PercentAllocated = obj.PercentAllocated;
            this.IsLongTerm = obj.IsLongTerm;
            var propValSkills = obj.Skills;
            if (propValSkills != null)
            {
                this.Skills = propValSkills
                    .Select(f => f.MapToDto<ProjectManager.Data.Services.ProjectService.SkillInfo, SkillInfoDtoGen>(context, tree?[nameof(this.Skills)])).ToList();
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Services.ProjectService.AssignmentInfo entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

        }
    }
}
