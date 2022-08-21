<template>
  <span>
    <v-tooltip v-if="text" :[location]="true">
      <template #activator="{ on }">
        <span v-on="on">
          <slot></slot>
        </span>
      </template>
      <span>
        {{ text }}
      </span>
    </v-tooltip>
    <span v-else>
      <slot></slot>
    </span>
  </span>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class AssignmentState extends Vue {
  @Prop() private text!: string;
  @Prop({ default: "top" }) private location!: string;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
