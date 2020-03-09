<template>
  <div id="app">
    <div class="user">
      <button class="myButton" id="terminarsessao" @click="logOut()">Terminar sessão</button>
      <!-- <font-awesome-icon :icon="['far', 'user']" />
      {{email}}-->
      <!-- <br />
      <br />-->
      <ejs-dropdownbutton
        :items="itemsAdmin"
        class="adminDrop"
        iconCss="ddb-icons e-paste"
      >{{email}}</ejs-dropdownbutton>
      <ejs-dropdownbutton
        :items="items"
        class="clienteDrop drop"
        iconCss="ddb-icons e-paste"
      >{{email}}</ejs-dropdownbutton>
    </div>
    <h1 class="titulo">MyOwnCutlery</h1>
    <img alt="Vue logo" src="./assets/cutlery.png" />
    <br />
    <div class="nav">
      <router-link to="/produto" class="admin">Produto</router-link>
      <router-link to="/operacao" class="admin">Operação</router-link>
      <router-link to="/tipoMaquina" class="admin">Tipo Maquina</router-link>
      <router-link to="/maquina" class="admin">Maquina</router-link>
      <router-link to="/linhaproducao" class="admin">LinhaProducao</router-link>
      <router-link to="/cliente" class="admin">Cliente</router-link>
      <router-link to="/encomenda" class="clienteDrop encomendaUser">Encomenda</router-link>
      <router-link to="/encomendaAdmin" class="admin">Encomenda</router-link>

      <a :href=" publicPath + 'index2.html'">Fabrica</a>
    </div>
    <main class="App__main">
      <transition
        name="fade"
        mode="out-in"
        @beforeLeave="beforeLeave"
        @enter="enter"
        @afterEnter="afterEnter"
      >
        <router-view />
      </transition>
    </main>
  </div>
</template>

<script>
import { store } from "./router/store.js";
import Vue from "vue";

export default {
  data() {
    return {
      teste: "",
      urlHost: "http://localhost:8080/#/",
      // urlHost:"azure",
      publicPath: process.env.BASE_URL,
      email: store.state.accessToken,
      items: [
        {
          text: "Perfil do utilizador",
          url: "http://localhost:8080/#/perfil"
        },
        {
          text: "Alterar definições",
          url: "http://localhost:8080/#/alterarCliente"
        },
        {
          text: "Apagar dados",
          url: "http://localhost:8080/#/apagarDados"
        }
      ],
      itemsAdmin: [
        {
          text: "Alterar definições de um cliente",
          url: "http://localhost:8080/#/alterarClienteAdmin"
        }
      ]
    };
  },
  mounted() {
    var toHide = document.getElementsByClassName("hide");
    toHide.forEach(h => (h.style.display = "none"));

    if (store.state.accessToken !== "admin") {
      document
        .getElementsByClassName("admin")
        .forEach(e => (e.style.display = "none"));
      document
        .getElementsByClassName("adminDrop")
        .forEach(e => (e.style.display = "none"));
    }
    if (store.state.accessToken == "admin") {
      document
        .getElementsByClassName("adminDrop")
        .forEach(e => (e.style.display = "inline-block"));
      document
        .getElementsByClassName("clienteDrop")
        .forEach(e => (e.style.display = "none"));
    }

    Vue.axios
      .get("http://localhost:3000/api/clientes/permissao")
      .then(response => {
        this.teste = response.data;
        if (this.teste != true) {
          document
            .getElementsByClassName("encomendaUser")
            .forEach(e => (e.style.display = "none"));
        }
      })
      .catch(error => {
        console.warn(error);
      });

    Vue.axios
      .get("http://localhost:3000/api/clientes/permissao2")
      .then(response => {
        this.teste = response.data;
        if (this.teste != true) {
          document
            .getElementsByClassName("drop")
            .forEach(e => (e.style.display = "none"));
        }
      })
      .catch(error => {
        console.warn(error);
      });
  },

  methods: {
    logOut() {
      var toHide = document.getElementsByClassName("hide");
      var logo = document.getElementsByClassName("logo");
      toHide.forEach(h => (h.style.display = "block"));
      logo.forEach(h => (h.style.display = "inline"));

      store.commit("setAccessToken", "");
      this.$router.push({ name: "login", query: { redirect: "/login" } });
    },
    beforeLeave(element) {
      this.prevHeight = getComputedStyle(element).height;
    },
    enter(element) {
      const { height } = getComputedStyle(element);

      element.style.height = this.prevHeight;

      setTimeout(() => {
        element.style.height = height;
      });
    },
    afterEnter(element) {
      element.style.height = "auto";
    }
  }
};
</script>

