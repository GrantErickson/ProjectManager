using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class BillingPeriodDtoGen : GeneratedDto<ProjectManager.Data.Models.BillingPeriod>
    {
        public BillingPeriodDtoGen() { }

        private int? _BillingPeriodId;
        private string _OrganizationId;
        private ProjectManager.Web.Models.OrganizationDtoGen _Organization;
        private string _Name;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;

        public int? BillingPeriodId
        {
            get => _BillingPeriodId;
            set { _BillingPeriodId = value; Changed(nameof(BillingPeriodId)); }
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
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.DateTime? StartDate
        {
            get => _StartDate;
            set { _StartDate = value; Changed(nameof(StartDate)); }
        }
        public System.DateTime? EndDate
        {
            get => _EndDate;
            set { _EndDate = value; Changed(nameof(EndDate)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.BillingPeriod obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.BillingPeriodId = obj.BillingPeriodId;
            this.OrganizationId = obj.OrganizationId;
            this.Name = obj.Name;
            this.StartDate = obj.StartDate;
            this.EndDate = obj.EndDate;
            if (tree == null || tree[nameof(this.Organization)] != null)
                this.Organization = obj.Organization.MapToDto<ProjectManager.Data.Models.Organization, OrganizationDtoGen>(context, tree?[nameof(this.Organization)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.BillingPeriod entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(BillingPeriodId))) entity.BillingPeriodId = (BillingPeriodId ?? entity.BillingPeriodId);
            if (ShouldMapTo(nameof(OrganizationId))) entity.OrganizationId = OrganizationId;
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = (StartDate ?? entity.StartDate);
            if (ShouldMapTo(nameof(EndDate))) entity.EndDate = (EndDate ?? entity.EndDate);
        }
    }
}
