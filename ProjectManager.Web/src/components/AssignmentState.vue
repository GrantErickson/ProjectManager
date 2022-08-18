<template>
  <span>
    <!-- Unknown -->
    <v-icon v-if="state == 0" small>fas fa-circle-question</v-icon>
    <!-- Active -->
    <v-icon v-if="state == 1" small color="green">fas fa-check-circle</v-icon>
    <!-- Contracting -->
    <v-icon v-if="state == 2" small color="blue darken-2"
      >fas fa-file-signature</v-icon
    >
    <!-- Completed -->
    <v-icon v-if="state == 3" small>fas fa-clipboard-check</v-icon>
    <!-- Potential -->
    <v-icon v-if="state == 4" small color="yellow darken-3"
      >fas fa-face-smile</v-icon
    >
    <!-- Lost -->
    <v-icon v-if="state == 5" small>fas fa-face-frown</v-icon>
    <!-- Paused -->
    <v-icon v-if="state == 6" small color="orange">fas fa-pause</v-icon>
  </span>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import * as $models from "../models.g";

@Component
export default class AssignmentState extends Vue {
  @Prop() private state!: $models.AssignmentStateEnum;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
