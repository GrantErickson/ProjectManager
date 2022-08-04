using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ProjectRoleDtoGen : GeneratedDto<ProjectManager.Data.Models.ProjectRole>
    {
        public ProjectRoleDtoGen() { }

        private int? _ProjectRoleId;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private string _OrganizationUserId;
        private ProjectManager.Web.Models.OrganizationUserDtoGen _User;
        private bool? _IsManager;

        public int? ProjectRoleId
        {
            get => _ProjectRoleId;
            set { _ProjectRoleId = value; Changed(nameof(ProjectRoleId)); }
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
        public string OrganizationUserId
        {
            get => _OrganizationUserId;
            set { _OrganizationUserId = value; Changed(nameof(OrganizationUserId)); }
        }
        public ProjectManager.Web.Models.OrganizationUserDtoGen User
        {
            get => _User;
            set { _User = value; Changed(nameof(User)); }
        }
        public bool? IsManager
        {
            get => _IsManager;
            set { _IsManager = value; Changed(nameof(IsManager)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.ProjectRole obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ProjectRoleId = obj.ProjectRoleId;
            this.ProjectId = obj.ProjectId;
            this.OrganizationUserId = obj.OrganizationUserId;
            this.IsManager = obj.IsManager;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

            if (tree == null || tree[nameof(this.User)] != null)
                this.User = obj.User.MapToDto<ProjectManager.Data.Models.OrganizationUser, OrganizationUserDtoGen>(context, tree?[nameof(this.User)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.ProjectRole entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ProjectRoleId))) entity.ProjectRoleId = (ProjectRoleId ?? entity.ProjectRoleId);
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(OrganizationUserId))) entity.OrganizationUserId = OrganizationUserId;
            if (ShouldMapTo(nameof(IsManager))) entity.IsManager = (IsManager ?? entity.IsManager);
        }
    }
}
