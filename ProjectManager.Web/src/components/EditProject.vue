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

      <!-- Start and End Dates -->
      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="startDate"></c-input>
      </v-col>
      <v-col cols="12" sm="6" md="6">
        <c-input :model="project" for="endDate"></c-input>
      </v-col>

      <v-col cols="12">
        <c-input :model="project" for="isPublic"></c-input>
      </v-col>

      <!-- Notes -->
      <v-col cols="12">
        <c-input :model="project" for="note" textarea></c-input>
      </v-col>
      <v-col cols="9">
        <h3>Notes</h3>
      </v-col>
      <v-col cols="3" class="text-right">
        <v-btn small @click="newNote">New Note</v-btn>
      </v-col>

      <v-col cols="12">
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
      </v-col>

      <!-- Contract -->
      <v-col cols="9">
        <h3>Contracts</h3>
      </v-col>
      <v-col cols="3" class="text-right">
        <v-btn small @click="newContract">New Contract</v-btn>
      </v-col>

      <v-col cols="12">
        <v-simple-table
          dense
          fixed-header
          class="d-flex flex-column"
          style="overflow-y: hidden"
          width="100%"
        >
          <thead>
            <tr>
              <th width="75%">Name</th>
              <th>State</th>
              <th>Amount</th>
              <th>Link</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="contract in project.contracts"
              :key="contract.contractId"
            >
              <td>
                <span>{{ contract.name }}</span>
              </td>
              <td><c-display :model="contract" for="state" /></td>
              <td><c-display :model="contract" for="amount" /></td>
              <td>
                <a
                  v-if="contract.contractUrl"
                  :href="contract.contractUrl"
                  target="_blank"
                >
                  Link</a
                >
              </td>
              <td>
                <v-icon x-small class="mx-4" @click="editContract(contract)"
                  >fas fa-pencil</v-icon
                >
              </td>
            </tr>
          </tbody>
        </v-simple-table>
      </v-col>
    </v-row>

    <v-dialog
      v-if="editContractShown"
      v-model="editContractShown"
      max-width="700px"
    >
      <v-card>
        <v-card-title>
          <span class="headline">Contract</span>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col cols="12">
              <c-input :model="selectedContract" for="name"></c-input>
            </v-col>
            <v-col cols="6">
              <c-input :model="selectedContract" for="amount"></c-input>
            </v-col>
            <v-col cols="6">
              <c-input :model="selectedContract" for="state"></c-input>
            </v-col>

            <v-col cols="6">
              <c-input :model="selectedContract" for="startDate"></c-input>
            </v-col>
            <v-col cols="6">
              <c-input :model="selectedContract" for="endDate"></c-input>
            </v-col>

            <v-col cols="6">
              <c-input :model="selectedContract" for="unusedAmount"></c-input>
            </v-col>
            <v-col cols="6">
              <c-input
                :model="selectedContract"
                for="hasMustNotExceed"
              ></c-input>
            </v-col>

            <v-col cols="12">
              <c-input :model="selectedContract" for="contractUrl"></c-input>
            </v-col>

            <v-col cols="12">
              <c-input :model="selectedContract" for="notes" textarea></c-input>
            </v-col>
          </v-row>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="red darken-1" text @click="deleteSelectedContract">
            Delete
          </v-btn>
          <v-btn color="blue darken-1" text @click="editContractShown = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class EditProject extends Vue {
  @Prop() private project!: ViewModels.ProjectViewModel | null;
  private editNote: ViewModels.ProjectNoteViewModel | null = null;
  private selectedContract: ViewModels.ContractViewModel | null = null;

  mounted() {
    this.sortNotes();
    this.sortContracts();
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

  newContract() {
    let contract = this.project!.addToContracts();
    contract.project = this.project;
    this.editContract(contract);
  }
  editContract(contract: ViewModels.ContractViewModel) {
    this.selectedContract = contract;
    this.selectedContract.$startAutoSave(this);
  }
  sortContracts() {
    this.project!.contracts!.sort((a, b) => {
      return b.startDate!.getTime() - a.startDate!.getTime();
    });
  }
  deleteSelectedContract() {
    if (this.selectedContract == null) return;
    if (confirm("Do you want to delete this item?")) {
      this.selectedContract.$delete();
      this.selectedContract = null;
    }
  }
  public get editContractShown() {
    return this.selectedContract != null;
  }
  public set editContractShown(value: boolean) {
    // Only used to close the dialog
    this.selectedContract = null;
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
