<template>
  <v-container>
    <v-row>
      <v-col cols="12" lg="7">
        <v-card>
          <v-card-title>
            {{ msg }}
          </v-card-title>
          <v-card-text class="black--text">
            <h2 class="headline font-weight-light mb-3">
              Here are some next steps to get started:
            </h2>
            <ol>
              <li>Add Skills you would like to track.</li>
              <li>
                Add Organization Users. You can add Skills to Organization
                Users.
              </li>
              <li>Add Clients and their associated Projects.</li>
              <li>Add Assignments to Projects. Assignments can have skills.</li>
              <li>
                Add Time Entries to Assignments to associate time with a User.
              </li>
              <li>Add notes to projects.</li>
              <li>
                Set up Billing Periods so be able to eventually do time
                approval.
              </li>
            </ol>
            <v-divider class="my-3" />
            <router-link
              :to="{
                name: 'coalesce-admin-list',
                params: { type: 'Organization' },
              }"
              class="headline font-weight-light"
            >
              Start with an organization
            </router-link>
          </v-card-text>
        </v-card>

        <v-card class="mt-5">
          <v-card-title>
            Admin Page Links
            <v-spacer></v-spacer>
            <a href="/coalesce-security" class="headline font-weight-light">
              Security Overview
            </a>
          </v-card-title>
          <v-card-text class="black--text">
            <v-simple-table dense>
              <thead>
                <tr>
                  <th>Type</th>
                  <th>Admin Table</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="type in adminTypes" :key="type.name">
                  <td>
                    {{ type.displayName }}
                  </td>
                  <td>
                    <router-link
                      :to="{
                        name: 'coalesce-admin-list',
                        params: { type: type.name },
                      }"
                    >
                      Table
                    </router-link>
                  </td>
                </tr>
              </tbody>
            </v-simple-table>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

import $metadata from "@/metadata.g";

@Component
export default class HelloWorld extends Vue {
  @Prop() private msg!: string | null;

  adminTypes = Object.values($metadata.types).filter((t) => t.type == "model");
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
