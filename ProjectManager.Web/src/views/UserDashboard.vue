<template>
  <v-container>
    <v-row>
      <v-col>
        <h2>{{ user.name }}'s Dashboard</h2>
      </v-col>
    </v-row>
    <v-progress-linear
      :style="{ visibility: isLoading ? 'visible' : 'hidden' }"
      indeterminate
      color="primary"
    />

    <!-- Skills Card -->
    <v-row>
      <v-col cols="12">
        <v-card>
          <v-card-title> Skills </v-card-title>
          <v-card-text>
            <!-- list skills -->
            <v-simple-table>
              <thead>
                <tr>
                  <th>Skill</th>
                  <th>Level</th>
                  <th>Area of Interest</th>
                  <th>Note</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="skill in user.skills"
                  :key="skill.userSkillId"
                  class="mx-1"
                >
                  <td>{{ skill.skill.name }}</td>
                  <td>{{ skill.level }}</td>
                  <td>
                    <v-icon v-if="skill.isAreaOfInterest" class="ml-2"
                      >fa fa-thumbs-up</v-icon
                    >
                  </td>
                  <td>
                    {{ skill.note }}
                  </td>
                  <td class="text-right">
                    <!-- Editor for skill -->
                    <v-icon small @click="editSkill(skill)"
                      >fa fa-pencil</v-icon
                    >
                  </td>
                </tr>
              </tbody>
            </v-simple-table>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Cards for assignments -->
    <v-row>
      <v-col>
        <h2>Assignments</h2>
      </v-col>
    </v-row>

    <v-row>
      <v-col
        v-for="assignment in user.assignments"
        :key="assignment.assignmentId"
        cols="3"
      >
        <AssignmentCard :assignment="assignment"></AssignmentCard>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import EditAssignment from "@/components/EditAssignment.vue";
import * as ViewModels from "@/viewmodels.g";
import * as $models from "@/models.g";

@Component
export default class People extends Vue {
  private user = new ViewModels.UserViewModel();
  private dataSource = new $models.User.DataSources.UserWithAssignments();

  async created() {
    this.user.$dataSource = this.dataSource;
    let userId = this.$route.params.userId;
    if (typeof userId === "string") {
      this.user.$load(userId);
    }
  }

  get isLoading() {
    return this.user.$load.isLoading;
  }

  editSkill(skill: $models.UserSkill) {
    console.log("Open Dialog to edit Skill: " + skill.userSkillId);
    // Show edit dialog
  }
}
</script>

<style lang="scss">
.my-card {
  min-height: 200px;
}
</style>
