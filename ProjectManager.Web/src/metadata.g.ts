import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const EmploymentStatusEnum = domain.enums.EmploymentStatusEnum = {
  name: "EmploymentStatusEnum",
  displayName: "Employment Status Enum",
  type: "enum",
  ...getEnumMeta<"FullTime"|"PartTime"|"Contractor">([
  {
    value: 0,
    strValue: "FullTime",
    displayName: "Full Time",
  },
  {
    value: 1,
    strValue: "PartTime",
    displayName: "Part Time",
  },
  {
    value: 2,
    strValue: "Contractor",
    displayName: "Contractor",
  },
  ]),
}
export const ProjectStateEnum = domain.enums.ProjectStateEnum = {
  name: "ProjectStateEnum",
  displayName: "Project State Enum",
  type: "enum",
  ...getEnumMeta<"Unknown"|"Active"|"Contracting"|"Completed"|"Potential">([
  {
    value: 0,
    strValue: "Unknown",
    displayName: "Unknown",
  },
  {
    value: 1,
    strValue: "Active",
    displayName: "Active",
  },
  {
    value: 2,
    strValue: "Contracting",
    displayName: "Contracting",
  },
  {
    value: 3,
    strValue: "Completed",
    displayName: "Completed",
  },
  {
    value: 4,
    strValue: "Potential",
    displayName: "Potential",
  },
  ]),
}
export const ApplicationUser = domain.types.ApplicationUser = {
  name: "ApplicationUser",
  displayName: "Application User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ApplicationUser",
  get keyProp() { return this.props.id }, 
  behaviorFlags: 7,
  props: {
    id: {
      name: "id",
      displayName: "Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
    },
    organizations: {
      name: "organizations",
      displayName: "Organizations",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      },
      role: "value",
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Assignment = domain.types.Assignment = {
  name: "Assignment",
  displayName: "Assignment",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Assignment",
  get keyProp() { return this.props.assignmentId }, 
  behaviorFlags: 7,
  props: {
    assignmentId: {
      name: "assignmentId",
      displayName: "Assignment Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    projectId: {
      name: "projectId",
      displayName: "Project Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Project as ModelType) },
      get navigationProp() { return (domain.types.Assignment as ModelType).props.project as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Project is required.",
      }
    },
    project: {
      name: "project",
      displayName: "Project",
      type: "model",
      get typeDef() { return (domain.types.Project as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Assignment as ModelType).props.projectId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Project as ModelType).props.assignments as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    organizationUserId: {
      name: "organizationUserId",
      displayName: "Organization User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get principalType() { return (domain.types.OrganizationUser as ModelType) },
      get navigationProp() { return (domain.types.Assignment as ModelType).props.user as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    user: {
      name: "user",
      displayName: "User",
      type: "model",
      get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Assignment as ModelType).props.organizationUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.OrganizationUser as ModelType).props.assignments as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    rate: {
      name: "rate",
      displayName: "Rate",
      type: "number",
      role: "value",
    },
    rateRange: {
      name: "rateRange",
      displayName: "Rate Range",
      type: "string",
      role: "value",
    },
    startDate: {
      name: "startDate",
      displayName: "Start Date",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
    },
    endDate: {
      name: "endDate",
      displayName: "End Date",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
    },
    percentAllocated: {
      name: "percentAllocated",
      displayName: "Percent Allocated",
      type: "number",
      role: "value",
    },
    note: {
      name: "note",
      displayName: "Note",
      type: "string",
      role: "value",
    },
    isLongTerm: {
      name: "isLongTerm",
      displayName: "Is Long Term",
      type: "boolean",
      role: "value",
    },
    isFlagged: {
      name: "isFlagged",
      displayName: "Is Flagged",
      type: "boolean",
      role: "value",
    },
    skills: {
      name: "skills",
      displayName: "Skills",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.AssignmentSkill as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.AssignmentSkill as ModelType).props.assignmentId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.AssignmentSkill as ModelType).props.assignment as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const AssignmentSkill = domain.types.AssignmentSkill = {
  name: "AssignmentSkill",
  displayName: "Assignment Skill",
  get displayProp() { return this.props.assignmentSkillId }, 
  type: "model",
  controllerRoute: "AssignmentSkill",
  get keyProp() { return this.props.assignmentSkillId }, 
  behaviorFlags: 7,
  props: {
    assignmentSkillId: {
      name: "assignmentSkillId",
      displayName: "Assignment Skill Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    skillId: {
      name: "skillId",
      displayName: "Skill Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Skill as ModelType).props.skillId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Skill as ModelType) },
      get navigationProp() { return (domain.types.AssignmentSkill as ModelType).props.skill as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Skill is required.",
      }
    },
    skill: {
      name: "skill",
      displayName: "Skill",
      type: "model",
      get typeDef() { return (domain.types.Skill as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.AssignmentSkill as ModelType).props.skillId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Skill as ModelType).props.skillId as PrimaryKeyProperty },
      dontSerialize: true,
    },
    assignmentId: {
      name: "assignmentId",
      displayName: "Assignment Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Assignment as ModelType).props.assignmentId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Assignment as ModelType) },
      get navigationProp() { return (domain.types.AssignmentSkill as ModelType).props.assignment as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Assignment is required.",
      }
    },
    assignment: {
      name: "assignment",
      displayName: "Assignment",
      type: "model",
      get typeDef() { return (domain.types.Assignment as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.AssignmentSkill as ModelType).props.assignmentId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Assignment as ModelType).props.assignmentId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Assignment as ModelType).props.skills as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    level: {
      name: "level",
      displayName: "Level",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const BillingPeriod = domain.types.BillingPeriod = {
  name: "BillingPeriod",
  displayName: "Billing Period",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "BillingPeriod",
  get keyProp() { return this.props.billingPeriodId }, 
  behaviorFlags: 7,
  props: {
    billingPeriodId: {
      name: "billingPeriodId",
      displayName: "Billing Period Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    organizationId: {
      name: "organizationId",
      displayName: "Organization Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Organization as ModelType) },
      get navigationProp() { return (domain.types.BillingPeriod as ModelType).props.organization as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    organization: {
      name: "organization",
      displayName: "Organization",
      type: "model",
      get typeDef() { return (domain.types.Organization as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.BillingPeriod as ModelType).props.organizationId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Organization as ModelType).props.billingPeriods as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    startDate: {
      name: "startDate",
      displayName: "Start Date",
      type: "date",
      dateKind: "date",
      noOffset: true,
      role: "value",
    },
    endDate: {
      name: "endDate",
      displayName: "End Date",
      type: "date",
      dateKind: "date",
      noOffset: true,
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Client = domain.types.Client = {
  name: "Client",
  displayName: "Client",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Client",
  get keyProp() { return this.props.clientId }, 
  behaviorFlags: 7,
  props: {
    clientId: {
      name: "clientId",
      displayName: "Client Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    organizationId: {
      name: "organizationId",
      displayName: "Organization Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Organization as ModelType) },
      get navigationProp() { return (domain.types.Client as ModelType).props.organization as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    organization: {
      name: "organization",
      displayName: "Organization",
      type: "model",
      get typeDef() { return (domain.types.Organization as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Client as ModelType).props.organizationId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Organization as ModelType).props.clients as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    agreementUrl: {
      name: "agreementUrl",
      displayName: "Agreement Url",
      type: "string",
      role: "value",
    },
    primaryContact: {
      name: "primaryContact",
      displayName: "Primary Contact",
      type: "string",
      role: "value",
    },
    billingContact: {
      name: "billingContact",
      displayName: "Billing Contact",
      type: "string",
      role: "value",
    },
    projects: {
      name: "projects",
      displayName: "Projects",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Project as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Project as ModelType).props.clientId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Project as ModelType).props.client as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Organization = domain.types.Organization = {
  name: "Organization",
  displayName: "Organization",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Organization",
  get keyProp() { return this.props.organizationId }, 
  behaviorFlags: 7,
  props: {
    organizationId: {
      name: "organizationId",
      displayName: "Organization Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    users: {
      name: "users",
      displayName: "Users",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.OrganizationUser as ModelType).props.organizationId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.OrganizationUser as ModelType).props.organization as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    billingPeriods: {
      name: "billingPeriods",
      displayName: "Billing Periods",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.BillingPeriod as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.BillingPeriod as ModelType).props.organizationId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.BillingPeriod as ModelType).props.organization as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    clients: {
      name: "clients",
      displayName: "Clients",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Client as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Client as ModelType).props.organizationId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Client as ModelType).props.organization as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const OrganizationUser = domain.types.OrganizationUser = {
  name: "OrganizationUser",
  displayName: "Organization User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "OrganizationUser",
  get keyProp() { return this.props.organizationUserId }, 
  behaviorFlags: 7,
  props: {
    organizationUserId: {
      name: "organizationUserId",
      displayName: "Organization User Id",
      type: "string",
      role: "primaryKey",
      hidden: 3,
    },
    organizationId: {
      name: "organizationId",
      displayName: "Organization Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Organization as ModelType) },
      get navigationProp() { return (domain.types.OrganizationUser as ModelType).props.organization as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    organization: {
      name: "organization",
      displayName: "Organization",
      type: "model",
      get typeDef() { return (domain.types.Organization as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.OrganizationUser as ModelType).props.organizationId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Organization as ModelType).props.organizationId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Organization as ModelType).props.users as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    appUserId: {
      name: "appUserId",
      displayName: "App User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.ApplicationUser as ModelType).props.id as PrimaryKeyProperty },
      get principalType() { return (domain.types.ApplicationUser as ModelType) },
      get navigationProp() { return (domain.types.OrganizationUser as ModelType).props.appUser as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    appUser: {
      name: "appUser",
      displayName: "App User",
      type: "model",
      get typeDef() { return (domain.types.ApplicationUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.OrganizationUser as ModelType).props.appUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.ApplicationUser as ModelType).props.id as PrimaryKeyProperty },
      dontSerialize: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    defaultRate: {
      name: "defaultRate",
      displayName: "Default Rate",
      type: "number",
      role: "value",
    },
    isActive: {
      name: "isActive",
      displayName: "Is Active",
      type: "boolean",
      role: "value",
    },
    isOrganizationAdmin: {
      name: "isOrganizationAdmin",
      displayName: "Is Organization Admin",
      type: "boolean",
      role: "value",
    },
    employmentStatus: {
      name: "employmentStatus",
      displayName: "Employment Status",
      type: "enum",
      get typeDef() { return domain.enums.EmploymentStatusEnum },
      role: "value",
    },
    assignments: {
      name: "assignments",
      displayName: "Assignments",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Assignment as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Assignment as ModelType).props.organizationUserId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Assignment as ModelType).props.user as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    projectRoles: {
      name: "projectRoles",
      displayName: "Project Roles",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.ProjectRole as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.ProjectRole as ModelType).props.organizationUserId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.ProjectRole as ModelType).props.user as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    skills: {
      name: "skills",
      displayName: "Skills",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.UserSkill as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.UserSkill as ModelType).props.organizationUserId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.UserSkill as ModelType).props.user as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Project = domain.types.Project = {
  name: "Project",
  displayName: "Project",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Project",
  get keyProp() { return this.props.projectId }, 
  behaviorFlags: 7,
  props: {
    projectId: {
      name: "projectId",
      displayName: "Project Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    clientId: {
      name: "clientId",
      displayName: "Client Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Client as ModelType).props.clientId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Client as ModelType) },
      get navigationProp() { return (domain.types.Project as ModelType).props.client as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Client is required.",
      }
    },
    client: {
      name: "client",
      displayName: "Client",
      type: "model",
      get typeDef() { return (domain.types.Client as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.Project as ModelType).props.clientId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Client as ModelType).props.clientId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Client as ModelType).props.projects as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    startDate: {
      name: "startDate",
      displayName: "Start Date",
      type: "date",
      dateKind: "date",
      noOffset: true,
      role: "value",
    },
    endDate: {
      name: "endDate",
      displayName: "End Date",
      type: "date",
      dateKind: "date",
      noOffset: true,
      role: "value",
    },
    amount: {
      name: "amount",
      displayName: "Amount",
      type: "number",
      role: "value",
    },
    note: {
      name: "note",
      displayName: "Note",
      type: "string",
      role: "value",
    },
    contractUrl: {
      name: "contractUrl",
      displayName: "Contract Url",
      type: "string",
      role: "value",
    },
    projectState: {
      name: "projectState",
      displayName: "Project State",
      type: "enum",
      get typeDef() { return domain.enums.ProjectStateEnum },
      role: "value",
    },
    probablility: {
      name: "probablility",
      displayName: "Probablility",
      type: "number",
      role: "value",
      rules: {
        min: val => val == null || val >= 0 || "Probablility must be at least 0.",
        max: val => val == null || val <= 100 || "Probablility may not be more than 100.",
      }
    },
    primaryContact: {
      name: "primaryContact",
      displayName: "Primary Contact",
      type: "string",
      role: "value",
    },
    billingContact: {
      name: "billingContact",
      displayName: "Billing Contact",
      type: "string",
      role: "value",
    },
    billingInformation: {
      name: "billingInformation",
      displayName: "Billing Information",
      type: "string",
      role: "value",
    },
    isBillableDefault: {
      name: "isBillableDefault",
      displayName: "Is Billable Default",
      type: "boolean",
      role: "value",
    },
    roles: {
      name: "roles",
      displayName: "Roles",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.ProjectRole as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.ProjectRole as ModelType).props.projectId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.ProjectRole as ModelType).props.project as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    notes: {
      name: "notes",
      displayName: "Notes",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.ProjectNote as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.ProjectNote as ModelType).props.projectId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.ProjectNote as ModelType).props.project as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    timeEntries: {
      name: "timeEntries",
      displayName: "Time Entries",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.TimeEntry as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.TimeEntry as ModelType).props.projectId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.TimeEntry as ModelType).props.project as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
    assignments: {
      name: "assignments",
      displayName: "Assignments",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.Assignment as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.Assignment as ModelType).props.projectId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.Assignment as ModelType).props.project as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
    projectWithAssignments: {
      type: "dataSource",
      name: "ProjectWithAssignments",
      displayName: "Project With Assignments",
      isDefault: true,
      props: {
      },
    },
  },
}
export const ProjectNote = domain.types.ProjectNote = {
  name: "ProjectNote",
  displayName: "Project Note",
  get displayProp() { return this.props.projectNoteId }, 
  type: "model",
  controllerRoute: "ProjectNote",
  get keyProp() { return this.props.projectNoteId }, 
  behaviorFlags: 7,
  props: {
    projectNoteId: {
      name: "projectNoteId",
      displayName: "Project Note Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    note: {
      name: "note",
      displayName: "Note",
      type: "string",
      role: "value",
    },
    documentUrl: {
      name: "documentUrl",
      displayName: "Document Url",
      type: "string",
      role: "value",
    },
    projectId: {
      name: "projectId",
      displayName: "Project Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Project as ModelType) },
      get navigationProp() { return (domain.types.ProjectNote as ModelType).props.project as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Project is required.",
      }
    },
    project: {
      name: "project",
      displayName: "Project",
      type: "model",
      get typeDef() { return (domain.types.Project as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.ProjectNote as ModelType).props.projectId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Project as ModelType).props.notes as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    date: {
      name: "date",
      displayName: "Date",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const ProjectRole = domain.types.ProjectRole = {
  name: "ProjectRole",
  displayName: "Project Role",
  get displayProp() { return this.props.projectRoleId }, 
  type: "model",
  controllerRoute: "ProjectRole",
  get keyProp() { return this.props.projectRoleId }, 
  behaviorFlags: 7,
  props: {
    projectRoleId: {
      name: "projectRoleId",
      displayName: "Project Role Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    projectId: {
      name: "projectId",
      displayName: "Project Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Project as ModelType) },
      get navigationProp() { return (domain.types.ProjectRole as ModelType).props.project as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Project is required.",
      }
    },
    project: {
      name: "project",
      displayName: "Project",
      type: "model",
      get typeDef() { return (domain.types.Project as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.ProjectRole as ModelType).props.projectId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Project as ModelType).props.roles as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    organizationUserId: {
      name: "organizationUserId",
      displayName: "Organization User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get principalType() { return (domain.types.OrganizationUser as ModelType) },
      get navigationProp() { return (domain.types.ProjectRole as ModelType).props.user as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    user: {
      name: "user",
      displayName: "User",
      type: "model",
      get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.ProjectRole as ModelType).props.organizationUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.OrganizationUser as ModelType).props.projectRoles as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    isManager: {
      name: "isManager",
      displayName: "Is Manager",
      type: "boolean",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Skill = domain.types.Skill = {
  name: "Skill",
  displayName: "Skill",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Skill",
  get keyProp() { return this.props.skillId }, 
  behaviorFlags: 7,
  props: {
    skillId: {
      name: "skillId",
      displayName: "Skill Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    users: {
      name: "users",
      displayName: "Users",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.UserSkill as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.UserSkill as ModelType).props.skillId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.UserSkill as ModelType).props.skill as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const TimeEntry = domain.types.TimeEntry = {
  name: "TimeEntry",
  displayName: "Time Entry",
  get displayProp() { return this.props.timeEntryId }, 
  type: "model",
  controllerRoute: "TimeEntry",
  get keyProp() { return this.props.timeEntryId }, 
  behaviorFlags: 7,
  props: {
    timeEntryId: {
      name: "timeEntryId",
      displayName: "Time Entry Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    organizationUserId: {
      name: "organizationUserId",
      displayName: "Organization User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get principalType() { return (domain.types.OrganizationUser as ModelType) },
      get navigationProp() { return (domain.types.TimeEntry as ModelType).props.user as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    user: {
      name: "user",
      displayName: "User",
      type: "model",
      get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.TimeEntry as ModelType).props.organizationUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      dontSerialize: true,
    },
    projectId: {
      name: "projectId",
      displayName: "Project Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Project as ModelType) },
      get navigationProp() { return (domain.types.TimeEntry as ModelType).props.project as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Project is required.",
      }
    },
    project: {
      name: "project",
      displayName: "Project",
      type: "model",
      get typeDef() { return (domain.types.Project as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.TimeEntry as ModelType).props.projectId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Project as ModelType).props.projectId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Project as ModelType).props.timeEntries as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    startDate: {
      name: "startDate",
      displayName: "Start Date",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
    hours: {
      name: "hours",
      displayName: "Hours",
      type: "number",
      role: "value",
    },
    isBillable: {
      name: "isBillable",
      displayName: "Is Billable",
      type: "boolean",
      role: "value",
    },
    description: {
      name: "description",
      displayName: "Description",
      type: "string",
      role: "value",
    },
    approvedDate: {
      name: "approvedDate",
      displayName: "Approved Date",
      type: "date",
      dateKind: "datetime",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const UserSkill = domain.types.UserSkill = {
  name: "UserSkill",
  displayName: "User Skill",
  get displayProp() { return this.props.userSkillId }, 
  type: "model",
  controllerRoute: "UserSkill",
  get keyProp() { return this.props.userSkillId }, 
  behaviorFlags: 7,
  props: {
    userSkillId: {
      name: "userSkillId",
      displayName: "User Skill Id",
      type: "number",
      role: "primaryKey",
      hidden: 3,
    },
    organizationUserId: {
      name: "organizationUserId",
      displayName: "Organization User Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get principalType() { return (domain.types.OrganizationUser as ModelType) },
      get navigationProp() { return (domain.types.UserSkill as ModelType).props.user as ModelReferenceNavigationProperty },
      hidden: 3,
    },
    user: {
      name: "user",
      displayName: "User",
      type: "model",
      get typeDef() { return (domain.types.OrganizationUser as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.UserSkill as ModelType).props.organizationUserId as ForeignKeyProperty },
      get principalKey() { return (domain.types.OrganizationUser as ModelType).props.organizationUserId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.OrganizationUser as ModelType).props.skills as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    skillId: {
      name: "skillId",
      displayName: "Skill Id",
      type: "number",
      role: "foreignKey",
      get principalKey() { return (domain.types.Skill as ModelType).props.skillId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Skill as ModelType) },
      get navigationProp() { return (domain.types.UserSkill as ModelType).props.skill as ModelReferenceNavigationProperty },
      hidden: 3,
      rules: {
        required: val => val != null || "Skill is required.",
      }
    },
    skill: {
      name: "skill",
      displayName: "Skill",
      type: "model",
      get typeDef() { return (domain.types.Skill as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.UserSkill as ModelType).props.skillId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Skill as ModelType).props.skillId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Skill as ModelType).props.users as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    level: {
      name: "level",
      displayName: "Level",
      type: "number",
      role: "value",
    },
    note: {
      name: "note",
      displayName: "Note",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
    EmploymentStatusEnum: typeof EmploymentStatusEnum
    ProjectStateEnum: typeof ProjectStateEnum
  }
  types: {
    ApplicationUser: typeof ApplicationUser
    Assignment: typeof Assignment
    AssignmentSkill: typeof AssignmentSkill
    BillingPeriod: typeof BillingPeriod
    Client: typeof Client
    Organization: typeof Organization
    OrganizationUser: typeof OrganizationUser
    Project: typeof Project
    ProjectNote: typeof ProjectNote
    ProjectRole: typeof ProjectRole
    Skill: typeof Skill
    TimeEntry: typeof TimeEntry
    UserSkill: typeof UserSkill
  }
  services: {
  }
}

solidify(domain)

export default domain as unknown as AppDomain
