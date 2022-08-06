<template>
  <v-container>
    <h2>Projects</h2>
    <v-card
      v-for="project in projects.$items"
      :key="project.projectId"
      class="my-2"
    >
      <v-card-title>
        <v-row>
          <v-col cols="6">
            <b>{{ project.client.name }}</b
            >:
            {{ project.name }}
            <v-chip small>{{ project.state() }}</v-chip>
            <v-icon small class="mx-4" @click="showEditProject(project)"
              >fas fa-pencil</v-icon
            >
          </v-col>
          <v-col>
            <v-chip v-if="project.lead" small>{{ project.lead?.name }}</v-chip>
            <v-chip v-if="!project.lead" small color="yellow">no lead</v-chip>
          </v-col>

          <v-spacer />

          <v-btn x-small fab class="mx-4">
            <!-- TODO: Figure out how to add a property to the project to track this -->
            <v-icon v-if="!project.expanded">fas fa-chevron-up</v-icon>
            <v-icon v-if="project.expanded">fas fa-chevron-down</v-icon>
          </v-btn>
        </v-row>
      </v-card-title>
      <v-simple-table
        dense
        fixed-header
        class="d-flex flex-column"
        style="overflow-y: hidden"
      >
        <template #default>
          <thead>
            <tr>
              <th class="text-left">Role</th>
              <th class="text-left">Name</th>
              <th class="text-left">Allocation</th>
              <th class="text-left">Rate</th>
              <th class="text-left">Days Left</th>
              <th class="text-left"></th>
              <th class="text-right">
                <v-icon @click="addAssignment(project)"
                  >fas fa-plus-circle</v-icon
                >
              </th>
            </tr>
          </thead>
          <tbody style="overflow-y: scroll">
            <tr
              v-for="assignment in project.assignments"
              :key="assignment.assignmentId"
            >
              <td>
                {{ assignment.role }}
              </td>
              <td>
                <span>{{ assignment.user?.name }}</span>
                <v-chip v-if="!assignment.user" small color="yellow"
                  >needed</v-chip
                >
              </td>
              <td>{{ assignment.percentAllocated }}</td>
              <td>${{ assignment.rate }}</td>
              <td>{{ daysLeft(assignment) }}</td>
              <td>
                <v-icon v-if="assignment.isLongTerm" small color="green"
                  >fas fa-road-circle-check</v-icon
                >
                <v-icon
                  v-if="assignment.isFlagged"
                  small
                  color="red"
                  class="mx-2"
                  >fas fa-flag</v-icon
                >
                <v-tooltip top>
                  <template #activator="{ on }">
                    <v-icon
                      v-if="assignment.skills.length"
                      x-small
                      class="mx-2"
                      v-on="on"
                      >fas fa-list</v-icon
                    >
                  </template>
                  <span>
                    <v-chip
                      v-for="skill in assignment.skills.filter((f) => f.skill)"
                      :key="skill.assignmentSkillId"
                      small
                      class="mx-1"
                    >
                      {{ skill.skill.name }}:
                      {{ skill.level }}
                    </v-chip>
                  </span>
                </v-tooltip>
              </td>

              <td class="text-right">
                <v-icon
                  small
                  color=""
                  class="mx-2"
                  @click="showEditAssignment(assignment)"
                  >fas fa-pencil</v-icon
                >
                <v-icon small color="error" @click="promptDelete(assignment)"
                  >fas fa-trash</v-icon
                >
              </td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>
    </v-card>

    <v-dialog
      v-if="editAssignment"
      v-model="editAssignmentShown"
      max-width="800px"
    >
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Assignment</span> </v-col>
              <v-spacer></v-spacer>
              <v-col cols="3">
                <c-input :model="editAssignment" for="isFlagged"></c-input>
              </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <EditAssignment :assignment="editAssignment" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="editAssignment = null">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog v-if="editProject" v-model="editProjectShown" max-width="800px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Project</span> </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <EditProject :project="editProject" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="editProject = null">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import EditAssignment from "@/components/EditAssignment.vue";
import * as ViewModels from "@/viewmodels.g";
import * as $models from "@/models.g";

// TODO: Figure out how to add a prototype correctly.
// @ts-ignore
ViewModels.ProjectViewModel.prototype.state = function () {
  return $models.ProjectStateEnum[this.projectState!];
};

@Component
export default class Projects extends Vue {
  private projects = new ViewModels.ProjectListViewModel();
  private editAssignment: ViewModels.AssignmentViewModel | null = null;
  private editProject: ViewModels.ProjectViewModel | null = null;

  async created() {
    await this.projects.$load();
  }

  addAssignment(project: ViewModels.ProjectViewModel) {
    this.editAssignment = project.addToAssignments();
    this.editAssignment.project = project;
  }

  promptDelete(assignment: ViewModels.AssignmentViewModel) {
    if (confirm("Do you want to delete this item?")) {
      assignment.$delete();
    }
  }
  showEditAssignment(assignment: ViewModels.AssignmentViewModel) {
    this.editAssignment = assignment;
    this.editAssignment.$startAutoSave(this);
  }
  public get editAssignmentShown() {
    return this.editAssignment != null;
  }
  public set editAssignmentShown(value: boolean) {
    this.editAssignment = null;
  }

  showEditProject(project: ViewModels.ProjectViewModel) {
    this.editProject = project;
    this.editProject.$startAutoSave(this);
  }
  public get editProjectShown() {
    return this.editProject != null;
  }
  public set editProjectShown(value: boolean) {
    this.editProject = null;
  }

  daysLeft(assignment: ViewModels.AssignmentViewModel) {
    if (assignment.isLongTerm) {
      return "N/A";
    }
    if (assignment.endDate == null) {
      return "Unknown";
    }
    var daysLeft =
      (assignment.endDate.getTime() - new Date().getTime()) /
      1000 /
      60 /
      60 /
      24;
    return daysLeft.toFixed(0);
  }
}
</script>
