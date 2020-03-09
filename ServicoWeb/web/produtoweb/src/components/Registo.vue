<template>
  <div>
    <br />
    <br />
    <br />
    <input class="css-input" placeholder="Nome" v-model="nome" />
    <br />
    <br />
    <input class="css-input" placeholder="Morada" v-model="morada" />
    <br />
    <br />
    <input class="css-input" placeholder="Nº de telemovel" v-model="telemovel" />
    <br />
    <br />
    <input class="css-input" placeholder="Email" v-model="email" />
    <br />
    <br />
    <input class="css-input" type="password" placeholder="Password" v-model="password" />
    <br />
    <br />
    <div>
      <p>
        <input type="checkbox" class="check" id="myCheck" />Declaro que tenho mais de 18 anos, li e aceito os
        <a
          @click="getTermos()"
        >termos e condições de uso.</a>
      </p>
      <p class="error">{{erroCheck}}</p>
      <br />
      <br />
    </div>
    <button @click="criarUser()" class="myButton">Sign-up</button>
    <br />
    <br />
    <br />
    <br />
  </div>
</template>

<script>
import Vue from "vue";
import { store } from "../router/store.js";

//import router from 'vue-router'

export default {
  name: "registo",
  data() {
    return {
      nome: "",
      morada: "",
      telemovel: "",
      email: "",
      password: "",
      erroCheck: ""
    };
  },
  methods: {
validateEmail(email) 
{
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
},
    getTermos() {
      store.commit("setAccessToken", "termos");
      this.$router.push({ name: "termos", query: { redirect: "/home" } });
      store.commit("setAccessToken", "");
    },
    criarUser() {
      var checkBox = document.getElementById("myCheck");
      if(this.nome.length > 0 && this.morada.length > 0  && this.telemovel.length > 0 && this.password.length > 0  && this.email.length > 0  ){
      if(this.validateEmail(this.email)==true){
        if (checkBox.checked == true) {         
          var base =
            '{"nome": "' +
            this.nome +
            '", "morada": "' +
            this.morada +
            '", "telemovel": ' +
            this.telemovel +
            ', "email": "' +
            this.email +
            '", "password": "' +
            this.password +
            '"}';
          Vue.axios
            .post("http://localhost:3000/api/clientes", JSON.parse(base))
            .then(response => {
              if (response.data.message == "Cliente criado com sucesso!") {
                this.$alert("Cliente criado com sucesso!");
                this.$router.push({
                  name: "login",
                  query: { redirect: "/login" }
                });
              }
            });
          this.erroCheck = "Mail inválido!";
        } else {
          this.$alert(
            "Tem de aceitar os termos e condições para se conseguir registar!"
          );
        }       
      }else {
          this.$alert(
            "Mail Invalido!"
          );
        } 
    }else {
          this.$alert(
            "Todos os campos tem de ser preenchidos!"
          );
        } 
    }
  },
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
.error {
  color: #f24537;
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
  padding: 12px 100px;
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

a:hover {
  border: 0;
  text-decoration: underline;
}
</style>
