using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class TagDtoGen : GeneratedDto<ProjectManager.Data.Models.Tag>
    {
        public TagDtoGen() { }

        private int? _TagId;
        private string _Name;
        private string _Color;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectTagDtoGen> _TagProjects;

        public int? TagId
        {
            get => _TagId;
            set { _TagId = value; Changed(nameof(TagId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Color
        {
            get => _Color;
            set { _Color = value; Changed(nameof(Color)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectTagDtoGen> TagProjects
        {
            get => _TagProjects;
            set { _TagProjects = value; Changed(nameof(TagProjects)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Tag obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.TagId = obj.TagId;
            this.Name = obj.Name;
            this.Color = obj.Color;
            var propValTagProjects = obj.TagProjects;
            if (propValTagProjects != null && (tree == null || tree[nameof(this.TagProjects)] != null))
            {
                this.TagProjects = propValTagProjects
                    .OrderBy(f => f.ProjectTagId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.ProjectTag, ProjectTagDtoGen>(context, tree?[nameof(this.TagProjects)])).ToList();
            }
            else if (propValTagProjects == null && tree?[nameof(this.TagProjects)] != null)
            {
                this.TagProjects = new ProjectTagDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Tag entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(TagId))) entity.TagId = (TagId ?? entity.TagId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Color))) entity.Color = Color;
        }
    }
}
