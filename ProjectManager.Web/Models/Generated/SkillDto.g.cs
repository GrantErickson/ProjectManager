using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class SkillDtoGen : GeneratedDto<ProjectManager.Data.Models.Skill>
    {
        public SkillDtoGen() { }

        private int? _SkillId;
        private string _Name;
        private string _Description;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserSkillDtoGen> _Users;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentSkillDtoGen> _Assignments;

        public int? SkillId
        {
            get => _SkillId;
            set { _SkillId = value; Changed(nameof(SkillId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserSkillDtoGen> Users
        {
            get => _Users;
            set { _Users = value; Changed(nameof(Users)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentSkillDtoGen> Assignments
        {
            get => _Assignments;
            set { _Assignments = value; Changed(nameof(Assignments)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Skill obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.SkillId = obj.SkillId;
            this.Name = obj.Name;
            this.Description = obj.Description;
            var propValUsers = obj.Users;
            if (propValUsers != null && (tree == null || tree[nameof(this.Users)] != null))
            {
                this.Users = propValUsers
                    .OrderBy(f => f.UserSkillId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.UserSkill, UserSkillDtoGen>(context, tree?[nameof(this.Users)])).ToList();
            }
            else if (propValUsers == null && tree?[nameof(this.Users)] != null)
            {
                this.Users = new UserSkillDtoGen[0];
            }

            var propValAssignments = obj.Assignments;
            if (propValAssignments != null && (tree == null || tree[nameof(this.Assignments)] != null))
            {
                this.Assignments = propValAssignments
                    .OrderBy(f => f.AssignmentSkillId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.AssignmentSkill, AssignmentSkillDtoGen>(context, tree?[nameof(this.Assignments)])).ToList();
            }
            else if (propValAssignments == null && tree?[nameof(this.Assignments)] != null)
            {
                this.Assignments = new AssignmentSkillDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Skill entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(SkillId))) entity.SkillId = (SkillId ?? entity.SkillId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
        }
    }
}
