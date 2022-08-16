using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ApplicationUserDtoGen : GeneratedDto<ProjectManager.Data.Models.ApplicationUser>
    {
        public ApplicationUserDtoGen() { }

        private string _Id;
        private string _Name;
        private string _Email;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserDtoGen> _Organizations;

        public string Id
        {
            get => _Id;
            set { _Id = value; Changed(nameof(Id)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserDtoGen> Organizations
        {
            get => _Organizations;
            set { _Organizations = value; Changed(nameof(Organizations)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.ApplicationUser obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Email = obj.Email;
            var propValOrganizations = obj.Organizations;
            if (propValOrganizations != null && (tree == null || tree[nameof(this.Organizations)] != null))
            {
                this.Organizations = propValOrganizations
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.User, UserDtoGen>(context, tree?[nameof(this.Organizations)])).ToList();
            }
            else if (propValOrganizations == null && tree?[nameof(this.Organizations)] != null)
            {
                this.Organizations = new UserDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.ApplicationUser entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Id))) entity.Id = Id;
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
        }
    }
}
