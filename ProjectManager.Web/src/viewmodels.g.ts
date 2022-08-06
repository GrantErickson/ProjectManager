import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  id: string | null;
  name: string | null;
  email: string | null;
  organizations: OrganizationUserViewModel[] | null;
}
export class ApplicationUserViewModel extends ViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, string> implements $models.ApplicationUser  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationUser> | null) {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient(), initialData)
  }
}
defineProps(ApplicationUserViewModel, $metadata.ApplicationUser)

export class ApplicationUserListViewModel extends ListViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, ApplicationUserViewModel> {
  
  constructor() {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient())
  }
}


export interface AssignmentViewModel extends $models.Assignment {
  assignmentId: number | null;
  projectId: number | null;
  project: ProjectViewModel | null;
  organizationUserId: string | null;
  user: OrganizationUserViewModel | null;
  role: string | null;
  rate: number | null;
  rateRange: string | null;
  startDate: Date | null;
  endDate: Date | null;
  percentAllocated: number | null;
  note: string | null;
  isLongTerm: boolean | null;
  isFlagged: boolean | null;
  skills: AssignmentSkillViewModel[] | null;
}
export class AssignmentViewModel extends ViewModel<$models.Assignment, $apiClients.AssignmentApiClient, number> implements $models.Assignment  {
  
  
  public addToSkills() {
    return this.$addChild('skills') as AssignmentSkillViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Assignment> | null) {
    super($metadata.Assignment, new $apiClients.AssignmentApiClient(), initialData)
  }
}
defineProps(AssignmentViewModel, $metadata.Assignment)

export class AssignmentListViewModel extends ListViewModel<$models.Assignment, $apiClients.AssignmentApiClient, AssignmentViewModel> {
  
  constructor() {
    super($metadata.Assignment, new $apiClients.AssignmentApiClient())
  }
}


export interface AssignmentSkillViewModel extends $models.AssignmentSkill {
  assignmentSkillId: number | null;
  skillId: number | null;
  skill: SkillViewModel | null;
  assignmentId: number | null;
  assignment: AssignmentViewModel | null;
  level: number | null;
}
export class AssignmentSkillViewModel extends ViewModel<$models.AssignmentSkill, $apiClients.AssignmentSkillApiClient, number> implements $models.AssignmentSkill  {
  
  constructor(initialData?: DeepPartial<$models.AssignmentSkill> | null) {
    super($metadata.AssignmentSkill, new $apiClients.AssignmentSkillApiClient(), initialData)
  }
}
defineProps(AssignmentSkillViewModel, $metadata.AssignmentSkill)

export class AssignmentSkillListViewModel extends ListViewModel<$models.AssignmentSkill, $apiClients.AssignmentSkillApiClient, AssignmentSkillViewModel> {
  
  constructor() {
    super($metadata.AssignmentSkill, new $apiClients.AssignmentSkillApiClient())
  }
}


export interface BillingPeriodViewModel extends $models.BillingPeriod {
  billingPeriodId: number | null;
  organizationId: string | null;
  organization: OrganizationViewModel | null;
  name: string | null;
  startDate: Date | null;
  endDate: Date | null;
}
export class BillingPeriodViewModel extends ViewModel<$models.BillingPeriod, $apiClients.BillingPeriodApiClient, number> implements $models.BillingPeriod  {
  
  constructor(initialData?: DeepPartial<$models.BillingPeriod> | null) {
    super($metadata.BillingPeriod, new $apiClients.BillingPeriodApiClient(), initialData)
  }
}
defineProps(BillingPeriodViewModel, $metadata.BillingPeriod)

export class BillingPeriodListViewModel extends ListViewModel<$models.BillingPeriod, $apiClients.BillingPeriodApiClient, BillingPeriodViewModel> {
  
  constructor() {
    super($metadata.BillingPeriod, new $apiClients.BillingPeriodApiClient())
  }
}


export interface ClientViewModel extends $models.Client {
  clientId: number | null;
  name: string | null;
  organizationId: string | null;
  organization: OrganizationViewModel | null;
  agreementUrl: string | null;
  primaryContact: string | null;
  billingContact: string | null;
  projects: ProjectViewModel[] | null;
}
export class ClientViewModel extends ViewModel<$models.Client, $apiClients.ClientApiClient, number> implements $models.Client  {
  
  
  public addToProjects() {
    return this.$addChild('projects') as ProjectViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Client> | null) {
    super($metadata.Client, new $apiClients.ClientApiClient(), initialData)
  }
}
defineProps(ClientViewModel, $metadata.Client)

export class ClientListViewModel extends ListViewModel<$models.Client, $apiClients.ClientApiClient, ClientViewModel> {
  
  constructor() {
    super($metadata.Client, new $apiClients.ClientApiClient())
  }
}


