<template>
  <v-container>
    <c-admin-table-toolbar :list="skills"></c-admin-table-toolbar>
    <c-table
      :list="skills"
      admin=""
      :props="['name', 'assignments', 'users']"
      :extra-headers="['Description', '']"
    >
      <template #item.append="{ item }">
        <td>
          <pre>{{ item.description }}</pre>
        </td>
        <td class="text-right">
          <v-icon @click="showEditSkill(item)">fa fa-pen-to-square</v-icon>
        </td>
      </template>
    </c-table>
    <c-list-pagination :list="skills"></c-list-pagination>

    <v-dialog v-if="editSkillShown" v-model="editSkillShown" max-width="800px">
      <v-card>
        <v-card-title>
          <v-container>
            <v-row>
              <v-col><span class="text-h5">Skill</span> </v-col>
            </v-row>
          </v-container>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col cols="12">
              <c-input :model="selectedSkill" for="name"></c-input>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <c-input
                :model="selectedSkill"
                for="description"
                textarea
              ></c-input>
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="red darken-1" text @click="deleteSelectedSkill">
            Delete
          </v-btn>
          <v-btn color="blue darken-1" text @click="editSkillShown = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class SkillsAdmin extends Vue {
  private skills = new ViewModels.SkillListViewModel();
  private selectedSkill: ViewModels.SkillViewModel | null = null;
  private editSkillShown = false;

  created() {
    this.skills.$load();
    this.skills.$startAutoLoad(this);
  }

  showEditSkill(skill: ViewModels.SkillViewModel) {
    this.selectedSkill = skill;
    this.selectedSkill.$startAutoSave(this);
    this.editSkillShown = true;
  }

  deleteSelectedSkill() {
    if (this.selectedSkill && confirm("Delete this skill?")) {
      this.selectedSkill.$delete();
      this.selectedSkill = null;
      this.editSkillShown = false;
    }
  }
}
</script>
