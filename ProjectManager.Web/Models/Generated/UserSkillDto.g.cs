using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class UserSkillDtoGen : GeneratedDto<ProjectManager.Data.Models.UserSkill>
    {
        public UserSkillDtoGen() { }

        private int? _UserSkillId;
        private string _UserId;
        private ProjectManager.Web.Models.UserDtoGen _User;
        private int? _SkillId;
        private ProjectManager.Web.Models.SkillDtoGen _Skill;
        private int? _Level;
        private string _Note;

        public int? UserSkillId
        {
            get => _UserSkillId;
            set { _UserSkillId = value; Changed(nameof(UserSkillId)); }
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
        public int? Level
        {
            get => _Level;
            set { _Level = value; Changed(nameof(Level)); }
        }
        public string Note
        {
            get => _Note;
            set { _Note = value; Changed(nameof(Note)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.UserSkill obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.UserSkillId = obj.UserSkillId;
            this.UserId = obj.UserId;
            this.SkillId = obj.SkillId;
            this.Level = obj.Level;
            this.Note = obj.Note;
            if (tree == null || tree[nameof(this.User)] != null)
                this.User = obj.User.MapToDto<ProjectManager.Data.Models.User, UserDtoGen>(context, tree?[nameof(this.User)]);

            if (tree == null || tree[nameof(this.Skill)] != null)
                this.Skill = obj.Skill.MapToDto<ProjectManager.Data.Models.Skill, SkillDtoGen>(context, tree?[nameof(this.Skill)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.UserSkill entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(UserSkillId))) entity.UserSkillId = (UserSkillId ?? entity.UserSkillId);
            if (ShouldMapTo(nameof(UserId))) entity.UserId = UserId;
            if (ShouldMapTo(nameof(SkillId))) entity.SkillId = (SkillId ?? entity.SkillId);
            if (ShouldMapTo(nameof(Level))) entity.Level = Level;
            if (ShouldMapTo(nameof(Note))) entity.Note = Note;
        }
    }
}
