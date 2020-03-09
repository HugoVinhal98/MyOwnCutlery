import Vue from 'vue';
import Vuex from 'vuex';
import VuexPersist from 'vuex-persist';

Vue.use(Vuex);

const vuexPersist = new VuexPersist({
    key: 'access_token'
    //storage: sessionStorage
},
    {
        key: 'title'
        //storage: sessionStorage
    });

export const store = new Vuex.Store({
    state: {
        accessToken: "",
        title: ""
    },
    mutations: {
        setAccessToken(state, accessToken) {
            state.accessToken = accessToken;
        },
        revokeAccessToken(state) {
            state.accessToken = "";
        },
        setTitle(state, title) {
            state.title = title;
        },
        removeTitle(state) {
            state.title = "";
        }
    },
    plugins: [vuexPersist.plugin]
});