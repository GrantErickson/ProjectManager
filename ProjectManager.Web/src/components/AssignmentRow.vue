<template>
  <tr>
    <td>
      <span>
        <!-- Unknown -->
        <v-icon v-if="assignment.assignmentState == 0" small
          >fas fa-circle-question</v-icon
        >
        <!-- Active -->
        <v-icon v-if="assignment.assignmentState == 1" small color="green"
          >fas fa-check-circle</v-icon
        >
        <!-- Contracting -->
        <v-icon
          v-if="assignment.assignmentState == 2"
          small
          color="blue darken-2"
          >fas fa-file-signature</v-icon
        >
        <!-- Completed -->
        <v-icon v-if="assignment.assignmentState == 3" small
          >fas fa-clipboard-check</v-icon
        >
        <!-- Potential -->
        <v-icon
          v-if="assignment.assignmentState == 4"
          small
          color="yellow darken-3"
          >fas fa-face-smile</v-icon
        >
        <!-- Lost -->
        <v-icon v-if="assignment.assignmentState == 5" small
          >fas fa-face-frown</v-icon
        >
        <!-- Paused -->
        <v-icon v-if="assignment.assignmentState == 6" small color="orange"
          >fas fa-pause</v-icon
        >
      </span>
      <span class="mx-2">
        {{ assignment.role }}
      </span>
    </td>
    <td>
      <v-tooltip v-if="assignment.user" top>
        <template #activator="{ on }">
          <span v-on="on">{{ assignment.user?.name }}</span>
        </template>
        <span v-if="assignment.user.defaultRate"
          >${{ assignment.user.defaultRate }}</span
        >
        <span v-else>not set</span>
      </v-tooltip>
      <v-chip v-if="!assignment.user" small color="yellow">needed</v-chip>
    </td>
    <td>{{ assignment.percentAllocated }}</td>
    <td>
      <v-tooltip v-if="assignment.user" top>
        <template #activator="{ on }">
          <span>
            <span
              v-if="assignment.rate"
              :class="
                assignment.rate != assignment.user?.defaultRate
                  ? 'yellow lighten-4'
                  : ''
              "
              v-on="on"
              >${{ assignment.rate }}</span
            >
          </span>
        </template>
        <span v-if="assignment.user"
          >{{ assignment.user.name }} standard rate: ${{
            assignment.user.defaultRate
          }}</span
        >
        <span v-else>no user set</span>
      </v-tooltip>
    </td>
    <td>{{ daysLeft }}</td>
    <td>{{ assignment.note }}</td>
    <td>
      <!-- Icons -->
      <v-icon
        v-if="assignment.isBillable"
        small
        color="blue darken-2"
        class="mx-2"
        >fas fa-dollar-sign</v-icon
      >
      <v-icon v-if="assignment.isLongTerm" small color="green"
        >fas fa-road-circle-check</v-icon
      >
      <v-icon v-if="assignment.isFlagged" small color="red" class="mx-2"
        >fas fa-flag</v-icon
      >
      <v-tooltip top>
        <template #activator="{ on }">
          <v-icon v-if="assignment.skills.length" x-small class="mx-2" v-on="on"
            >fas fa-list</v-icon
          >
        </template>
        <span>
          <v-chip
            v-for="skill in assignment.skills.filter((f) => f.skill)"
            :key="skill.assignmentSkillId"
            small
            class="mx-1"
          >
            {{ skill.skill.name }}:
            {{ skill.level }}
          </v-chip>
        </span>
      </v-tooltip>
      <v-icon v-if="assignment.isPublic" small color="blue" class="mx-2"
        >fas fa-globe</v-icon
      >
    </td>

    <td class="text-right">
      <v-icon small color="" class="mx-2" @click="showEditor"
        >fas fa-pencil</v-icon
      >
      <v-icon small color="error" @click="promptDelete()">fas fa-trash</v-icon>
    </td>

    <v-dialog v-if="showEdit" v-model="showEdit" max-width="800px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col
                ><span class="text-h5">Assignment: {{ assignment.role }}</span>
              </v-col>
              <v-spacer></v-spacer>
              <v-col cols="3">
                <c-input :model="assignment" for="isFlagged"></c-input>
              </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <EditAssignment :assignment="assignment" />
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="showEdit = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </tr>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class AssignmentRow extends Vue {
  @Prop() public assignment!: ViewModels.AssignmentViewModel;
  private showEdit = false;

  promptDelete() {
    if (confirm("Do you want to delete this item?")) {
      this.assignment.$delete();
    }
  }

  public showEditor() {
    this.assignment.$startAutoSave(this);
    this.showEdit = true;
  }

  get daysLeft() {
    if (this.assignment.isLongTerm) {
      return "N/A";
    }
    if (this.assignment.endDate == null) {
      return "Unknown";
    }
    var daysLeft =
      (this.assignment.endDate.getTime() - new Date().getTime()) /
      1000 /
      60 /
      60 /
      24;
    return daysLeft.toFixed(0);
  }
}
</script>

<style></style>
