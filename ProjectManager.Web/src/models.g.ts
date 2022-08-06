import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export enum EmploymentStatusEnum {
  FullTime = 0,
  PartTime = 1,
  Contractor = 2,
}


export enum ProjectStateEnum {
  Unknown = 0,
  Active = 1,
  Contracting = 2,
  Completed = 3,
  Potential = 4,
}


export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  id: string | null
  name: string | null
  email: string | null
  organizations: OrganizationUser[] | null
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
  organizationUserId: string | null
  user: OrganizationUser | null
  role: string | null
  rate: number | null
  rateRange: string | null
  startDate: Date | null
  endDate: Date | null
  percentAllocated: number | null
  note: string | null
  isLongTerm: boolean | null
  isFlagged: boolean | null
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


export interface Organization extends Model<typeof metadata.Organization> {
  organizationId: string | null
  name: string | null
  users: OrganizationUser[] | null
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


export interface OrganizationUser extends Model<typeof metadata.OrganizationUser> {
  organizationUserId: string | null
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
}
export class OrganizationUser {
  
  /** Mutates the input object and its descendents into a valid OrganizationUser implementation. */
  static convert(data?: Partial<OrganizationUser>): OrganizationUser {
    return convertToModel(data || {}, metadata.OrganizationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid OrganizationUser implementation. */
  static map(data?: Partial<OrganizationUser>): OrganizationUser {
    return mapToModel(data || {}, metadata.OrganizationUser) 
  }
  
  /** Instantiate a new OrganizationUser, optionally basing it on the given data. */
  constructor(data?: Partial<OrganizationUser> | {[k: string]: any}) {
      Object.assign(this, OrganizationUser.map(data || {}));
  }
}


export interface Project extends Model<typeof metadata.Project> {
  projectId: number | null
  name: string | null
  clientId: number | null
  client: Client | null
  startDate: Date | null
  endDate: Date | null
  amount: number | null
  note: string | null
  contractUrl: string | null
  projectState: ProjectStateEnum | null
  probability: number | null
  primaryContact: string | null
  billingContact: string | null
  billingInformation: string | null
  isBillableDefault: boolean | null
  roles: ProjectRole[] | null
  notes: ProjectNote[] | null
  timeEntries: TimeEntry[] | null
  assignments: Assignment[] | null
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
  organizationUserId: string | null
  user: OrganizationUser | null
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


export interface Skill extends Model<typeof metadata.Skill> {
  skillId: number | null
  name: string | null
  users: UserSkill[] | null
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


export interface TimeEntry extends Model<typeof metadata.TimeEntry> {
  timeEntryId: number | null
  organizationUserId: string | null
  user: OrganizationUser | null
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


export interface UserSkill extends Model<typeof metadata.UserSkill> {
  userSkillId: number | null
  organizationUserId: string | null
  user: OrganizationUser | null
  skillId: number | null
  skill: Skill | null
  level: number | null
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


