import Vue from 'vue'
import App from './LoginApp.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueSimpleAlert from "vue-simple-alert"
import VueNumericInput from 'vue-numeric-input';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faUser } from '@fortawesome/free-regular-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { DropDownListPlugin } from '@syncfusion/ej2-vue-dropdowns'
import { DropDownButtonPlugin } from "@syncfusion/ej2-vue-splitbuttons";
import { enableRipple } from '@syncfusion/ej2-base';

enableRipple(true);
Vue.use(DropDownButtonPlugin);
Vue.use(VueAxios, axios);
Vue.use(VueSimpleAlert);
Vue.use(VueNumericInput);
Vue.use(DropDownListPlugin);

library.add(faUser);
Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
