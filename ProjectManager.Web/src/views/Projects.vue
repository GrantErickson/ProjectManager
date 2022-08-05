<template>
  <div class="projects">
    <v-container>
      <h2>
        Projects
        <v-btn @click="addProject">add</v-btn>
      </h2>
      <v-card v-for="project in projects.$items" class="">
        <v-card-title>
          <v-row>
            <v-col>
              <b>{{project.client.name}}</b>:
              {{ project.name }}
            </v-col>
            <v-spacer></v-spacer>
            <v-col cols="2">
              <c-input :model="project" for="probablility"></c-input>
            </v-col>
          </v-row>
        </v-card-title>
        <v-card-text class="my-4" >
          <v-row v-for="assignment in project.assignments">
            <c-input :model="assignment" for="name" cols="3"></c-input>
            <c-input :model="assignment" for="user" cols="3"></c-input>
            <c-input :model="assignment" for="percentAllocated" cols="3"></c-input>
            <c-input :model="assignment" for="rate" cols="1"></c-input>
            <c-input :model="assignment" for="isLongTerm" cols="2"></c-input>
            <v-col>
              <v-icon @click="assignment.$delete()" small color="error">fas fa-trash</v-icon>
            </v-col>
          </v-row>
          <v-btn @click="addAssignment(project)">add</v-btn>
        </v-card-text>
      </v-card>
    </v-container>

  </div>
</template>

<script lang="ts">
  import { Component, Vue } from "vue-property-decorator";
  import * as ViewModels from "@/viewmodels.g";

  @Component
  export default class Projects extends Vue {
    private projects = new ViewModels.ProjectListViewModel();

    async created() {
      await this.projects.$load();
    }

    addAssignment(project: ViewModels.ProjectViewModel) {
      var newAssignment = project.addToAssignments();
      newAssignment.project = project;
      newAssignment.$startAutoSave(this);
    }
    addProject() {
      alert("Don't you wish you could add a project. Go to the Projects Admin Page")
    }
  }

</script>
