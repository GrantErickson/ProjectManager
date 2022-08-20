using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ContractDtoGen : GeneratedDto<ProjectManager.Data.Models.Contract>
    {
        public ContractDtoGen() { }

        private int? _ContractId;
        private int? _ProjectId;
        private ProjectManager.Web.Models.ProjectDtoGen _Project;
        private string _Name;
        private string _ContractUrl;
        private decimal? _Amount;
        private ProjectManager.Data.Models.Contract.ContractStateEnum? _State;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private decimal? _UnusedAmount;
        private bool? _HasMustNotExceed;
        private string _Notes;

        public int? ContractId
        {
            get => _ContractId;
            set { _ContractId = value; Changed(nameof(ContractId)); }
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
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public string ContractUrl
        {
            get => _ContractUrl;
            set { _ContractUrl = value; Changed(nameof(ContractUrl)); }
        }
        public decimal? Amount
        {
            get => _Amount;
            set { _Amount = value; Changed(nameof(Amount)); }
        }
        public ProjectManager.Data.Models.Contract.ContractStateEnum? State
        {
            get => _State;
            set { _State = value; Changed(nameof(State)); }
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
        public decimal? UnusedAmount
        {
            get => _UnusedAmount;
            set { _UnusedAmount = value; Changed(nameof(UnusedAmount)); }
        }
        public bool? HasMustNotExceed
        {
            get => _HasMustNotExceed;
            set { _HasMustNotExceed = value; Changed(nameof(HasMustNotExceed)); }
        }
        public string Notes
        {
            get => _Notes;
            set { _Notes = value; Changed(nameof(Notes)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Contract obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ContractId = obj.ContractId;
            this.ProjectId = obj.ProjectId;
            this.Name = obj.Name;
            this.ContractUrl = obj.ContractUrl;
            this.Amount = obj.Amount;
            this.State = obj.State;
            this.StartDate = obj.StartDate;
            this.EndDate = obj.EndDate;
            this.UnusedAmount = obj.UnusedAmount;
            this.HasMustNotExceed = obj.HasMustNotExceed;
            this.Notes = obj.Notes;
            if (tree == null || tree[nameof(this.Project)] != null)
                this.Project = obj.Project.MapToDto<ProjectManager.Data.Models.Project, ProjectDtoGen>(context, tree?[nameof(this.Project)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Contract entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ContractId))) entity.ContractId = (ContractId ?? entity.ContractId);
            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(ContractUrl))) entity.ContractUrl = ContractUrl;
            if (ShouldMapTo(nameof(Amount))) entity.Amount = Amount;
            if (ShouldMapTo(nameof(State))) entity.State = (State ?? entity.State);
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = StartDate;
            if (ShouldMapTo(nameof(EndDate))) entity.EndDate = EndDate;
            if (ShouldMapTo(nameof(UnusedAmount))) entity.UnusedAmount = UnusedAmount;
            if (ShouldMapTo(nameof(HasMustNotExceed))) entity.HasMustNotExceed = (HasMustNotExceed ?? entity.HasMustNotExceed);
            if (ShouldMapTo(nameof(Notes))) entity.Notes = Notes;
        }
    }
}
