using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class OrganizationUserDtoGen : GeneratedDto<ProjectManager.Data.Models.OrganizationUser>
    {
        public OrganizationUserDtoGen() { }

        private string _OrganizationUserId;
        private string _OrganizationId;
        private ProjectManager.Web.Models.OrganizationDtoGen _Organization;
        private string _AppUserId;
        private ProjectManager.Web.Models.ApplicationUserDtoGen _AppUser;
        private string _Name;
        private decimal? _DefaultRate;
        private bool? _IsActive;
        private bool? _IsOrganizationAdmin;
        private ProjectManager.Data.Models.OrganizationUser.EmploymentStatusEnum? _EmploymentStatus;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentDtoGen> _Assignments;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectRoleDtoGen> _ProjectRoles;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserSkillDtoGen> _Skills;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectDtoGen> _Projects;

        public string OrganizationUserId
        {
            get => _OrganizationUserId;
            set { _OrganizationUserId = value; Changed(nameof(OrganizationUserId)); }
        }
        public string OrganizationId
        {
            get => _OrganizationId;
            set { _OrganizationId = value; Changed(nameof(OrganizationId)); }
        }
        public ProjectManager.Web.Models.OrganizationDtoGen Organization
        {
            get => _Organization;
            set { _Organization = value; Changed(nameof(Organization)); }
        }
        public string AppUserId
        {
            get => _AppUserId;
            set { _AppUserId = value; Changed(nameof(AppUserId)); }
        }
        public ProjectManager.Web.Models.ApplicationUserDtoGen AppUser
        {
            get => _AppUser;
            set { _AppUser = value; Changed(nameof(AppUser)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public decimal? DefaultRate
        {
            get => _DefaultRate;
            set { _DefaultRate = value; Changed(nameof(DefaultRate)); }
        }
        public bool? IsActive
        {
            get => _IsActive;
            set { _IsActive = value; Changed(nameof(IsActive)); }
        }
        public bool? IsOrganizationAdmin
        {
            get => _IsOrganizationAdmin;
            set { _IsOrganizationAdmin = value; Changed(nameof(IsOrganizationAdmin)); }
        }
        public ProjectManager.Data.Models.OrganizationUser.EmploymentStatusEnum? EmploymentStatus
        {
            get => _EmploymentStatus;
            set { _EmploymentStatus = value; Changed(nameof(EmploymentStatus)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentDtoGen> Assignments
        {
            get => _Assignments;
            set { _Assignments = value; Changed(nameof(Assignments)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectRoleDtoGen> ProjectRoles
        {
            get => _ProjectRoles;
            set { _ProjectRoles = value; Changed(nameof(ProjectRoles)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserSkillDtoGen> Skills
        {
            get => _Skills;
            set { _Skills = value; Changed(nameof(Skills)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectDtoGen> Projects
        {
            get => _Projects;
            set { _Projects = value; Changed(nameof(Projects)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.OrganizationUser obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.OrganizationUserId = obj.OrganizationUserId;
            this.OrganizationId = obj.OrganizationId;
            this.AppUserId = obj.AppUserId;
            this.Name = obj.Name;
            this.DefaultRate = obj.DefaultRate;
            this.IsActive = obj.IsActive;
            this.IsOrganizationAdmin = obj.IsOrganizationAdmin;
            this.EmploymentStatus = obj.EmploymentStatus;
            if (tree == null || tree[nameof(this.Organization)] != null)
                this.Organization = obj.Organization.MapToDto<ProjectManager.Data.Models.Organization, OrganizationDtoGen>(context, tree?[nameof(this.Organization)]);

            if (tree == null || tree[nameof(this.AppUser)] != null)
                this.AppUser = obj.AppUser.MapToDto<ProjectManager.Data.Models.ApplicationUser, ApplicationUserDtoGen>(context, tree?[nameof(this.AppUser)]);

            var propValAssignments = obj.Assignments;
            if (propValAssignments != null && (tree == null || tree[nameof(this.Assignments)] != null))
            {
                this.Assignments = propValAssignments
                    .OrderBy(f => f.AssignmentId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.Assignment, AssignmentDtoGen>(context, tree?[nameof(this.Assignments)])).ToList();
            }
            else if (propValAssignments == null && tree?[nameof(this.Assignments)] != null)
            {
                this.Assignments = new AssignmentDtoGen[0];
            }

            var propValProjectRoles = obj.ProjectRoles;
            if (propValProjectRoles != null && (tree == null || tree[nameof(this.ProjectRoles)] != null))
            {
                this.ProjectRoles = propValProjectRoles
                    .OrderBy(f => f.ProjectRoleId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.ProjectRole, ProjectRoleDtoGen>(context, tree?[nameof(this.ProjectRoles)])).ToList();
            }
            else if (propValProjectRoles == null && tree?[nameof(this.ProjectRoles)] != null)
            {
                this.ProjectRoles = new ProjectRoleDtoGen[0];
            }

            var propValSkills = obj.Skills;
            if (propValSkills != null && (tree == null || tree[nameof(this.Skills)] != null))
            {
                this.Skills = propValSkills
                    .OrderBy(f => f.UserSkillId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.UserSkill, UserSkillDtoGen>(context, tree?[nameof(this.Skills)])).ToList();
            }
            else if (propValSkills == null && tree?[nameof(this.Skills)] != null)
            {
                this.Skills = new UserSkillDtoGen[0];
            }

            var propValProjects = obj.Projects;
            if (propValProjects != null && (tree == null || tree[nameof(this.Projects)] != null))
            {
                this.Projects = propValProjects
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Projects)])).ToList();
            }
            else if (propValProjects == null && tree?[nameof(this.Projects)] != null)
            {
                this.Projects = new ProjectDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.OrganizationUser entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(OrganizationUserId))) entity.OrganizationUserId = OrganizationUserId;
            if (ShouldMapTo(nameof(OrganizationId))) entity.OrganizationId = OrganizationId;
            if (ShouldMapTo(nameof(AppUserId))) entity.AppUserId = AppUserId;
            if (ShouldMapTo(nameof(DefaultRate))) entity.DefaultRate = (DefaultRate ?? entity.DefaultRate);
            if (ShouldMapTo(nameof(IsActive))) entity.IsActive = (IsActive ?? entity.IsActive);
            if (ShouldMapTo(nameof(IsOrganizationAdmin))) entity.IsOrganizationAdmin = (IsOrganizationAdmin ?? entity.IsOrganizationAdmin);
            if (ShouldMapTo(nameof(EmploymentStatus))) entity.EmploymentStatus = (EmploymentStatus ?? entity.EmploymentStatus);
            if ((context.IsInRoleCached("OrgAdmin")))
            {
                if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            }
        }
    }
}
