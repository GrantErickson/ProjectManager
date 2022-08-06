<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="6" md="6">
        <c-input :model="assignment" for="role"></c-input>
      </v-col>

      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="percentAllocated"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="isLongTerm"></c-input>
      </v-col>

      <v-col cols="12" sm="9" md="6">
        <c-input :model="assignment" for="user"></c-input>
      </v-col>

      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="rate"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="rateRange"></c-input>
      </v-col>

      <v-col cols="12" sm="6" md="6">
        <c-input :model="assignment" for="startDate"></c-input>
      </v-col>

      <v-col cols="12" sm="6" md="6">
        <c-input :model="assignment" for="endDate"></c-input>
      </v-col>

      <v-col cols="12">
        Skills:
        <v-chip
          v-for="skill in assignment.skills"
          :key="skill.assignmentSkillId"
          >{{ skill.skill.name }}: {{ skill.level }}</v-chip
        >
      </v-col>

      <v-col cols="12">
        <c-input :model="assignment" for="note"></c-input>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";

@Component
export default class EditAssignment extends Vue {
  @Prop() private assignment!: ViewModels.AssignmentViewModel | null;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
