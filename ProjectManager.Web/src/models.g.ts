import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export enum AssignmentStateEnum {
  Unknown = 0,
  Active = 1,
  Contracting = 2,
  Completed = 3,
  Potential = 4,
  Lost = 5,
  Paused = 6,
}


export enum ContractStateEnum {
  Unknown = 0,
  Draft = 1,
  SentForSignature = 2,
  Active = 3,
  Cancelled = 4,
  Complete = 5,
}


export enum EmploymentStatusEnum {
  Unknown = 0,
  FullTime = 1,
  PartTime = 2,
  Contractor = 3,
}


export enum ProjectStateEnum {
  Unknown = 0,
  Active = 1,
  Contracting = 2,
  Completed = 3,
  Potential = 4,
  Lost = 5,
}


export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  id: string | null
  name: string | null
  email: string | null
  organizations: User[] | null
  isAppAdmin: boolean | null
}
export class ApplicationUser {
  
  /** Mutates the input object and its descendents into a valid ApplicationUser implementation. */
  static convert(data?: Partial<ApplicationUser>): ApplicationUser {
    return convertToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationUser implementation. */
  static map(data?: Partial<ApplicationUser>): ApplicationUser {
    return mapToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Instantiate a new ApplicationUser, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationUser> | {[k: string]: any}) {
      Object.assign(this, ApplicationUser.map(data || {}));
  }
}


export interface Assignment extends Model<typeof metadata.Assignment> {
  assignmentId: number | null
  projectId: number | null
  project: Project | null
  userId: string | null
  user: User | null
  role: string | null
  rate: number | null
  assignmentState: AssignmentStateEnum | null
  rateRange: string | null
  startDate: Date | null
  endDate: Date | null
  percentAllocated: number | null
  note: string | null
  isLongTerm: boolean | null
  isFlagged: boolean | null
  isBillable: boolean | null
  isPublic: boolean | null
  skills: AssignmentSkill[] | null
}
export class Assignment {
  
  /** Mutates the input object and its descendents into a valid Assignment implementation. */
  static convert(data?: Partial<Assignment>): Assignment {
    return convertToModel(data || {}, metadata.Assignment) 
  }
  
  /** Maps the input object and its descendents to a new, valid Assignment implementation. */
  static map(data?: Partial<Assignment>): Assignment {
    return mapToModel(data || {}, metadata.Assignment) 
  }
  
  /** Instantiate a new Assignment, optionally basing it on the given data. */
  constructor(data?: Partial<Assignment> | {[k: string]: any}) {
      Object.assign(this, Assignment.map(data || {}));
  }
}


export interface AssignmentSkill extends Model<typeof metadata.AssignmentSkill> {
  assignmentSkillId: number | null
  skillId: number | null
  skill: Skill | null
  assignmentId: number | null
  assignment: Assignment | null
  level: number | null
}
export class AssignmentSkill {
  
  /** Mutates the input object and its descendents into a valid AssignmentSkill implementation. */
  static convert(data?: Partial<AssignmentSkill>): AssignmentSkill {
    return convertToModel(data || {}, metadata.AssignmentSkill) 
  }
  
  /** Maps the input object and its descendents to a new, valid AssignmentSkill implementation. */
  static map(data?: Partial<AssignmentSkill>): AssignmentSkill {
    return mapToModel(data || {}, metadata.AssignmentSkill) 
  }
  
  /** Instantiate a new AssignmentSkill, optionally basing it on the given data. */
  constructor(data?: Partial<AssignmentSkill> | {[k: string]: any}) {
      Object.assign(this, AssignmentSkill.map(data || {}));
  }
}


export interface BillingPeriod extends Model<typeof metadata.BillingPeriod> {
  billingPeriodId: number | null
  organizationId: string | null
  organization: Organization | null
  name: string | null
  startDate: Date | null
  endDate: Date | null
}
export class BillingPeriod {
  
