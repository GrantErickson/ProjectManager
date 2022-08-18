<template>
  <v-card class="my-2">
    <v-card-title>
      <v-row>
        <v-col cols="6">
          <b>{{ project.client.name }}</b
          >:
          {{ project.name }}
          <v-chip small>{{ state }}</v-chip>
          <v-icon v-if="project.isPublic" small color="blue" class="mx-2"
            >fas fa-globe</v-icon
          >
          <v-icon small class="mx-4" @click="showEditor">fas fa-pencil</v-icon>
        </v-col>
        <v-col>
          <v-chip v-if="project.lead" small>{{ project.lead?.name }}</v-chip>
          <v-chip v-if="!project.lead" small color="yellow">no lead</v-chip>
        </v-col>

        <v-btn
          x-small
          fab
          class="mx-4 my-2"
          elevation="0"
          @click="expanded = !expanded"
        >
          <v-icon v-if="!expanded">fas fa-chevron-up</v-icon>
          <v-icon v-if="expanded">fas fa-chevron-down</v-icon>
        </v-btn>
      </v-row>
    </v-card-title>
    <v-card-subtitle v-if="project.note">
      {{ project.note }}
    </v-card-subtitle>
    <v-expand-transition>
      <v-simple-table
        v-if="expanded"
        dense
        fixed-header
        class="d-flex flex-column no-scrollbars"
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
              <th class="text-left">Note</th>
              <th class="text-left"></th>
              <th class="text-right">
                <v-icon @click="addAssignment(project)"
                  >fas fa-plus-circle</v-icon
                >
              </th>
            </tr>
          </thead>
          <tbody style="overflow-y: scroll">
            <AssignmentRow
              v-for="assignment in project.assignments"
              :key="assignment.assignmentId"
              ref="assignmentEdits"
              :assignment="assignment"
            ></AssignmentRow>
          </tbody>
        </template>
      </v-simple-table>
    </v-expand-transition>

    <v-dialog v-if="showEdit" v-model="showEdit" max-width="800px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Project</span> </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <EditProject :project="project" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="showEdit = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";
import * as $models from "../models.g";
import AssignmentRow from "./AssignmentRow.vue";

@Component
export default class ProjectCard extends Vue {
  @Prop() private project!: ViewModels.ProjectViewModel;
  private editAssignment: ViewModels.AssignmentViewModel | null = null;
  private showEdit = false;
  private expanded = true;

  public get state(): string {
    return $models.ProjectStateEnum[this.project.projectState!];
  }

  public showEditor() {
    this.project.$startAutoSave(this);
    this.showEdit = true;
  }

  async addAssignment(project: ViewModels.ProjectViewModel) {
    this.editAssignment = project.addToAssignments();
    this.editAssignment.project = project;
    this.editAssignment.role = "New Role";
    await this.editAssignment.$save();
    let edits = this.$refs.assignmentEdits as AssignmentRow[];
    edits
      .filter(
        (a) => a.assignment.assignmentId == this.editAssignment!.assignmentId
      )[0]
      .showEditor();
  }
}
</script>

<style>
.no-scrollbars .v-data-table__wrapper {
  overflow-y: hidden;
}
</style>
