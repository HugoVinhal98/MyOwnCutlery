<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <br />
    <h2>Alterar informação pessoal</h2>
    <br />
    <br />
    <br />
    <input class="css-input" placeholder="Nome" id="nome" v-model="nome" />
    <br />
    <br />
    <input class="css-input" placeholder="Morada" v-model="morada" />
    <br />
    <br />
    <input class="css-input" placeholder="Nº de telemovel" v-model="telemovel" />
    <br />
    <br />
    <input class="css-input" placeholder="email" v-model="email1" />
    <br />
    <br />
    <input class="css-input" type="password" placeholder="Password" v-model="password" />
    <br />
    <br />
    <button @click="alterarCliente()" id="alterarCliente" class="myButton">Alterar informações pessoais</button>
    <br />
    <br />
    <!-- <h2>{{json}}</h2> -->
    <br />
    <br />
  </div>
</template>

<script>
import Vue from "vue";
//import router from 'vue-router'
import { store } from "../router/store.js";



export default {
  name: "alterarCliente",
  data() {
    return {
    nome: "",
    morada: "",
    telemovel: "",
    password: "",
    erroCheck: "",
    email: store.state.accessToken,
    email1: "",
    nomeAux: document.getElementById("nome"),
    json: ""
    };
  },
  methods: {
    alterarCliente() {
    
        if(this.nome.length > 0 && this.morada.length > 0  && this.telemovel.length > 0 && this.password.length > 0  && this.email1.length > 0  ){
        var base =
          '{"nome": "' +
          this.nome +
          '", "morada": "' +
          this.morada +
          '", "telemovel": ' +
          this.telemovel +
          ', "email": "' +
          this.email +
          '", "email1": "' +
          this.email1 +
          '", "password": "' +
          this.password +
          '"}';
        this.json = base;
        Vue.axios
          .put("http://localhost:3000/api/clientes/alterarCliente", JSON.parse(base))
          .then(response => {
            if (response.data.message == "Client updated!") {
              this.$alert("Cliente alterado com sucesso!");
              this.$router.push({
                name: "home",
                query: { redirect: "/home" }
              });
            store.commit("setAccessToken", this.email1);
            }
          })
          .catch((error) => {
          this.$alert("e-mail existente!");
          console.warn(error);
        });  
        this.erroCheck = "Erro ao alterar o cliente!";
        }else{
        this.$alert(
        "Todos os campos são obrigatórios!"
        );
        }
    },
    goBack(){
      this.$router.push({ name: 'home', query: { redirect: '/home' } }); 
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style src="../assets/css/alterarClienteStyle.css">
</style>
