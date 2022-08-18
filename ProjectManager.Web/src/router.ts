import Vue from "vue";
import Router from "vue-router";
import { CAdminTablePage, CAdminEditorPage } from "coalesce-vue-vuetify/lib";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("./views/Home.vue"),
    },
    {
      path: "/projects",
      name: "projects",
      component: () => import("./views/Projects.vue"),
    },
    {
      path: "/people",
      name: "people",
      component: () => import("./views/People.vue"),
    },
    {
      path: "/projectList",
      name: "projectList",
      component: () => import("./views/ProjectList.vue"),
    },
    {
      path: "/user/:userId",
      name: "user",
      component: () => import("./views/UserDashboard.vue"),
    },

    // Coalesce admin routes
    {
      path: "/admin/:type",
      name: "coalesce-admin-list",
      component: CAdminTablePage,
      props: (r) => ({
        type: r.params.type,
      }),
    },
    {
      path: "/admin/:type/edit/:id?",
      name: "coalesce-admin-item",
      component: CAdminEditorPage,
      props: (r) => ({
        type: r.params.type,
        id: r.params.id,
      }),
    },
  ],
});
