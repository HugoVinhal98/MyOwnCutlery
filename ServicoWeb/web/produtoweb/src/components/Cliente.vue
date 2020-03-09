<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <h1>Gestão de encomendas</h1>
    <h2>Clientes</h2>
    <button @click="getClientes()" id="getClientes" class="myButton">Obter clientes</button>
    <div v-if="lista">
      <ul>
        <li class="listaClientes" v-for="item in lista.clientes" v-bind:key="item">
          <b>{{item.nome}}</b>
          <!-- <br />
          <p>Morada: {{ item.morada }}</p>
          <br />
          <p>Telemovel: {{ item.telemovel }}</p>
          <p>email: {{ item.email }}</p>
          <p>password: {{ item.password }}</p>-->
          <hr />
        </li>
      </ul>
    </div>
    <br />
    <br />
  </div>
</template>

<script>
import Vue from "vue";

export default {
  name: "produto",
  data() {
    return {
      lista: ""
    };
  },
  methods: {
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    getClientes() {
      Vue.axios
        .get("http://localhost:3000/api/clientes")
        .then(response => {
          this.lista = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style src="../assets/css/clienteStyle.css"></style>