  /** Mutates the input object and its descendents into a valid BillingPeriod implementation. */
  static convert(data?: Partial<BillingPeriod>): BillingPeriod {
    return convertToModel(data || {}, metadata.BillingPeriod) 
  }
  
  /** Maps the input object and its descendents to a new, valid BillingPeriod implementation. */
  static map(data?: Partial<BillingPeriod>): BillingPeriod {
    return mapToModel(data || {}, metadata.BillingPeriod) 
  }
  
  /** Instantiate a new BillingPeriod, optionally basing it on the given data. */
  constructor(data?: Partial<BillingPeriod> | {[k: string]: any}) {
      Object.assign(this, BillingPeriod.map(data || {}));
  }
}


export interface Client extends Model<typeof metadata.Client> {
  clientId: number | null
  name: string | null
  organizationId: string | null
  organization: Organization | null
  agreementUrl: string | null
  primaryContact: string | null
  billingContact: string | null
  contractUrl: string | null
  projects: Project[] | null
}
export class Client {
  
  /** Mutates the input object and its descendents into a valid Client implementation. */
  static convert(data?: Partial<Client>): Client {
    return convertToModel(data || {}, metadata.Client) 
  }
  
  /** Maps the input object and its descendents to a new, valid Client implementation. */
  static map(data?: Partial<Client>): Client {
    return mapToModel(data || {}, metadata.Client) 
  }
  
  /** Instantiate a new Client, optionally basing it on the given data. */
  constructor(data?: Partial<Client> | {[k: string]: any}) {
      Object.assign(this, Client.map(data || {}));
  }
}


export interface Contract extends Model<typeof metadata.Contract> {
  contractId: number | null
  projectId: number | null
  project: Project | null
  name: string | null
  contractUrl: string | null
  amount: number | null
  state: ContractStateEnum | null
  startDate: Date | null
  endDate: Date | null
  unusedAmount: number | null
  hasMustNotExceed: boolean | null
  notes: string | null
}
export class Contract {
  
  /** Mutates the input object and its descendents into a valid Contract implementation. */
  static convert(data?: Partial<Contract>): Contract {
    return convertToModel(data || {}, metadata.Contract) 
  }
  
  /** Maps the input object and its descendents to a new, valid Contract implementation. */
  static map(data?: Partial<Contract>): Contract {
    return mapToModel(data || {}, metadata.Contract) 
  }
  
  /** Instantiate a new Contract, optionally basing it on the given data. */
  constructor(data?: Partial<Contract> | {[k: string]: any}) {
      Object.assign(this, Contract.map(data || {}));
  }
}


export interface Organization extends Model<typeof metadata.Organization> {
  organizationId: string | null
  name: string | null
  users: User[] | null
  billingPeriods: BillingPeriod[] | null
  clients: Client[] | null
}
export class Organization {
  
  /** Mutates the input object and its descendents into a valid Organization implementation. */
  static convert(data?: Partial<Organization>): Organization {
    return convertToModel(data || {}, metadata.Organization) 
  }
  
  /** Maps the input object and its descendents to a new, valid Organization implementation. */
  static map(data?: Partial<Organization>): Organization {
    return mapToModel(data || {}, metadata.Organization) 
  }
  
  /** Instantiate a new Organization, optionally basing it on the given data. */
  constructor(data?: Partial<Organization> | {[k: string]: any}) {
      Object.assign(this, Organization.map(data || {}));
  }
}


export interface Project extends Model<typeof metadata.Project> {
  projectId: number | null
  name: string | null
  clientId: number | null
  client: Client | null
  startDate: Date | null
  endDate: Date | null
  leadId: string | null
  lead: User | null
  amount: number | null
  note: string | null
  projectState: ProjectStateEnum | null
  probability: number | null
  primaryContact: string | null
  billingContact: string | null
  billingInformation: string | null
  isBillableDefault: boolean | null
  isPublic: boolean | null
  roles: ProjectRole[] | null
  notes: ProjectNote[] | null
  timeEntries: TimeEntry[] | null
  assignments: Assignment[] | null
  contracts: Contract[] | null
  projectTags: ProjectTag[] | null
}
export class Project {
  
