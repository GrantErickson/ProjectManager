<template>
  <v-container>
    <c-admin-table-toolbar :list="skills"></c-admin-table-toolbar>
    <c-table
      :list="skills"
      admin=""
      :props="['name']"
      :extra-headers="['Description']"
    >
      <template #item.append="{ item }">
        <td><c-input :model="item" for="description" textarea /></td>
      </template>
    </c-table>
    <c-list-pagination :list="skills"></c-list-pagination>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import * as ViewModels from "../viewmodels.g";

@Component
export default class SkillsAdmin extends Vue {
  private skills = new ViewModels.SkillListViewModel();

  created() {
    this.skills.$load();
    this.skills.$startAutoLoad(this);
  }
}
</script>
