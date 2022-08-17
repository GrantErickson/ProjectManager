<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="6" md="6">
        <c-input :model="assignment" for="role"></c-input>
      </v-col>
      <v-col cols="12" sm="9" md="6">
        <c-input :model="assignment" for="user"></c-input>
      </v-col>

      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="percentAllocated"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="assignmentState"></c-input>
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

      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="isLongTerm"></c-input>
      </v-col>
      <v-col cols="12" sm="3" md="3">
        <c-input :model="assignment" for="isBillable"></c-input>
      </v-col>

      <v-col cols="12">
        <c-input :model="assignment" for="note"></c-input>
      </v-col>

      <v-col cols="12">
        Skills:
        <v-chip
          v-for="skill in assignment.skills"
          :key="skill.assignmentSkillId"
          class="mx-1"
          @click="showEditSkill(skill)"
          >{{ skill.skill?.name }}: {{ skill.level }}
        </v-chip>
        <v-chip @click="addSkill"><v-icon>fas fa-plus</v-icon></v-chip>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-btn @click="showUsers = true"> Matching users </v-btn>
      </v-col>
    </v-row>
    <v-dialog v-if="showUsers" v-model="showUsers" max-width="900px">
      <AssignmentPeople
        :assignment="assignment"
        @close="hideShowUsers"
      ></AssignmentPeople>
    </v-dialog>

    <v-dialog v-if="editSkill" v-model="editSkillShown" max-width="500px">
      <EditSkill :skill="editSkill" @close="editSkill = null"></EditSkill>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";

@Component
export default class EditAssignment extends Vue {
  @Prop() private assignment!: ViewModels.AssignmentViewModel;
  private editSkill: ViewModels.AssignmentSkillViewModel | null = null;
  private showUsers = false;

  addSkill() {
    this.editSkill = this.assignment.addToSkills();
    this.editSkill.$startAutoSave(this);
  }

  showEditSkill(skill: ViewModels.AssignmentSkillViewModel) {
    this.editSkill = skill;
    this.editSkill.$startAutoSave(this);
  }
  public get editSkillShown() {
    return this.editSkill != null;
  }
  public set editSkillShown(value: boolean) {
    // Only used to close the dialog
    this.editSkill = null;
  }

  public hideShowUsers() {
    this.showUsers = false;
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