  /** Mutates the input object and its descendents into a valid Project implementation. */
  static convert(data?: Partial<Project>): Project {
    return convertToModel(data || {}, metadata.Project) 
  }
  
  /** Maps the input object and its descendents to a new, valid Project implementation. */
  static map(data?: Partial<Project>): Project {
    return mapToModel(data || {}, metadata.Project) 
  }
  
  /** Instantiate a new Project, optionally basing it on the given data. */
  constructor(data?: Partial<Project> | {[k: string]: any}) {
      Object.assign(this, Project.map(data || {}));
  }
}
export namespace Project {
  export namespace DataSources {
    
    export class ProjectWithAssignments implements DataSource<typeof metadata.Project.dataSources.projectWithAssignments> {
      readonly $metadata = metadata.Project.dataSources.projectWithAssignments
      filterLeadId: string | null = null
      hideCompleted: boolean | null = null
    }
  }
}


export interface ProjectNote extends Model<typeof metadata.ProjectNote> {
  projectNoteId: number | null
  note: string | null
  documentUrl: string | null
  projectId: number | null
  project: Project | null
  date: Date | null
}
export class ProjectNote {
  
  /** Mutates the input object and its descendents into a valid ProjectNote implementation. */
  static convert(data?: Partial<ProjectNote>): ProjectNote {
    return convertToModel(data || {}, metadata.ProjectNote) 
  }
  
  /** Maps the input object and its descendents to a new, valid ProjectNote implementation. */
  static map(data?: Partial<ProjectNote>): ProjectNote {
    return mapToModel(data || {}, metadata.ProjectNote) 
  }
  
  /** Instantiate a new ProjectNote, optionally basing it on the given data. */
  constructor(data?: Partial<ProjectNote> | {[k: string]: any}) {
      Object.assign(this, ProjectNote.map(data || {}));
  }
}


export interface ProjectRole extends Model<typeof metadata.ProjectRole> {
  projectRoleId: number | null
  projectId: number | null
  project: Project | null
  userId: string | null
  user: User | null
  isManager: boolean | null
}
export class ProjectRole {
  
  /** Mutates the input object and its descendents into a valid ProjectRole implementation. */
  static convert(data?: Partial<ProjectRole>): ProjectRole {
    return convertToModel(data || {}, metadata.ProjectRole) 
  }
  
  /** Maps the input object and its descendents to a new, valid ProjectRole implementation. */
  static map(data?: Partial<ProjectRole>): ProjectRole {
    return mapToModel(data || {}, metadata.ProjectRole) 
  }
  
  /** Instantiate a new ProjectRole, optionally basing it on the given data. */
  constructor(data?: Partial<ProjectRole> | {[k: string]: any}) {
      Object.assign(this, ProjectRole.map(data || {}));
  }
}


export interface ProjectTag extends Model<typeof metadata.ProjectTag> {
  projectTagId: number | null
  projectId: number | null
  project: Project | null
  tagId: number | null
  tag: Tag | null
}
export class ProjectTag {
  
  /** Mutates the input object and its descendents into a valid ProjectTag implementation. */
  static convert(data?: Partial<ProjectTag>): ProjectTag {
    return convertToModel(data || {}, metadata.ProjectTag) 
  }
  
  /** Maps the input object and its descendents to a new, valid ProjectTag implementation. */
  static map(data?: Partial<ProjectTag>): ProjectTag {
    return mapToModel(data || {}, metadata.ProjectTag) 
  }
  
  /** Instantiate a new ProjectTag, optionally basing it on the given data. */
  constructor(data?: Partial<ProjectTag> | {[k: string]: any}) {
      Object.assign(this, ProjectTag.map(data || {}));
  }
}


export interface Skill extends Model<typeof metadata.Skill> {
  skillId: number | null
  name: string | null
  description: string | null
  users: UserSkill[] | null
  assignments: AssignmentSkill[] | null
}
export class Skill {
  
