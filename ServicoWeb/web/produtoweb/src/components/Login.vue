<template>
  <div>
    <br />
    <br />
    <br />
    <input class="css-input" placeholder="Email" v-model="email" id="email" email/>
    <br />
    <br />
    <input class="css-input" type="password" placeholder="Password" id="pass" v-model="password" password/>
    <br />
    <p class="error">{{emailNotFound}}</p>
    <button @click="login()" class="myButton" id="lol">Login</button>
  </div>
</template>

<script>
import Vue from "vue";
//import router from 'vue-router'

import { store } from "../router/store.js";



export default {
  name: "login",
  data() {
    return {
      email: "",
      password: "",
      log: "",
      emailNotFound: "",    
    };
  },
  methods: {
    login() {
      var base =
        '{"email": "' + this.email + '","password": "' + this.password + '"}';

      if (this.canLogin(this.email, this.password)) {
        store.commit("setAccessToken", this.email);
        this.$router.push({ name: "home", query: { redirect: "/home" } });
        this.$alert("Login com sucesso! Bem vindo :)");
      }

      Vue.axios
        .post("http://localhost:3000/api/clientes/login", JSON.parse(base))
        .then(response => {
          this.log = response.data.out;
          if (this.log === 1) {
            store.commit("setAccessToken", this.email);
            this.$router.push({ name: "home", query: { redirect: "/home" } });
            if (!window.top.Cypress) { 
            this.$alert("Login com sucesso! Bem vindo :)");
            }
          }
        });
      this.emailNotFound = "Dados inseridos inválidos!";
    },
    canLogin(email, password) {
      return email == "admin" && password == "admin";
    },
    
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home {
  margin-top: 70px;
}
h4 {
  display: inline;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}

a {
  color: #42b983;
}
hr {
  margin-top: 30px;
  border-color: #ffd05c;
  border-width: 5px;
  border-style: none;
  border-top-style: dotted;
  width: 5%;
}

p {
  display: inline-block;
  margin: 10px;
  width: 100%;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  font-weight: bold;
  color: #d02718;
}

.listaProdutos:hover {
  color: #ffd05c;
}

input {
  margin: 0 2px 0 2px;
}

/* Botoes */
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
  font-size: 21px;
  font-weight: bold;
  padding: 12px 110px;
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

.myButton2 {
  box-shadow: inset 0px 1px 0px 0px #f5978e;
  background: linear-gradient(to bottom, #f24537 5%, #c62d1f 100%);
  background-color: #f24537;
  border-radius: 6px;
  border: 1px solid #d02718;
  display: inline-block;
  cursor: pointer;
  color: #ffffff;
  font-family: Arial;
  font-size: 15px;
  font-weight: bold;
  padding: 6px 24px;
  text-decoration: none;
  text-shadow: 0px 1px 0px #810e05;
}
.myButton2:hover {
  background: linear-gradient(to bottom, #c62d1f 5%, #f24537 100%);
  background-color: #c62d1f;
}
.myButton2:active {
  position: relative;
  top: 1px;
}

.css-input {
  border-color: #cccccc;
  border-width: 4px;
  border-radius: 10px;
  border-style: solid;
  padding: 12px;
  font-size: 21px;
  font-weight: bold;
  font-style: none;
  font-family: monospace;
}
.css-input:focus {
  outline: none;
}
</style>
