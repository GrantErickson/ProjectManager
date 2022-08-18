using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ProjectInfoDtoGen : GeneratedDto<ProjectManager.Data.Services.ProjectService.ProjectInfo>
    {
        public ProjectInfoDtoGen() { }

        private string _Name;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentInfoDtoGen> _Assignments;
        private string _Client;
        private ProjectManager.Data.Models.Project.ProjectStateEnum? _State;

        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentInfoDtoGen> Assignments
        {
            get => _Assignments;
            set { _Assignments = value; Changed(nameof(Assignments)); }
        }
        public string Client
        {
            get => _Client;
            set { _Client = value; Changed(nameof(Client)); }
        }
        public ProjectManager.Data.Models.Project.ProjectStateEnum? State
        {
            get => _State;
            set { _State = value; Changed(nameof(State)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Services.ProjectService.ProjectInfo obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Name = obj.Name;
            this.Client = obj.Client;
            this.State = obj.State;
            var propValAssignments = obj.Assignments;
            if (propValAssignments != null)
            {
                this.Assignments = propValAssignments
                    .Select(f => f.MapToDto<ProjectManager.Data.Services.ProjectService.AssignmentInfo, AssignmentInfoDtoGen>(context, tree?[nameof(this.Assignments)])).ToList();
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Services.ProjectService.ProjectInfo entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
        }
    }
}
