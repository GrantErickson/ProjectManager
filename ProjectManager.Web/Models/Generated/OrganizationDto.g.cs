using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class OrganizationDtoGen : GeneratedDto<ProjectManager.Data.Models.Organization>
    {
        public OrganizationDtoGen() { }

        private string _OrganizationId;
        private string _Name;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserDtoGen> _Users;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.BillingPeriodDtoGen> _BillingPeriods;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ClientDtoGen> _Clients;

        public string OrganizationId
        {
            get => _OrganizationId;
            set { _OrganizationId = value; Changed(nameof(OrganizationId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.UserDtoGen> Users
        {
            get => _Users;
            set { _Users = value; Changed(nameof(Users)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.BillingPeriodDtoGen> BillingPeriods
        {
            get => _BillingPeriods;
            set { _BillingPeriods = value; Changed(nameof(BillingPeriods)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ClientDtoGen> Clients
        {
            get => _Clients;
            set { _Clients = value; Changed(nameof(Clients)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Organization obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.OrganizationId = obj.OrganizationId;
            this.Name = obj.Name;
            var propValUsers = obj.Users;
            if (propValUsers != null && (tree == null || tree[nameof(this.Users)] != null))
            {
                this.Users = propValUsers
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.User, UserDtoGen>(context, tree?[nameof(this.Users)])).ToList();
            }
            else if (propValUsers == null && tree?[nameof(this.Users)] != null)
            {
                this.Users = new UserDtoGen[0];
            }

            var propValBillingPeriods = obj.BillingPeriods;
            if (propValBillingPeriods != null && (tree == null || tree[nameof(this.BillingPeriods)] != null))
            {
                this.BillingPeriods = propValBillingPeriods
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.BillingPeriod, BillingPeriodDtoGen>(context, tree?[nameof(this.BillingPeriods)])).ToList();
            }
            else if (propValBillingPeriods == null && tree?[nameof(this.BillingPeriods)] != null)
            {
                this.BillingPeriods = new BillingPeriodDtoGen[0];
            }

            var propValClients = obj.Clients;
            if (propValClients != null && (tree == null || tree[nameof(this.Clients)] != null))
            {
                this.Clients = propValClients
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.Client, ClientDtoGen>(context, tree?[nameof(this.Clients)])).ToList();
            }
            else if (propValClients == null && tree?[nameof(this.Clients)] != null)
            {
                this.Clients = new ClientDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Organization entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(OrganizationId))) entity.OrganizationId = OrganizationId;
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
        }
    }
}
