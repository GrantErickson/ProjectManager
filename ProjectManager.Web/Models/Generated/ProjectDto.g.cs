using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.Web.Models
{
    public partial class ProjectDtoGen : GeneratedDto<ProjectManager.Data.Models.Project>
    {
        public ProjectDtoGen() { }

        private int? _ProjectId;
        private string _Name;
        private int? _ClientId;
        private ProjectManager.Web.Models.ClientDtoGen _Client;
        private System.DateTime? _StartDate;
        private System.DateTime? _EndDate;
        private string _LeadId;
        private ProjectManager.Web.Models.UserDtoGen _Lead;
        private decimal? _Amount;
        private string _Note;
        private ProjectManager.Data.Models.Project.ProjectStateEnum? _ProjectState;
        private decimal? _Probability;
        private string _PrimaryContact;
        private string _BillingContact;
        private string _BillingInformation;
        private bool? _IsBillableDefault;
        private bool? _IsPublic;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectRoleDtoGen> _Roles;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectNoteDtoGen> _Notes;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.TimeEntryDtoGen> _TimeEntries;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentDtoGen> _Assignments;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ContractDtoGen> _Contracts;
        private System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectTagDtoGen> _ProjectTags;

        public int? ProjectId
        {
            get => _ProjectId;
            set { _ProjectId = value; Changed(nameof(ProjectId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public int? ClientId
        {
            get => _ClientId;
            set { _ClientId = value; Changed(nameof(ClientId)); }
        }
        public ProjectManager.Web.Models.ClientDtoGen Client
        {
            get => _Client;
            set { _Client = value; Changed(nameof(Client)); }
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
        public string LeadId
        {
            get => _LeadId;
            set { _LeadId = value; Changed(nameof(LeadId)); }
        }
        public ProjectManager.Web.Models.UserDtoGen Lead
        {
            get => _Lead;
            set { _Lead = value; Changed(nameof(Lead)); }
        }
        public decimal? Amount
        {
            get => _Amount;
            set { _Amount = value; Changed(nameof(Amount)); }
        }
        public string Note
        {
            get => _Note;
            set { _Note = value; Changed(nameof(Note)); }
        }
        public ProjectManager.Data.Models.Project.ProjectStateEnum? ProjectState
        {
            get => _ProjectState;
            set { _ProjectState = value; Changed(nameof(ProjectState)); }
        }
        public decimal? Probability
        {
            get => _Probability;
            set { _Probability = value; Changed(nameof(Probability)); }
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
        public string BillingInformation
        {
            get => _BillingInformation;
            set { _BillingInformation = value; Changed(nameof(BillingInformation)); }
        }
        public bool? IsBillableDefault
        {
            get => _IsBillableDefault;
            set { _IsBillableDefault = value; Changed(nameof(IsBillableDefault)); }
        }
        public bool? IsPublic
        {
            get => _IsPublic;
            set { _IsPublic = value; Changed(nameof(IsPublic)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectRoleDtoGen> Roles
        {
            get => _Roles;
            set { _Roles = value; Changed(nameof(Roles)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectNoteDtoGen> Notes
        {
            get => _Notes;
            set { _Notes = value; Changed(nameof(Notes)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.TimeEntryDtoGen> TimeEntries
        {
            get => _TimeEntries;
            set { _TimeEntries = value; Changed(nameof(TimeEntries)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.AssignmentDtoGen> Assignments
        {
            get => _Assignments;
            set { _Assignments = value; Changed(nameof(Assignments)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ContractDtoGen> Contracts
        {
            get => _Contracts;
            set { _Contracts = value; Changed(nameof(Contracts)); }
        }
        public System.Collections.Generic.ICollection<ProjectManager.Web.Models.ProjectTagDtoGen> ProjectTags
        {
            get => _ProjectTags;
            set { _ProjectTags = value; Changed(nameof(ProjectTags)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(ProjectManager.Data.Models.Project obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ProjectId = obj.ProjectId;
            this.Name = obj.Name;
            this.ClientId = obj.ClientId;
            this.StartDate = obj.StartDate;
            this.EndDate = obj.EndDate;
            this.LeadId = obj.LeadId;
            this.Amount = obj.Amount;
            this.Note = obj.Note;
            this.ProjectState = obj.ProjectState;
            this.Probability = obj.Probability;
            this.PrimaryContact = obj.PrimaryContact;
            this.BillingContact = obj.BillingContact;
            this.BillingInformation = obj.BillingInformation;
            this.IsBillableDefault = obj.IsBillableDefault;
            this.IsPublic = obj.IsPublic;
            if (tree == null || tree[nameof(this.Client)] != null)
                this.Client = obj.Client.MapToDto<ProjectManager.Data.Models.Client, ClientDtoGen>(context, tree?[nameof(this.Client)]);

            if (tree == null || tree[nameof(this.Lead)] != null)
                this.Lead = obj.Lead.MapToDto<ProjectManager.Data.Models.User, UserDtoGen>(context, tree?[nameof(this.Lead)]);

            var propValRoles = obj.Roles;
            if (propValRoles != null && (tree == null || tree[nameof(this.Roles)] != null))
            {
                this.Roles = propValRoles
                    .OrderBy(f => f.ProjectRoleId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.ProjectRole, ProjectRoleDtoGen>(context, tree?[nameof(this.Roles)])).ToList();
            }
            else if (propValRoles == null && tree?[nameof(this.Roles)] != null)
            {
                this.Roles = new ProjectRoleDtoGen[0];
            }

            var propValNotes = obj.Notes;
            if (propValNotes != null && (tree == null || tree[nameof(this.Notes)] != null))
            {
                this.Notes = propValNotes
                    .OrderBy(f => f.ProjectNoteId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.ProjectNote, ProjectNoteDtoGen>(context, tree?[nameof(this.Notes)])).ToList();
            }
            else if (propValNotes == null && tree?[nameof(this.Notes)] != null)
            {
                this.Notes = new ProjectNoteDtoGen[0];
            }

            var propValTimeEntries = obj.TimeEntries;
            if (propValTimeEntries != null && (tree == null || tree[nameof(this.TimeEntries)] != null))
            {
                this.TimeEntries = propValTimeEntries
                    .OrderBy(f => f.TimeEntryId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.TimeEntry, TimeEntryDtoGen>(context, tree?[nameof(this.TimeEntries)])).ToList();
            }
            else if (propValTimeEntries == null && tree?[nameof(this.TimeEntries)] != null)
            {
                this.TimeEntries = new TimeEntryDtoGen[0];
            }

            var propValAssignments = obj.Assignments;
            if (propValAssignments != null && (tree == null || tree[nameof(this.Assignments)] != null))
            {
                this.Assignments = propValAssignments
                    .OrderBy(f => f.AssignmentId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.Assignment, AssignmentDtoGen>(context, tree?[nameof(this.Assignments)])).ToList();
            }
            else if (propValAssignments == null && tree?[nameof(this.Assignments)] != null)
            {
                this.Assignments = new AssignmentDtoGen[0];
            }

            var propValContracts = obj.Contracts;
            if (propValContracts != null && (tree == null || tree[nameof(this.Contracts)] != null))
            {
                this.Contracts = propValContracts
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.Contract, ContractDtoGen>(context, tree?[nameof(this.Contracts)])).ToList();
            }
            else if (propValContracts == null && tree?[nameof(this.Contracts)] != null)
            {
                this.Contracts = new ContractDtoGen[0];
            }

            var propValProjectTags = obj.ProjectTags;
            if (propValProjectTags != null && (tree == null || tree[nameof(this.ProjectTags)] != null))
            {
                this.ProjectTags = propValProjectTags
                    .OrderBy(f => f.ProjectTagId)
                    .Select(f => f.MapToDto<ProjectManager.Data.Models.ProjectTag, ProjectTagDtoGen>(context, tree?[nameof(this.ProjectTags)])).ToList();
            }
            else if (propValProjectTags == null && tree?[nameof(this.ProjectTags)] != null)
            {
                this.ProjectTags = new ProjectTagDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(ProjectManager.Data.Models.Project entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ProjectId))) entity.ProjectId = (ProjectId ?? entity.ProjectId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(ClientId))) entity.ClientId = (ClientId ?? entity.ClientId);
            if (ShouldMapTo(nameof(StartDate))) entity.StartDate = StartDate;
            if (ShouldMapTo(nameof(EndDate))) entity.EndDate = EndDate;
            if (ShouldMapTo(nameof(LeadId))) entity.LeadId = LeadId;
            if (ShouldMapTo(nameof(Amount))) entity.Amount = Amount;
            if (ShouldMapTo(nameof(Note))) entity.Note = Note;
            if (ShouldMapTo(nameof(ProjectState))) entity.ProjectState = (ProjectState ?? entity.ProjectState);
            if (ShouldMapTo(nameof(Probability))) entity.Probability = Probability;
            if (ShouldMapTo(nameof(PrimaryContact))) entity.PrimaryContact = PrimaryContact;
            if (ShouldMapTo(nameof(BillingContact))) entity.BillingContact = BillingContact;
            if (ShouldMapTo(nameof(BillingInformation))) entity.BillingInformation = BillingInformation;
            if (ShouldMapTo(nameof(IsBillableDefault))) entity.IsBillableDefault = (IsBillableDefault ?? entity.IsBillableDefault);
            if (ShouldMapTo(nameof(IsPublic))) entity.IsPublic = (IsPublic ?? entity.IsPublic);
        }
    }
}