export interface OrganizationViewModel extends $models.Organization {
  organizationId: string | null;
  name: string | null;
  users: OrganizationUserViewModel[] | null;
  billingPeriods: BillingPeriodViewModel[] | null;
  clients: ClientViewModel[] | null;
}
export class OrganizationViewModel extends ViewModel<$models.Organization, $apiClients.OrganizationApiClient, string> implements $models.Organization  {
  
  
  public addToUsers() {
    return this.$addChild('users') as OrganizationUserViewModel
  }
  
  
  public addToBillingPeriods() {
    return this.$addChild('billingPeriods') as BillingPeriodViewModel
  }
  
  
  public addToClients() {
    return this.$addChild('clients') as ClientViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Organization> | null) {
    super($metadata.Organization, new $apiClients.OrganizationApiClient(), initialData)
  }
}
defineProps(OrganizationViewModel, $metadata.Organization)

export class OrganizationListViewModel extends ListViewModel<$models.Organization, $apiClients.OrganizationApiClient, OrganizationViewModel> {
  
  constructor() {
    super($metadata.Organization, new $apiClients.OrganizationApiClient())
  }
}


export interface OrganizationUserViewModel extends $models.OrganizationUser {
  organizationUserId: string | null;
  organizationId: string | null;
  organization: OrganizationViewModel | null;
  appUserId: string | null;
  appUser: ApplicationUserViewModel | null;
  name: string | null;
  defaultRate: number | null;
  isActive: boolean | null;
  isOrganizationAdmin: boolean | null;
  employmentStatus: $models.EmploymentStatusEnum | null;
  assignments: AssignmentViewModel[] | null;
  projectRoles: ProjectRoleViewModel[] | null;
  skills: UserSkillViewModel[] | null;
  projects: ProjectViewModel[] | null;
}
export class OrganizationUserViewModel extends ViewModel<$models.OrganizationUser, $apiClients.OrganizationUserApiClient, string> implements $models.OrganizationUser  {
  
  
  public addToAssignments() {
    return this.$addChild('assignments') as AssignmentViewModel
  }
  
  
  public addToProjectRoles() {
    return this.$addChild('projectRoles') as ProjectRoleViewModel
  }
  
  
  public addToSkills() {
    return this.$addChild('skills') as UserSkillViewModel
  }
  
  
  public addToProjects() {
    return this.$addChild('projects') as ProjectViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.OrganizationUser> | null) {
    super($metadata.OrganizationUser, new $apiClients.OrganizationUserApiClient(), initialData)
  }
}
defineProps(OrganizationUserViewModel, $metadata.OrganizationUser)

export class OrganizationUserListViewModel extends ListViewModel<$models.OrganizationUser, $apiClients.OrganizationUserApiClient, OrganizationUserViewModel> {
  
  constructor() {
    super($metadata.OrganizationUser, new $apiClients.OrganizationUserApiClient())
  }
}


export interface ProjectViewModel extends $models.Project {
  projectId: number | null;
  name: string | null;
  clientId: number | null;
  client: ClientViewModel | null;
  startDate: Date | null;
  endDate: Date | null;
  leadId: string | null;
  lead: OrganizationUserViewModel | null;
  amount: number | null;
  note: string | null;
  contractUrl: string | null;
  projectState: $models.ProjectStateEnum | null;
  probability: number | null;
  primaryContact: string | null;
  billingContact: string | null;
  billingInformation: string | null;
  isBillableDefault: boolean | null;
  roles: ProjectRoleViewModel[] | null;
  notes: ProjectNoteViewModel[] | null;
  timeEntries: TimeEntryViewModel[] | null;
  assignments: AssignmentViewModel[] | null;
}
export class ProjectViewModel extends ViewModel<$models.Project, $apiClients.ProjectApiClient, number> implements $models.Project  {
  
  
  public addToRoles() {
    return this.$addChild('roles') as ProjectRoleViewModel
  }
  
  
  public addToNotes() {
    return this.$addChild('notes') as ProjectNoteViewModel
  }
  
  
  public addToTimeEntries() {
    return this.$addChild('timeEntries') as TimeEntryViewModel
  }
  
  
  public addToAssignments() {
    return this.$addChild('assignments') as AssignmentViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Project> | null) {
    super($metadata.Project, new $apiClients.ProjectApiClient(), initialData)
  }
}
defineProps(ProjectViewModel, $metadata.Project)

export class ProjectListViewModel extends ListViewModel<$models.Project, $apiClients.ProjectApiClient, ProjectViewModel> {
  
  constructor() {
    super($metadata.Project, new $apiClients.ProjectApiClient())
  }
}


export interface ProjectNoteViewModel extends $models.ProjectNote {
  projectNoteId: number | null;
  note: string | null;
  documentUrl: string | null;
  projectId: number | null;
  project: ProjectViewModel | null;
  date: Date | null;
}
export class ProjectNoteViewModel extends ViewModel<$models.ProjectNote, $apiClients.ProjectNoteApiClient, number> implements $models.ProjectNote  {
  
  constructor(initialData?: DeepPartial<$models.ProjectNote> | null) {
    super($metadata.ProjectNote, new $apiClients.ProjectNoteApiClient(), initialData)
  }
}
defineProps(ProjectNoteViewModel, $metadata.ProjectNote)

export class ProjectNoteListViewModel extends ListViewModel<$models.ProjectNote, $apiClients.ProjectNoteApiClient, ProjectNoteViewModel> {
  
