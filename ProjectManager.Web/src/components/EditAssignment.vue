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

    <v-dialog v-if="editSkill" v-model="editSkillShown" max-width="500px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Skill</span> </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="6">
                <c-input :model="editSkill" for="skill"></c-input>
              </v-col>

              <v-col cols="12" sm="6" md="6">
                <c-input :model="editSkill" for="level"></c-input>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="red darken-1" text @click="deleteEditSkill">
            Delete
          </v-btn>
          <v-btn color="blue darken-1" text @click="editSkill = null">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
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

  public deleteEditSkill() {
    if (this.editSkill) {
      this.editSkill!.$delete();
      this.editSkill = null;
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