<style>
@import "../node_modules/@syncfusion/ej2-base/styles/material.css";
@import "../node_modules/@syncfusion/ej2-buttons/styles/material.css";
@import "../node_modules/@syncfusion/ej2-popups/styles/material.css";
@import "../node_modules/@syncfusion/ej2-splitbuttons/styles/material.css";
@font-face {
  font-family: "e-db-icons";
  src: url(data:application/x-font-ttf;charset=utf-8;base64,AAEAAAAKAIAAAwAgT1MvMj0jSRoAAAEoAAAAVmNtYXDnFudgAAABkAAAADpnbHlmSrKTCAAAAdgAAAC4aGVhZBKtK8cAAADQAAAANmhoZWEHmQNtAAAArAAAACRobXR4D7gAAAAAAYAAAAAQbG9jYQB4ADoAAAHMAAAACm1heHABEAAYAAABCAAAACBuYW1lH00mDAAAApAAAAJJcG9zdIwkSr0AAATcAAAATQABAAADUv9qAFoEAAAA//4D6gABAAAAAAAAAAAAAAAAAAAABAABAAAAAQAAGc/PS18PPPUACwPoAAAAANfSc3wAAAAA19JzfAAAAAAD6gPqAAAACAACAAAAAAAAAAEAAAAEAAwAAgAAAAAAAgAAAAoACgAAAP8AAAAAAAAAAQPuAZAABQAAAnoCvAAAAIwCegK8AAAB4AAxAQIAAAIABQMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUGZFZABA5wPnBQNS/2oAWgPqAJYAAAABAAAAAAAABAAAAAPoAAAD6AAAA+gAAAAAAAIAAAADAAAAFAADAAEAAAAUAAQAJgAAAAQABAABAADnBf//AADnA///AAAAAQAEAAAAAQACAAMAAAAAAAAAHAA6AFwAAAACAAAAAAPqA2UABgAKAAA3IREjCQEjBRcBIQID6AL+Dv4NAQEY3QG4/I+IAsL+GAHonroBcwAAAAIAAAAAA8YD6gAFAAoAADchESMJASUHCQImA6AD/jL+MQEEywGWAZb+agICX/4+AcLXsv6cAWQBZAAAAAEAAAAAA+oD6gALAAATCQEXCQE3CQEnCQECATP+zcIBMgEzwf7OATLB/s3+zgMp/s3+zsIBM/7NwgEyATPB/s4BMgAAAAASAN4AAQAAAAAAAAABAAAAAQAAAAAAAQAKAAEAAQAAAAAAAgAHAAsAAQAAAAAAAwAKABIAAQAAAAAABAAKABwAAQAAAAAABQALACYAAQAAAAAABgAKADEAAQAAAAAACgAsADsAAQAAAAAACwASAGcAAwABBAkAAAACAHkAAwABBAkAAQAUAHsAAwABBAkAAgAOAI8AAwABBAkAAwAUAJ0AAwABBAkABAAUALEAAwABBAkABQAWAMUAAwABBAkABgAUANsAAwABBAkACgBYAO8AAwABBAkACwAkAUcgZS1kYi1pY29uc1JlZ3VsYXJlLWRiLWljb25zZS1kYi1pY29uc1ZlcnNpb24gMS4wZS1kYi1pY29uc0ZvbnQgZ2VuZXJhdGVkIHVzaW5nIFN5bmNmdXNpb24gTWV0cm8gU3R1ZGlvd3d3LnN5bmNmdXNpb24uY29tACAAZQAtAGQAYgAtAGkAYwBvAG4AcwBSAGUAZwB1AGwAYQByAGUALQBkAGIALQBpAGMAbwBuAHMAZQAtAGQAYgAtAGkAYwBvAG4AcwBWAGUAcgBzAGkAbwBuACAAMQAuADAAZQAtAGQAYgAtAGkAYwBvAG4AcwBGAG8AbgB0ACAAZwBlAG4AZQByAGEAdABlAGQAIAB1AHMAaQBuAGcAIABTAHkAbgBjAGYAdQBzAGkAbwBuACAATQBlAHQAcgBvACAAUwB0AHUAZABpAG8AdwB3AHcALgBzAHkAbgBjAGYAdQBzAGkAbwBuAC4AYwBvAG0AAAAAAgAAAAAAAAAKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAQIBAwEEAQUADG1lc3NhZ2UtbWFpbAtyZWFkLXVucmVhZAZkZWxldGUAAAAAAA==)
    format("truetype");
  font-weight: normal;
  font-style: normal;
}

.fade-enter-active,
.fade-leave-active {
  transition-duration: 0.3s;
  transition-property: height, opacity;
  transition-timing-function: ease;
  overflow: hidden;
}

.fade-enter,
.fade-leave-active {
  opacity: 0;
}

p {
  display: inline-block;
  width: 100%;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  font-weight: bold;
}

.hide img {
  padding-left: 720;
}

.titulo {
  font-size: 300%;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

img {
  width: 150px;
  margin-top: 10px;
  margin-bottom: 40px;
}

a {
  color: #2c3e50;
  font-weight: bold;
  text-decoration: none;
  margin: 0 10px 0 10px;
}

a:hover {
  border: black solid 1px;
}

a:visited {
  text-decoration: none;
}

.user {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  font-weight: bold;
  text-align: right;
  padding: 0;

  margin: 20px 15px 0 0;
}

.ddb-icons {
  font-family: "e-db-icons" !important;
  font-size: 55px;
  font-style: normal;
  font-weight: normal;
  font-variant: normal !important;
  text-transform: none;
  border: 0 !important;
  line-height: 1;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #ffd05c;
}

.e-paste::before {
  content: "\e424";
  font-family: "e-icons";

  font-size: 15px;
  opacity: 0.78;
}

:host .li {
  padding: 0;
}

.e-item {
  padding-left: 0 !important;
}

.e-menu-url {
  border: 0 !important;
  font-weight: normal;
}

.myButton {
  display: inline;
  margin-right: 1%;
}

.myButton {
  box-shadow: 0px 1px 0px 0px #fff6af;
  background: linear-gradient(to bottom, #ffd05c 5%, #ffd05c 100%);
  background-color: #ffd05c;
  border-radius: 6px;
  border: 1px solid #ffaa22;
  display: inline-block;
  cursor: pointer;
  color: #333333;
  font-family: Arial;
  font-size: 12px;
  font-weight: bold;
  padding: 5px 16px;
  text-decoration: none;
  text-shadow: 0px 1px 0px #ffee66;
  margin: 5px;
}
.myButton:hover {
  background: linear-gradient(to bottom, #ffab23 5%, #ffec64 100%);
  background-color: #ffab23;
}
.myButton:active {
  position: relative;
  top: 1px;
}
</style>