  /** Mutates the input object and its descendents into a valid Skill implementation. */
  static convert(data?: Partial<Skill>): Skill {
    return convertToModel(data || {}, metadata.Skill) 
  }
  
  /** Maps the input object and its descendents to a new, valid Skill implementation. */
  static map(data?: Partial<Skill>): Skill {
    return mapToModel(data || {}, metadata.Skill) 
  }
  
  /** Instantiate a new Skill, optionally basing it on the given data. */
  constructor(data?: Partial<Skill> | {[k: string]: any}) {
      Object.assign(this, Skill.map(data || {}));
  }
}


export interface Tag extends Model<typeof metadata.Tag> {
  tagId: number | null
  name: string | null
  color: string | null
  tagProjects: ProjectTag[] | null
}
export class Tag {
  
  /** Mutates the input object and its descendents into a valid Tag implementation. */
  static convert(data?: Partial<Tag>): Tag {
    return convertToModel(data || {}, metadata.Tag) 
  }
  
  /** Maps the input object and its descendents to a new, valid Tag implementation. */
  static map(data?: Partial<Tag>): Tag {
    return mapToModel(data || {}, metadata.Tag) 
  }
  
  /** Instantiate a new Tag, optionally basing it on the given data. */
  constructor(data?: Partial<Tag> | {[k: string]: any}) {
      Object.assign(this, Tag.map(data || {}));
  }
}


export interface TimeEntry extends Model<typeof metadata.TimeEntry> {
  timeEntryId: number | null
  userId: string | null
  user: User | null
  projectId: number | null
  project: Project | null
  startDate: Date | null
  hours: number | null
  isBillable: boolean | null
  description: string | null
  approvedDate: Date | null
}
export class TimeEntry {
  
  /** Mutates the input object and its descendents into a valid TimeEntry implementation. */
  static convert(data?: Partial<TimeEntry>): TimeEntry {
    return convertToModel(data || {}, metadata.TimeEntry) 
  }
  
  /** Maps the input object and its descendents to a new, valid TimeEntry implementation. */
  static map(data?: Partial<TimeEntry>): TimeEntry {
    return mapToModel(data || {}, metadata.TimeEntry) 
  }
  
  /** Instantiate a new TimeEntry, optionally basing it on the given data. */
  constructor(data?: Partial<TimeEntry> | {[k: string]: any}) {
      Object.assign(this, TimeEntry.map(data || {}));
  }
}


export interface User extends Model<typeof metadata.User> {
  userId: string | null
  organizationId: string | null
  organization: Organization | null
  appUserId: string | null
  appUser: ApplicationUser | null
  name: string | null
  defaultRate: number | null
  isActive: boolean | null
  isOrganizationAdmin: boolean | null
  employmentStatus: EmploymentStatusEnum | null
  assignments: Assignment[] | null
  projectRoles: ProjectRole[] | null
  skills: UserSkill[] | null
  projects: Project[] | null
}
export class User {
  
  /** Mutates the input object and its descendents into a valid User implementation. */
  static convert(data?: Partial<User>): User {
    return convertToModel(data || {}, metadata.User) 
  }
  
  /** Maps the input object and its descendents to a new, valid User implementation. */
  static map(data?: Partial<User>): User {
    return mapToModel(data || {}, metadata.User) 
  }
  
  /** Instantiate a new User, optionally basing it on the given data. */
  constructor(data?: Partial<User> | {[k: string]: any}) {
      Object.assign(this, User.map(data || {}));
  }
}
export namespace User {
  export namespace DataSources {
    
    export class UserWithAssignments implements DataSource<typeof metadata.User.dataSources.userWithAssignments> {
      readonly $metadata = metadata.User.dataSources.userWithAssignments
    }
  }
}


export interface UserSkill extends Model<typeof metadata.UserSkill> {
  userSkillId: number | null
  userId: string | null
  user: User | null
  skillId: number | null
  skill: Skill | null
  level: number | null
  isAreaOfInterest: boolean | null
  note: string | null
}
export class UserSkill {
  
