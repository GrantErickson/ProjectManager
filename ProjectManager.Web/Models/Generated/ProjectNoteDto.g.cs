using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ProjectNoteDtoGen : GeneratedDto<ProjectManager.Data.Models.ProjectNote>
    {
        public ProjectNoteDtoGen() { }

        private int? _ProjectNoteId;
        private string _Note;
        private string _DocumentUrl;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private System.DateTimeOffset? _Date;

        public int? ProjectNoteId
        {
            get => _ProjectNoteId;
            set { _ProjectNoteId = value; Changed(nameof(ProjectNoteId)); }
        }
        public string Note
        {
            get => _Note;
            set { _Note = value; Changed(nameof(Note)); }
        }
        public string DocumentUrl
        {
            get => _DocumentUrl;
            set { _DocumentUrl = value; Changed(nameof(DocumentUrl)); }
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
        public System.DateTimeOffset? Date
        {
            get => _Date;
            set { _Date = value; Changed(nameof(Date)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.ProjectNote obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ProjectNoteId = obj.ProjectNoteId;
            this.Note = obj.Note;
            this.DocumentUrl = obj.DocumentUrl;
            this.ProjectId = obj.ProjectId;
            this.Date = obj.Date;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.ProjectNote entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ProjectNoteId))) entity.ProjectNoteId = (ProjectNoteId ?? entity.ProjectNoteId);
            if (ShouldMapTo(nameof(Note))) entity.Note = Note;
            if (ShouldMapTo(nameof(DocumentUrl))) entity.DocumentUrl = DocumentUrl;
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(Date))) entity.Date = (Date ?? entity.Date);
        }
    }
}
