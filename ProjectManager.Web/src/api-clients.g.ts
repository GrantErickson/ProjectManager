import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class AssignmentApiClient extends ModelApiClient<$models.Assignment> {
  constructor() { super($metadata.Assignment) }
}


export class AssignmentSkillApiClient extends ModelApiClient<$models.AssignmentSkill> {
  constructor() { super($metadata.AssignmentSkill) }
}


export class BillingPeriodApiClient extends ModelApiClient<$models.BillingPeriod> {
  constructor() { super($metadata.BillingPeriod) }
}


export class ClientApiClient extends ModelApiClient<$models.Client> {
  constructor() { super($metadata.Client) }
}


export class OrganizationApiClient extends ModelApiClient<$models.Organization> {
  constructor() { super($metadata.Organization) }
}


export class ProjectApiClient extends ModelApiClient<$models.Project> {
  constructor() { super($metadata.Project) }
}


export class ProjectNoteApiClient extends ModelApiClient<$models.ProjectNote> {
  constructor() { super($metadata.ProjectNote) }
}


export class ProjectRoleApiClient extends ModelApiClient<$models.ProjectRole> {
  constructor() { super($metadata.ProjectRole) }
}


export class SkillApiClient extends ModelApiClient<$models.Skill> {
  constructor() { super($metadata.Skill) }
}


export class TimeEntryApiClient extends ModelApiClient<$models.TimeEntry> {
  constructor() { super($metadata.TimeEntry) }
}


export class UserApiClient extends ModelApiClient<$models.User> {
  constructor() { super($metadata.User) }
}


export class UserSkillApiClient extends ModelApiClient<$models.UserSkill> {
  constructor() { super($metadata.UserSkill) }
}


