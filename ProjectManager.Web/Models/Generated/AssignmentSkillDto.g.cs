using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class AssignmentSkillDtoGen : GeneratedDto<ProjectManager.Data.Models.AssignmentSkill>
    {
        public AssignmentSkillDtoGen() { }

        private int? _AssignmentSkillId;
        private int? _SkillId;
        private ProjectManager.Web.Models.SkillDtoGen _Skill;
        private int? _AssignmentId;
        private ProjectManager.Web.Models.AssignmentDtoGen _Assignment;
        private int? _Level;

        public int? AssignmentSkillId
        {
            get => _AssignmentSkillId;
            set { _AssignmentSkillId = value; Changed(nameof(AssignmentSkillId)); }
        }
        public int? SkillId
        {
            get => _SkillId;
            set { _SkillId = value; Changed(nameof(SkillId)); }
        }
        public ProjectManager.Web.Models.SkillDtoGen Skill
        {
            get => _Skill;
            set { _Skill = value; Changed(nameof(Skill)); }
        }
        public int? AssignmentId
        {
            get => _AssignmentId;
            set { _AssignmentId = value; Changed(nameof(AssignmentId)); }
        }
        public ProjectManager.Web.Models.AssignmentDtoGen Assignment
        {
            get => _Assignment;
            set { _Assignment = value; Changed(nameof(Assignment)); }
        }
        public int? Level
        {
            get => _Level;
            set { _Level = value; Changed(nameof(Level)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.AssignmentSkill obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.AssignmentSkillId = obj.AssignmentSkillId;
            this.SkillId = obj.SkillId;
            this.AssignmentId = obj.AssignmentId;
            this.Level = obj.Level;
            if (tree == null || tree[nameof(this.Skill)] != null)
                this.Skill = obj.Skill.MapToDto<ProjectManager.Data.Models.Skill, SkillDtoGen>(context, tree?[nameof(this.Skill)]);

            if (tree == null || tree[nameof(this.Assignment)] != null)
                this.Assignment = obj.Assignment.MapToDto<ProjectManager.Data.Models.Assignment, AssignmentDtoGen>(context, tree?[nameof(this.Assignment)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.AssignmentSkill entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(AssignmentSkillId))) entity.AssignmentSkillId = (AssignmentSkillId ?? entity.AssignmentSkillId);
            if (ShouldMapTo(nameof(SkillId))) entity.SkillId = (SkillId ?? entity.SkillId);
            if (ShouldMapTo(nameof(AssignmentId))) entity.AssignmentId = (AssignmentId ?? entity.AssignmentId);
            if (ShouldMapTo(nameof(Level))) entity.Level = Level;
        }
    }
}
