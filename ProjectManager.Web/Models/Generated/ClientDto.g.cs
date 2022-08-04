using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ClientDtoGen : GeneratedDto<ProjectManager.Data.Models.Client>
    {
        public ClientDtoGen() { }

        private int? _ClientId;
        private string _Name;
        private string _OrganizationId;
        private ProjectManager.Web.Models.OrganizationDtoGen _Organization;
        private string _AgreementUrl;
        private string _PrimaryContact;
        private string _BillingContact;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectDtoGen> _Projects;

        public int? ClientId
        {
            get => _ClientId;
            set { _ClientId = value; Changed(nameof(ClientId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
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
        public string AgreementUrl
        {
            get => _AgreementUrl;
            set { _AgreementUrl = value; Changed(nameof(AgreementUrl)); }
        }
        public string PrimaryContact
        {
            get => _PrimaryContact;
            set { _PrimaryContact = value; Changed(nameof(PrimaryContact)); }
        }
        public string BillingContact
        {
            get => _BillingContact;
            set { _BillingContact = value; Changed(nameof(BillingContact)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectDtoGen> Projects
        {
            get => _Projects;
            set { _Projects = value; Changed(nameof(Projects)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Client obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ClientId = obj.ClientId;
            this.Name = obj.Name;
            this.OrganizationId = obj.OrganizationId;
            this.AgreementUrl = obj.AgreementUrl;
            this.PrimaryContact = obj.PrimaryContact;
            this.BillingContact = obj.BillingContact;
            if (tree == null || tree[nameof(this.Organization)] != null)
                this.Organization = obj.Organization.MapToDto<ProjectManager.Data.Models.Organization, OrganizationDtoGen>(context, tree?[nameof(this.Organization)]);

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
        public override void MapTo(ProjectManager.Data.Models.Client entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ClientId))) entity.ClientId = (ClientId ?? entity.ClientId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(OrganizationId))) entity.OrganizationId = OrganizationId;
            if (ShouldMapTo(nameof(AgreementUrl))) entity.AgreementUrl = AgreementUrl;
            if (ShouldMapTo(nameof(PrimaryContact))) entity.PrimaryContact = PrimaryContact;
            if (ShouldMapTo(nameof(BillingContact))) entity.BillingContact = BillingContact;
        }
    }
}
