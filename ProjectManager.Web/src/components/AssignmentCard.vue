<template>
  <v-card class="my-card" @click="showEditor">
    <v-card-title>
      {{ assignment.project.name }}
    </v-card-title>
    <v-card-subtitle>
      {{ assignment.role }} @ {{ assignment.percentAllocated }}%
    </v-card-subtitle>
    <v-divider />
    <v-card-text>
      <div>
        <v-icon
          v-if="assignment.isBillable"
          small
          color="blue darken-2"
          class="mx-2"
          >fas fa-dollar-sign</v-icon
        >
        <v-icon v-if="assignment.isLongTerm" small color="green" class="mx-2"
          >fas fa-road-circle-check</v-icon
        >
        <v-icon v-if="assignment.isFlagged" small color="red" class="mx-2"
          >fas fa-flag</v-icon
        >
        <v-chip small>{{ assignment.state() }}</v-chip>
      </div>
      <div>{{ assignment.project.client.name }} @ ${{ assignment.rate }}</div>
      <div v-if="assignment.endDate">
        ends in {{ daysLeftText(assignment) }} days
        <v-icon v-if="daysLeft(assignment.endDate) < 25" color="red"
          >fas fa-circle-exclamation</v-icon
        >
      </div>
    </v-card-text>
    <v-dialog v-if="showEdit" v-model="showEdit" max-width="800px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Assignment</span> </v-col>
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
  </v-card>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class AssignmentCard extends Vue {
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
