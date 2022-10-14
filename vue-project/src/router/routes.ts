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

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: ROUTE.LANDING,
      name: "landing",
      component: LandingView,
      meta: {
        hideMenu: true,
        hideNavBar: true,
      },
    },
    {
      path: ROUTE.REGISTER,
      name: "register",
      component: RegisterViewVue,
      meta: {
        hideMenu: true,
        hideNavBar: true,
      },
    },
    {
      path: ROUTE.LOGIN,
      name: "login",
      component: LoginViewVue,
      meta: {
        hideMenu: true,
        hideNavBar: true,
      },
    },
    {
      path: ROUTE.CATEGORIES,
      name: "categories",
      component: CategoriesViewVue,
      meta: {
        requiresAuth: true,
        // middleware: auth,
        hideMenu: false,
        hideNavBar: false,
      },
    },
    {
      path: ROUTE.CATEGORIES + "/:categoryId",
      component: PlaylistsViewVue,
      meta: {
        middleware: auth,
        hideMenu: false,
        hideNavBar: false,
      },
    },
    {
      path: ROUTE.PLAYLISTS,
      component: PlaylistsViewVue,
      meta: {
        middleware: auth,
        hideMenu: false,
        hideNavBar: false,
      },
    },
    {
      path: ROUTE.PLAYLISTS + "/:playlistId",
      component: SongViewVue,
      meta: {
        middleware: auth,
        hideMenu: false,
        hideNavBar: false,
      },
    },
    {
      path: ROUTE.SONGS,
      component: SongViewVue,
      meta: {
        middleware: auth,
        hideMenu: false,
        hideNavBar: false,
      },
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

const noAuthRoutes = [ROUTE.LOGIN, ROUTE.REGISTER, ROUTE.LANDING];

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
  return next();
});


// maybe good implementation, but not used due to complexity(not needed)
// function nextFactory(context:any, middleware:any, index:any) {
//   const subsequentMiddleware = middleware[index];
//   // If no subsequent Middleware exists,
//   // the default `next()` callback is returned.
//   if (!subsequentMiddleware) return context.next;

//   return (...parameters) => {
//     // Run the default Vue Router `next()` callback first.
//     context.next(...parameters);
//     // Then run the subsequent Middleware with a new
//     // `nextMiddleware()` callback.
//     const nextMiddleware = nextFactory(context, middleware, index + 1);
//     subsequentMiddleware({ ...context, next: nextMiddleware });
//   };
// }

// router.beforeEach((to, from, next) => {
//   if (to.meta.middleware) {
//     const middleware = Array.isArray(to.meta.middleware)
//       ? to.meta.middleware
//       : [to.meta.middleware];
//     const context = {
//       from,
//       next,
//       router,
//       to,
//     };
//     const nextMiddleware = nextFactory(context, middleware, 1);

//     return middleware[0]({ ...context, next: nextMiddleware });
//   }

//   return next();
// });

export default router;
