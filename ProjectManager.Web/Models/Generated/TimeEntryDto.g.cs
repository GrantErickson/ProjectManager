using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class TimeEntryDtoGen : GeneratedDto<ProjectManager.Data.Models.TimeEntry>
    {
        public TimeEntryDtoGen() { }

        private int? _TimeEntryId;
        private int? _OrganizationUserId;
        private ProjectManager.Web.Models.OrganizationUserDtoGen _User;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private System.DateTimeOffset? _StartDate;
        private decimal? _Hours;
        private bool? _IsBillable;
        private string _Description;
        private System.DateTimeOffset? _ApprovedDate;

        public int? TimeEntryId
        {
            get => _TimeEntryId;
            set { _TimeEntryId = value; Changed(nameof(TimeEntryId)); }
        }
        public int? OrganizationUserId
        {
            get => _OrganizationUserId;
            set { _OrganizationUserId = value; Changed(nameof(OrganizationUserId)); }
        }
        public ProjectManager.Web.Models.OrganizationUserDtoGen User
        {
            get => _User;
            set { _User = value; Changed(nameof(User)); }
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
        public System.DateTimeOffset? StartDate
        {
            get => _StartDate;
            set { _StartDate = value; Changed(nameof(StartDate)); }
        }
        public decimal? Hours
        {
            get => _Hours;
            set { _Hours = value; Changed(nameof(Hours)); }
        }
        public bool? IsBillable
        {
            get => _IsBillable;
            set { _IsBillable = value; Changed(nameof(IsBillable)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public System.DateTimeOffset? ApprovedDate
        {
            get => _ApprovedDate;
            set { _ApprovedDate = value; Changed(nameof(ApprovedDate)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.TimeEntry obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.TimeEntryId = obj.TimeEntryId;
            this.OrganizationUserId = obj.OrganizationUserId;
            this.ProjectId = obj.ProjectId;
            this.StartDate = obj.StartDate;
            this.Hours = obj.Hours;
            this.IsBillable = obj.IsBillable;
            this.Description = obj.Description;
            this.ApprovedDate = obj.ApprovedDate;
            if (tree == null || tree[nameof(this.User)] != null)
                this.User = obj.User.MapToDto<ProjectManager.Data.Models.OrganizationUser, OrganizationUserDtoGen>(context, tree?[nameof(this.User)]);

            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.TimeEntry entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(TimeEntryId))) entity.TimeEntryId = (TimeEntryId ?? entity.TimeEntryId);
            if (ShouldMapTo(nameof(OrganizationUserId))) entity.OrganizationUserId = (OrganizationUserId ?? entity.OrganizationUserId);
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = (StartDate ?? entity.StartDate);
            if (ShouldMapTo(nameof(Hours))) entity.Hours = (Hours ?? entity.Hours);
            if (ShouldMapTo(nameof(IsBillable))) entity.IsBillable = (IsBillable ?? entity.IsBillable);
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
            if (ShouldMapTo(nameof(ApprovedDate))) entity.ApprovedDate = ApprovedDate;
        }
    }
}
