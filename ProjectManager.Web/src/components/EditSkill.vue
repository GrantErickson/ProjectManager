<template>
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
          <v-col cols="12">
            <c-input :model="skill" for="skill"></c-input>
          </v-col>
          <v-col cols="12">
            <c-input :model="skill" for="level"></c-input>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12">
            <pre v-if="skill.skill?.description"
              >{{ skill.skill?.description }}
            </pre>
            <span v-else>No Description</span>
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn color="red darken-1" text @click="deleteSkill"> Delete </v-btn>
      <v-btn color="blue darken-1" text @click="close"> Close </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";

@Component
export default class EditAssignment extends Vue {
  @Prop() private skill!: ViewModels.UserSkillViewModel;

  public deleteSkill() {
    this.skill.$delete();
    this.close();
  }

  public close() {
    if (!this.skill.skillId) {
      this.skill.$delete();
    }
    this.$emit("close");
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
