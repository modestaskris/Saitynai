import { createApp } from "vue";
import { createPinia } from "pinia";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faUserSecret } from "@fortawesome/free-solid-svg-icons";
import { faUsersRectangle } from "@fortawesome/free-solid-svg-icons";
import { faMusic } from "@fortawesome/free-solid-svg-icons";
import { faFolderOpen } from "@fortawesome/free-solid-svg-icons";
import { faList } from "@fortawesome/free-solid-svg-icons";
import { faArrowRightFromBracket } from "@fortawesome/free-solid-svg-icons";
import { faArrowRightToBracket } from "@fortawesome/free-solid-svg-icons";
import { faUserPlus } from "@fortawesome/free-solid-svg-icons";
import { faAnglesRight } from "@fortawesome/free-solid-svg-icons";
import { faAnglesLeft } from "@fortawesome/free-solid-svg-icons";
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { faTrashCan } from "@fortawesome/free-regular-svg-icons";
import { faArrowUpRightFromSquare } from "@fortawesome/free-solid-svg-icons";

import App from "./App.vue";
import router from "./router/routes";

import "./style.css";

library.add(faUserSecret);
library.add(faUsersRectangle);
library.add(faFolderOpen);
library.add(faMusic);
library.add(faList);
library.add(faArrowRightFromBracket);
library.add(faArrowRightToBracket);
library.add(faUserPlus);
library.add(faAnglesRight);
library.add(faAnglesLeft);
library.add(faTrashCan);
library.add(faPen);
library.add(faArrowUpRightFromSquare);

const app = createApp(App).component("font-awesome-icon", FontAwesomeIcon);
app.use(createPinia());
app.use(router);

app.mount("#app");

// TODO: instantly after login app does not use token to fetch categories and does not update token... FIX CRITICAL
// TODO: make /user route secure and accessable only for admin...
// TODO: use grid in model row to guarantee absolute positions