  /** Mutates the input object and its descendents into a valid UserSkill implementation. */
  static convert(data?: Partial<UserSkill>): UserSkill {
    return convertToModel(data || {}, metadata.UserSkill) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserSkill implementation. */
  static map(data?: Partial<UserSkill>): UserSkill {
    return mapToModel(data || {}, metadata.UserSkill) 
  }
  
  /** Instantiate a new UserSkill, optionally basing it on the given data. */
  constructor(data?: Partial<UserSkill> | {[k: string]: any}) {
      Object.assign(this, UserSkill.map(data || {}));
  }
}


export interface AssignmentInfo extends Model<typeof metadata.AssignmentInfo> {
  name: string | null
  percentAllocated: number | null
  skills: SkillInfo[] | null
  isLongTerm: boolean | null
  assignmentState: AssignmentStateEnum | null
  user: string | null
}
export class AssignmentInfo {
  
  /** Mutates the input object and its descendents into a valid AssignmentInfo implementation. */
  static convert(data?: Partial<AssignmentInfo>): AssignmentInfo {
    return convertToModel(data || {}, metadata.AssignmentInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid AssignmentInfo implementation. */
  static map(data?: Partial<AssignmentInfo>): AssignmentInfo {
    return mapToModel(data || {}, metadata.AssignmentInfo) 
  }
  
  /** Instantiate a new AssignmentInfo, optionally basing it on the given data. */
  constructor(data?: Partial<AssignmentInfo> | {[k: string]: any}) {
      Object.assign(this, AssignmentInfo.map(data || {}));
  }
}


export interface ProjectInfo extends Model<typeof metadata.ProjectInfo> {
  name: string | null
  assignments: AssignmentInfo[] | null
  client: string | null
  state: ProjectStateEnum | null
  lead: string | null
}
export class ProjectInfo {
  
  /** Mutates the input object and its descendents into a valid ProjectInfo implementation. */
  static convert(data?: Partial<ProjectInfo>): ProjectInfo {
    return convertToModel(data || {}, metadata.ProjectInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid ProjectInfo implementation. */
  static map(data?: Partial<ProjectInfo>): ProjectInfo {
    return mapToModel(data || {}, metadata.ProjectInfo) 
  }
  
  /** Instantiate a new ProjectInfo, optionally basing it on the given data. */
  constructor(data?: Partial<ProjectInfo> | {[k: string]: any}) {
      Object.assign(this, ProjectInfo.map(data || {}));
  }
}


export interface SkillInfo extends Model<typeof metadata.SkillInfo> {
  name: string | null
  level: number | null
  description: string | null
}
export class SkillInfo {
  
  /** Mutates the input object and its descendents into a valid SkillInfo implementation. */
  static convert(data?: Partial<SkillInfo>): SkillInfo {
    return convertToModel(data || {}, metadata.SkillInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid SkillInfo implementation. */
  static map(data?: Partial<SkillInfo>): SkillInfo {
    return mapToModel(data || {}, metadata.SkillInfo) 
  }
  
  /** Instantiate a new SkillInfo, optionally basing it on the given data. */
  constructor(data?: Partial<SkillInfo> | {[k: string]: any}) {
      Object.assign(this, SkillInfo.map(data || {}));
  }
}


export interface UserInfo extends Model<typeof metadata.UserInfo> {
  name: string | null
  email: string | null
  roles: string[] | null
}
export class UserInfo {
  
  /** Mutates the input object and its descendents into a valid UserInfo implementation. */
  static convert(data?: Partial<UserInfo>): UserInfo {
    return convertToModel(data || {}, metadata.UserInfo) 
  }
  
  /** Maps the input object and its descendents to a new, valid UserInfo implementation. */
  static map(data?: Partial<UserInfo>): UserInfo {
    return mapToModel(data || {}, metadata.UserInfo) 
  }
  
  /** Instantiate a new UserInfo, optionally basing it on the given data. */
  constructor(data?: Partial<UserInfo> | {[k: string]: any}) {
      Object.assign(this, UserInfo.map(data || {}));
  }
}


