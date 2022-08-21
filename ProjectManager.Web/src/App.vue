<template>
  <v-app id="vue-app">
    <v-navigation-drawer v-model="drawer" app clipped>
      <v-list>
        <v-list-item link to="/">
          <v-list-item-action>
            <v-icon>fas fa-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/projects">
          <v-list-item-action>
            <v-icon>fas fa-box</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Manage Projects</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/people">
          <v-list-item-action>
            <v-icon>fas fa-person</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>People's Projects</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item>
          <v-divider></v-divider>
        </v-list-item>

        <v-list-item link to="/admin/TimeEntry">
          <v-list-item-action>
            <v-icon>fas fa-clock</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Time Entry (admin)</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/ProjectList">
          <v-list-item-action>
            <v-icon>fas fa-list</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Project List</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item>
          <v-divider></v-divider>
        </v-list-item>

        <v-list-item link to="/skillsAdmin">
          <v-list-item-action>
            <v-icon>fas fa-list</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Skills</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/admin/User">
          <v-list-item-action>
            <v-icon>fas fa-users</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>People</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/admin/Client">
          <v-list-item-action>
            <v-icon>fas fa-user-tie</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Clients</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/admin/Project">
          <v-list-item-action>
            <v-icon>fas fa-box</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Projects</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/admin/Assignment">
          <v-list-item-action>
            <v-icon>fas fa-check-double</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Assignment Admin</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item>
          <v-divider></v-divider>
        </v-list-item>

        <v-list-item link to="/admin/Organization">
          <v-list-item-action>
            <v-icon>fas fa-building</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Organizations</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item link to="/admin/ApplicationUser">
          <v-list-item-action>
            <v-icon>fas fa-user</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Login Users</v-list-item-title>
          </v-list-item-content>
        </v-list-item>

        <v-list-item>
          <v-divider></v-divider>
        </v-list-item>

        <v-list-item href="/MicrosoftIdentity/Account/SignOut">
          <v-list-item-action>
            <v-icon>fas fa-sign-out</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Sign Out</v-list-item-title>
            <v-list-item-subtitle v-if="userInfo">{{
              userInfo.name
            }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app color="primary" dark dense clipped-left>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>
        <router-link to="/" class="white--text" style="text-decoration: none">
          IntelliManager
        </router-link>
      </v-toolbar-title>
    </v-app-bar>

    <v-main>
      <transition
        name="router-transition"
        mode="out-in"
        appear
        @enter="routerViewOnEnter"
      >
        <!-- https://stackoverflow.com/questions/52847979/what-is-router-view-key-route-fullpath -->
        <router-view ref="routerView" :key="$route.path" />
      </transition>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";
import * as ViewModels from "@/viewmodels.g";
import * as $models from "@/models.g";

@Component({
  components: {},
})
export default class App extends Vue {
  drawer: boolean | null = null;
  routeComponent: Vue | null = null;
  userInfo: $models.UserInfo | null = null!;

  get routeMeta() {
    if (!this.$route || this.$route.name === null) return null;

    return this.$route.meta;
  }

  routerViewOnEnter() {
    this.routeComponent = this.$refs.routerView as Vue;
  }

  created() {
    // Get the user name
    let userService = new ViewModels.UserServiceViewModel();
    userService.getUserInfo().then((result) => {
      if (result.data.wasSuccessful) {
        this.userInfo = result.data.object || null;
      }
    });
    const baseTitle = document.title;
    this.$watch(
      () => (this.routeComponent as any)?.pageTitle,
      (n: string | null | undefined) => {
        if (n) {
          document.title = n + " - " + baseTitle;
        } else {
          document.title = baseTitle;
        }
      },
      { immediate: true }
    );
  }
}
</script>

<style lang="scss">
.router-transition-enter-active,
.router-transition-leave-active {
  // transition: 0.2s cubic-bezier(0.25, 0.8, 0.5, 1);
  transition: 0.1s ease-out;
}

.router-transition-move {
  transition: transform 0.4s;
}

.router-transition-enter,
.router-transition-leave-to {
  opacity: 0;
  // transform: translateY(5px);
}
</style>
