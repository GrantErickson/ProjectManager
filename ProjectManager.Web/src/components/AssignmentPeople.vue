<template>
  <v-card>
    <v-card-title>
      <v-container>
        <v-row>
          <v-col
            ><span class="text-h5"
              >Users Based on Assignment Skills: {{ assignment.role }}</span
            >
          </v-col>
        </v-row>
        <v-row>
          <v-chip
            v-for="skill in assignment.skills"
            :key="skill.assignmentSkillId"
            class="mx-1"
            @click="showEditSkill(skill)"
            >{{ skill.skill?.name }}: {{ skill.level }}
          </v-chip>
        </v-row>
      </v-container>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Skills</th>
            <th>Assignments</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="user in users" :key="user.userId">
            <td>
              {{ user.name }} <br />
              {{
                user.assignments.reduce(
                  (partialSum, a) => partialSum + a.percentAllocated,
                  0
                )
              }}%
            </td>
            <td>
              <v-chip
                v-for="skill in user.skills"
                :key="skill.skillId"
                :color="color(skill)"
                small
                class="mx-1 my-1"
                >{{ skill.skill.name }}: {{ skill.level }}</v-chip
              >
            </td>
            <td>
              <v-chip
                v-for="userAssignment in user.assignments"
                :key="userAssignment.assignmentId"
                class="mx-1 my-1"
                x-small
              >
                {{ userAssignment.project.client.name }}:
                {{ userAssignment.role }} @
                {{ userAssignment.percentAllocated }}%
              </v-chip>
            </td>
          </tr>
        </tbody></v-simple-table
      >
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="blue darken-1" text @click="$emit('close')"> Close </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import { User } from "@/models.g";
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class AssignmentPeople extends Vue {
  @Prop() public assignment!: ViewModels.AssignmentViewModel;
  public users: User[] = [];

  mounted() {
    this.assignment.getUsersWithSkills().then((result) => {
      this.users = result.data.object as User[];
      console.log(this.users);
    });
  }

  color(skill: ViewModels.UserSkillViewModel) {
    let assignmentSkill = this.assignment.skills!.find(
      (s) => s.skillId === skill.skillId
    );
    if (assignmentSkill) {
      var target: number =
        !assignmentSkill.level == null ? 0 : assignmentSkill.level!;
      if (skill.level && skill.level >= target) {
        return "green";
      } else {
        return "yellow";
      }
    } else {
      return "";
    }
  }
}
</script>

<style></style>
