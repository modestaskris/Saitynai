import CategoriesViewVue from "@/views/CategoriesView.vue";
import LoginViewVue from "@/views/LoginView.vue";
import PlaylistsViewVue from "@/views/PlaylistsView.vue";
import RegisterViewVue from "@/views/RegisterView.vue";
import SongViewVue from "@/views/SongView.vue";
import LandingView from "@/views/LandingView.vue";
import { createRouter, createWebHistory } from "vue-router";
import auth from "./authMiddleware";
import ROUTE from "./route";
import { TokenService } from "@/services/TokenService";
import NotFoundViewVue from '@/views/NotFoundView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: ROUTE.LANDING,
      name: "landing",
      component: LandingView,
    },
    {
      path: ROUTE.REGISTER,
      name: "register",
      component: RegisterViewVue,
    },
    {
      path: ROUTE.LOGIN,
      name: "login",
      component: LoginViewVue,
    },
    {
      path: ROUTE.CATEGORIES,
      name: "categories",
      component: CategoriesViewVue,
      meta: {
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.CATEGORIES + "/:categoryId",
      component: PlaylistsViewVue,
      meta: {
        middleware: auth,
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.PLAYLISTS,
      component: PlaylistsViewVue,
      meta: {
        middleware: auth,
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.PLAYLISTS + "/:playlistId",
      component: SongViewVue,
      meta: {
        middleware: auth,
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.SONGS,
      component: SongViewVue,
      meta: {
        middleware: auth,
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.SONGS,
      component: SongViewVue,
      meta: {
        middleware: auth,
        displayMenu: true,
        displayNavBar: true,
        displayFooter: true,
      },
    },
    {
      path: ROUTE.NOTFOUND,
      component: NotFoundViewVue,
    },
    // {
    //   path: "/",
    //   name: "home",
    //   component: HomeView,
    // },
    // {
    //   path: "/about",
    //   name: "about",
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import("../views/AboutView.vue"),
    // },import { ROUTE } from './route';
  ],


});

const noAuthRoutes = [ROUTE.LOGIN, ROUTE.REGISTER, ROUTE.LANDING, ROUTE.NOTFOUND];

router.beforeEach((to, from, next) => {
  if (noAuthRoutes.includes(to.path)) {
    return next();
  };
  const tokenIsValid = TokenService.tokenIsValid();
  if (!tokenIsValid) {
    // TODO: navigate to /login?
    router.push('/login');
    return;
  }
  console.log(`Going to route: ${to.path}`)

  return next();
});

export default router;
