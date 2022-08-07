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
      <v-col cols="10">
        <h3>Notes</h3>
      </v-col>
      <v-col cols="2">
        <v-btn @click="newNote">New Note</v-btn>
      </v-col>

      <v-simple-table
        dense
        fixed-header
        class="d-flex flex-column"
        style="overflow-y: hidden"
      >
        <thead>
          <tr>
            <th width="75%">Note</th>
            <th>Date</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="note in project.notes" :key="note.projectNoteId">
            <td>
              <span v-if="note != editNote">{{ note.note }}</span>
              <c-input
                v-if="note == editNote"
                :model="editNote"
                for="note"
              ></c-input>
            </td>
            <td><c-display :model="note" for="date" /></td>
            <td>
              <v-icon x-small color="red" @click="deleteNote(note)"
                >fas fa-trash</v-icon
              >
            </td>
          </tr>
        </tbody>
      </v-simple-table>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";

@Component
export default class EditProject extends Vue {
  @Prop() private project!: ViewModels.ProjectViewModel | null;
  private editNote: ViewModels.ProjectNoteViewModel | null = null;

  mounted() {
    this.sortNotes();
  }

  newNote() {
    this.editNote = this.project!.addToNotes();
    this.editNote.project = this.project;
    this.editNote.date = new Date();
    this.editNote.$startAutoSave;
    this.sortNotes();
  }

  sortNotes() {
    this.project!.notes!.sort((a, b) => {
      return b.date!.getTime() - a.date!.getTime();
    });
  }

  deleteNote(note: ViewModels.ProjectNoteViewModel) {
    if (confirm("Do you want to delete this item?")) {
      note.$delete();
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
