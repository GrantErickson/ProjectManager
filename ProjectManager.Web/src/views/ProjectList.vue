<template>
  <v-container>
    <v-row>
      <v-col>
        <h2>Project List</h2>
      </v-col>
      <v-col
        ><v-text-field v-model="search" label="Search"></v-text-field
      ></v-col>
    </v-row>
    <v-progress-linear
      :style="{
        visibility: projectService.getProjects.isLoading ? 'visible' : 'hidden',
      }"
      indeterminate
      color="primary"
    />

    <v-card v-for="project in projects" :key="project.name" class="my-2">
      <v-card-title>
        <v-row>
          <v-col cols="6">
            <b>{{ project.client }}</b
            >:
            {{ project.name }}
            <v-chip small
              ><c-display :model="project" for="state"></c-display
            ></v-chip>
          </v-col>
          <v-spacer />
          <v-col class="text-right">
            <v-chip v-if="project.lead" small>{{ project.lead }}</v-chip>
            <v-chip v-if="!project.lead" small color="yellow"
              >no lead yet</v-chip
            >
          </v-col>
        </v-row>
      </v-card-title>
      <v-simple-table
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
              <th class="text-left"></th>
            </tr>
          </thead>
          <tbody style="overflow-y: scroll">
            <tr
              v-for="assignment in project.assignments"
              :key="assignment.name"
            >
              <td>
                <span class="mx-2">
                  {{ assignment.name }}
                </span>
              </td>
              <td>
                <span v-if="assignment.user">{{ assignment.user }}</span>
                <v-chip v-if="!assignment.user" small color="yellow"
                  >needed</v-chip
                >
              </td>
              <td>{{ assignment.percentAllocated }}</td>
              <td>
                <!-- Icons -->
                <v-icon v-if="assignment.isLongTerm" small color="green"
                  >fas fa-road-circle-check</v-icon
                >
                <span>
                  <v-chip
                    v-for="skill in assignment.skills"
                    :key="skill.name"
                    small
                    class="mx-1"
                  >
                    {{ skill.name }}:
                    {{ skill.level }}
                  </v-chip>
                </span>
              </td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";
import * as $models from "../models.g";

@Component
export default class Projects extends Vue {
  private projectService = new ViewModels.ProjectServiceViewModel();
  private projects: $models.ProjectInfo[] = null!;
  private search = "";

  @Watch("search")
  onSearchChanged() {
    this.load();
  }

  async created() {
    await this.load();
  }

  async load() {
    await this.projectService.getProjects(this.search);
    if (this.projectService.getProjects != null) {
      this.projects = this.projectService.getProjects.result!;
    }
  }
}
</script>
