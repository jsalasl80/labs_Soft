import { createApp } from "vue";
import App from "./App.vue";

import { createRouter, createWebHistory } from "vue-router";
import CountriesList from "./components/CountriesList.vue";
import CountryForm from "./components/CountryForm.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: CountriesList,
  },
  {
    path: "/country",
    name: "Country",
    component: CountryForm,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

createApp(App).use(router).mount("#app");