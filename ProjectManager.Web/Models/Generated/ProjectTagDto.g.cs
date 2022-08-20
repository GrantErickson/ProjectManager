using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ProjectTagDtoGen : GeneratedDto<ProjectManager.Data.Models.ProjectTag>
    {
        public ProjectTagDtoGen() { }

        private int? _ProjectTagId;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private int? _TagId;
        private ProjectManager.Web.Models.TagDtoGen _Tag;

        public int? ProjectTagId
        {
            get => _ProjectTagId;
            set { _ProjectTagId = value; Changed(nameof(ProjectTagId)); }
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
        public int? TagId
        {
            get => _TagId;
            set { _TagId = value; Changed(nameof(TagId)); }
        }
        public ProjectManager.Web.Models.TagDtoGen Tag
        {
            get => _Tag;
            set { _Tag = value; Changed(nameof(Tag)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.ProjectTag obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ProjectTagId = obj.ProjectTagId;
            this.ProjectId = obj.ProjectId;
            this.TagId = obj.TagId;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

            if (tree == null || tree[nameof(this.Tag)] != null)
                this.Tag = obj.Tag.MapToDto<ProjectManager.Data.Models.Tag, TagDtoGen>(context, tree?[nameof(this.Tag)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.ProjectTag entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ProjectTagId))) entity.ProjectTagId = (ProjectTagId ?? entity.ProjectTagId);
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(TagId))) entity.TagId = (TagId ?? entity.TagId);
        }
    }
}
