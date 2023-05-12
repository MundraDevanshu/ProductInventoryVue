import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store/store'
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";
import "v-toaster/dist/v-toaster.css";


library.add(fas);


createApp(App).component("fa", FontAwesomeIcon).use(store).use(router).mount('#app')
