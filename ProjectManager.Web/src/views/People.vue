<template>
  <v-container>
    <v-row>
      <v-col>
        <h2>People</h2>
      </v-col>
    </v-row>
    <v-progress-linear
      :style="{ visibility: isLoading ? 'visible' : 'hidden' }"
      indeterminate
      color="primary"
    />

    <v-row v-for="person in people.$items" :key="person.userId">
      <!-- Person Card -->
      <v-col cols="3">
        <v-card class="my-card" color="brown lighten-4" elevation="8">
          <v-card-title>
            {{ person.name }}
          </v-card-title>
          <v-card-subtitle> ${{ person.defaultRate }} </v-card-subtitle>
          <v-divider />
          <v-card-text>
            Allocation:
            {{
              person.assignments.reduce(
                (acc, cur) => acc + cur.percentAllocated,
                0
              )
            }}%
            <!-- list skills -->
            <hr />
            <v-chip
              v-for="skill in person.skills"
              :key="skill.userSkillId"
              x-small
              class="mx-1"
              >{{ skill.skill.name }}: {{ skill.level }}
              <v-icon v-if="skill.isAreaOfInterest" class="ml-2" x-small
                >fa fa-thumbs-up</v-icon
              >
            </v-chip>
          </v-card-text>
        </v-card>
      </v-col>

      <!-- Cards for assignments -->
      <v-col
        v-for="assignment in person.assignments"
        :key="assignment.assignmentId"
        cols="3"
      >
        <AssignmentCard :assignment="assignment"></AssignmentCard>
      </v-col>
    </v-row>

    <!-- Assignment Dialog -->
    <v-dialog
      v-if="editAssignment"
      v-model="editAssignmentShown"
      max-width="800px"
    >
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col
                ><span class="text-h5">Assignment: {{ assignment.role }}</span>
              </v-col>
              <v-spacer></v-spacer>
              <v-col cols="3">
                <c-input :model="editAssignment" for="isFlagged"></c-input>
              </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <EditAssignment :assignment="editAssignment" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="editAssignment = null">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import EditAssignment from "@/components/EditAssignment.vue";
import * as ViewModels from "@/viewmodels.g";
import * as $models from "@/models.g";

@Component
export default class People extends Vue {
  private people = new ViewModels.UserListViewModel();
  private editAssignment: ViewModels.AssignmentViewModel | null = null;
  private dataSource = new $models.User.DataSources.UserWithAssignments();

  async created() {
    this.people.$dataSource = this.dataSource;
    this.people.$startAutoLoad(this);
    this.people.$load();
  }

  get isLoading() {
    return this.people.$load.isLoading;
  }

  promptDelete(assignment: ViewModels.AssignmentViewModel) {
    if (confirm("Do you want to delete this item?")) {
      assignment.$delete();
    }
  }
  showEditAssignment(assignment: ViewModels.AssignmentViewModel) {
    this.editAssignment = assignment;
    this.editAssignment.$startAutoSave(this);
  }
  public get editAssignmentShown() {
    return this.editAssignment != null;
  }
  public set editAssignmentShown(value: boolean) {
    this.editAssignment = null;
  }

  daysLeft(endDate: Date): number {
    var daysLeft =
      (endDate.getTime() - new Date().getTime()) / 1000 / 60 / 60 / 24;
    return daysLeft;
  }
  daysLeftText(assignment: ViewModels.AssignmentViewModel) {
    if (assignment.isLongTerm) {
      return "N/A";
    }
    if (assignment.endDate == null) {
      return "Unknown";
    }

    return this.daysLeft(assignment.endDate).toFixed(0);
  }
}
</script>

<style lang="scss">
.my-card {
  min-height: 200px;
}
</style>
