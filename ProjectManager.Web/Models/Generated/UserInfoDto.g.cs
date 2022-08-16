using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class UserInfoDtoGen : GeneratedDto<ProjectManager.Data.Services.UserService.UserInfo>
    {
        public UserInfoDtoGen() { }

        private string _Name;
        private string _Email;
        private System.Collections.Generic.ICollection<string> _Roles;

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
        public System.Collections.Generic.ICollection<string> Roles
        {
            get => _Roles;
            set { _Roles = value; Changed(nameof(Roles)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Services.UserService.UserInfo obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Name = obj.Name;
            this.Email = obj.Email;
            this.Roles = obj.Roles?.ToList();
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Services.UserService.UserInfo entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
        }
    }
}