  constructor() {
    super($metadata.ProjectNote, new $apiClients.ProjectNoteApiClient())
  }
}


export interface ProjectRoleViewModel extends $models.ProjectRole {
  projectRoleId: number | null;
  projectId: number | null;
  project: ProjectViewModel | null;
  organizationUserId: string | null;
  user: OrganizationUserViewModel | null;
  isManager: boolean | null;
}
export class ProjectRoleViewModel extends ViewModel<$models.ProjectRole, $apiClients.ProjectRoleApiClient, number> implements $models.ProjectRole  {
  
  constructor(initialData?: DeepPartial<$models.ProjectRole> | null) {
    super($metadata.ProjectRole, new $apiClients.ProjectRoleApiClient(), initialData)
  }
}
defineProps(ProjectRoleViewModel, $metadata.ProjectRole)

export class ProjectRoleListViewModel extends ListViewModel<$models.ProjectRole, $apiClients.ProjectRoleApiClient, ProjectRoleViewModel> {
  
  constructor() {
    super($metadata.ProjectRole, new $apiClients.ProjectRoleApiClient())
  }
}


export interface SkillViewModel extends $models.Skill {
  skillId: number | null;
  name: string | null;
  users: UserSkillViewModel[] | null;
}
export class SkillViewModel extends ViewModel<$models.Skill, $apiClients.SkillApiClient, number> implements $models.Skill  {
  
  
  public addToUsers() {
    return this.$addChild('users') as UserSkillViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Skill> | null) {
    super($metadata.Skill, new $apiClients.SkillApiClient(), initialData)
  }
}
defineProps(SkillViewModel, $metadata.Skill)

export class SkillListViewModel extends ListViewModel<$models.Skill, $apiClients.SkillApiClient, SkillViewModel> {
  
  constructor() {
    super($metadata.Skill, new $apiClients.SkillApiClient())
  }
}


export interface TimeEntryViewModel extends $models.TimeEntry {
  timeEntryId: number | null;
  organizationUserId: string | null;
  user: OrganizationUserViewModel | null;
  projectId: number | null;
  project: ProjectViewModel | null;
  startDate: Date | null;
  hours: number | null;
  isBillable: boolean | null;
  description: string | null;
  approvedDate: Date | null;
}
export class TimeEntryViewModel extends ViewModel<$models.TimeEntry, $apiClients.TimeEntryApiClient, number> implements $models.TimeEntry  {
  
  constructor(initialData?: DeepPartial<$models.TimeEntry> | null) {
    super($metadata.TimeEntry, new $apiClients.TimeEntryApiClient(), initialData)
  }
}
defineProps(TimeEntryViewModel, $metadata.TimeEntry)

export class TimeEntryListViewModel extends ListViewModel<$models.TimeEntry, $apiClients.TimeEntryApiClient, TimeEntryViewModel> {
  
  constructor() {
    super($metadata.TimeEntry, new $apiClients.TimeEntryApiClient())
  }
}


export interface UserSkillViewModel extends $models.UserSkill {
  userSkillId: number | null;
  organizationUserId: string | null;
  user: OrganizationUserViewModel | null;
  skillId: number | null;
  skill: SkillViewModel | null;
  level: number | null;
  note: string | null;
}
export class UserSkillViewModel extends ViewModel<$models.UserSkill, $apiClients.UserSkillApiClient, number> implements $models.UserSkill  {
  
  constructor(initialData?: DeepPartial<$models.UserSkill> | null) {
    super($metadata.UserSkill, new $apiClients.UserSkillApiClient(), initialData)
  }
}
defineProps(UserSkillViewModel, $metadata.UserSkill)

export class UserSkillListViewModel extends ListViewModel<$models.UserSkill, $apiClients.UserSkillApiClient, UserSkillViewModel> {
  
  constructor() {
    super($metadata.UserSkill, new $apiClients.UserSkillApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationUser: ApplicationUserViewModel,
  Assignment: AssignmentViewModel,
  AssignmentSkill: AssignmentSkillViewModel,
  BillingPeriod: BillingPeriodViewModel,
  Client: ClientViewModel,
  Organization: OrganizationViewModel,
  OrganizationUser: OrganizationUserViewModel,
  Project: ProjectViewModel,
  ProjectNote: ProjectNoteViewModel,
  ProjectRole: ProjectRoleViewModel,
  Skill: SkillViewModel,
  TimeEntry: TimeEntryViewModel,
  UserSkill: UserSkillViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
  Assignment: AssignmentListViewModel,
  AssignmentSkill: AssignmentSkillListViewModel,
  BillingPeriod: BillingPeriodListViewModel,
  Client: ClientListViewModel,
  Organization: OrganizationListViewModel,
  OrganizationUser: OrganizationUserListViewModel,
  Project: ProjectListViewModel,
  ProjectNote: ProjectNoteListViewModel,
  ProjectRole: ProjectRoleListViewModel,
  Skill: SkillListViewModel,
  TimeEntry: TimeEntryListViewModel,
  UserSkill: UserSkillListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

