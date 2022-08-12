<template>
  <v-container>
    <v-row>
      <v-col>
        <h2>Projects</h2>
      </v-col>
      <v-col cols="2">
        <v-switch
          v-model="dataSource.hideCompleted"
          label="Hide Complete"
        ></v-switch>
      </v-col>
      <v-col cols="3">
        <c-select
          for="OrganizationUser"
          :key-value.sync="dataSource.filterLeadId"
          :clearable="true"
          label="Lead"
        />
        <!-- TODO: <c-list-filters :list="projects" /> -->
      </v-col>
      <v-col cols="3">
        <v-text-field
          v-model="projects.$params.search"
          label="Search"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-progress-linear
      :style="{ visibility: isLoading ? 'visible' : 'hidden' }"
      indeterminate
      color="primary"
    />

    <ProjectCard
      v-for="project in projects.$items"
      :key="project.projectId"
      :project="project"
    ></ProjectCard>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";
import * as $models from "../models.g";

@Component
export default class Projects extends Vue {
  private projects = new ViewModels.ProjectListViewModel();
  private dataSource = new $models.Project.DataSources.ProjectWithAssignments();

  async created() {
    this.projects.$dataSource = this.dataSource;
    this.dataSource.hideCompleted = true;
    this.projects.$startAutoLoad(this);
    this.projects.$load();
  }

  get isLoading() {
    return this.projects.$load.isLoading;
  }
}
</script>
