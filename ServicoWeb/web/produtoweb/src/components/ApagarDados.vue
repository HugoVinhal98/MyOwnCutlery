<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <br />
    <h2>{{email}}</h2>
    <br />
    <br />
    <input type="checkbox" class="check" id="myCheck" />
    Tem a certeza que pretende
    <a>eliminar</a>os seus dados de cliente em definitivo?
    <br />
    <br />
    <button
      @click="deleteClienteByEmail()"
      id="deleteClienteByEmail"
      class="myButton"
    >Apagar informação pessoal</button>
    <!-- <h2>{{json}}</h2> -->
  </div>
</template>

<script>
import Vue from "vue";
//import router from 'vue-router'
import { store } from "../router/store.js";

export default {
  name: "perfil",
  data() {
    return {
      email: store.state.accessToken,
      nomeAux: document.getElementById("nome"),
      json: ""
    };
  },
  methods: {
    deleteClienteByEmail() {
      var checkBox = document.getElementById("myCheck");
      if (checkBox.checked == true) {
        var base = '{"email": "' + this.email + '" }';
        this.json = JSON.parse(base);
        Vue.axios
          .put(
            "http://localhost:3000/api/clientes/apagarcliente",
            JSON.parse(base)
          )
          .then(response => {
            this.cliente = response.data;
            var toHide = document.getElementsByClassName("hide");
            var logo = document.getElementsByClassName("logo");
            toHide.forEach(h => (h.style.display = "block"));
            logo.forEach(h => (h.style.display = "inline"));
            store.commit("setAccessToken", "");
            this.$router.push({ name: "login", query: { redirect: "/login" } });
            this.$alert("dados apagados em definitivo!");
          });
      } else {
        this.$alert("Tem de aceitar a eliminação em definitivo!");
      }
    },
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    }
  }
};
</script>

<style src="../assets/css/loginAppStyle.css">
</style>
