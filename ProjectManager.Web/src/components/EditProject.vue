<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="name"></c-input>
      </v-col>
      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="client"></c-input>
      </v-col>

      <v-col cols="12" sm="9" md="6">
        <c-input :model="project" for="lead"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="project" for="amount"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="project" for="projectState"></c-input>
      </v-col>

      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="startDate"></c-input>
      </v-col>

      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="endDate"></c-input>
      </v-col>

      <v-col cols="12">
        <c-input :model="project" for="note"></c-input>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";

@Component
export default class EditProject extends Vue {
  @Prop() private project!: ViewModels.ProjectViewModel | null;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
