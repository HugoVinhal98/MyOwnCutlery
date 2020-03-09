<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button><br><br>
    <h1>Master Data Fabrica</h1>
    <h2>Operação</h2>

    <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
    <br><br><br>

    <button @click="getOperacoes()" id="getOperacoes" class="myButton">Obter Operações</button>
    <div v-if="lista">
      <ul>
        <li class="listaOperacoes" v-for="item in lista" v-bind:key="item"> 
          <p>Operação: {{ item.nomeOperacao }}</p>
          <p>Tipo de Operação: {{ item.nomeTipoOp }}</p>
          <p>Duracao:</p>
          <p>
          <ul>
            <li>{{item.duracao.minutos}} minuto(s)</li>
            <li>{{item.duracao.segundos}} segundos(s)</li>
          </ul>
          </p>
          <br />
          <hr>
        </li>
      </ul>
    </div>

    <button @click="getTipoOperacoes()" id="getTipoOperacoes" class="myButton">Obter Tipos de Operação</button>
    <div v-if="listaTO">
      <ul>
        <li class="listaOperacoes" v-for="item in listaTO" v-bind:key="item"> 
          <p>Tipo Operação: {{ item.nome.nome }}</p>
          <p>Ferramenta: {{ item.ferramenta.descricao }}</p>
          <p>Tempo Setup: {{ item.tempoSetup.tempo }}</p>
          <br />
          <hr>
        </li>
      </ul>
    </div>

    <button @click="postOperacao()" id="postOperacao" class="myButton admin">Criar Operação</button>
    <br> 
    <br />
    <input v-model="nomeTipoOp" placeholder="Inserir nome de tipo de operacao" class="admin"/>
    <input v-model="nome" placeholder="Inserir nome da operacao" class="admin"/>
    <input v-model="minutos" placeholder="Inserir minutos" class="admin"/>
    <input v-model="segundos" placeholder="Inserir segundos" class="admin"/>

  </div>
</template>

<script>
import Vue from "vue";
import { store } from "../router/store.js";

export default {
  name: "operacao",
  data() {
    return {
      id: null,
      lista: [],
      listaTO: [],
      nomeTipoOp: "",
      minutos: "",
      segundos: "",
      nome: ""
    };
  },
  mounted() {
    if (store.state.accessToken !== 'admin') {
      document.getElementsByClassName("admin").forEach(e => e.style.display = "none")
    }
  },
  methods: {
    goBack(){
      this.$router.push({ name: 'home', query: { redirect: '/home' } }); 
    },
    clearData(){
      this.lista = [];
      this.listaTO = [];
      this.nomeTipoOp = '';
      this.minutos = '';
      this.segundos = '';
      this.nome = '';
    },
    getOperacoes() {
     Vue.axios
        .get("https://localhost:5003/api/operacao")
        .then(response => {
          this.lista = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    },
    postOperacao() {
      Vue.axios
        .post("https://localhost:5003/api/Operacao", {
          nomeTipoOp: this.nomeTipoOp,
          nomeOperacao: this.nome,
          duracao: {
            minutos: this.minutos,
            segundos: this.segundos
          }
        })
        .catch((error) => {
          this.$alert("Não é possivel criar operacão com a informação disponibilizada!");
          console.warn(error);
        });
    },
    getTipoOperacoes() {
      Vue.axios.get("https://localhost:5003/api/tipooperacao")
      .then(response => {
        this.listaTO = response.data;})
      .catch((error) => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });    
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home {
  margin-top: 70px;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.listaOperacoes:hover {
  color: #ffd05c;
}

hr{
  margin-top: 30px;
  border-color: #FFD05C;
  border-width: 5px;
  border-style: none;
  border-top-style: dotted;
  width: 5%;
}

p{
  display: inline-block;
  margin: 10px;
  width: 100%;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  font-weight: bold;
}

input{
  margin: 0 2px 0 2px;
}

/* Butoes */
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
  font-size: 15px;
  font-weight: bold;
  padding: 6px 24px;
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
	box-shadow:inset 0px 1px 0px 0px #f5978e;
	background:linear-gradient(to bottom, #f24537 5%, #c62d1f 100%);
	background-color:#f24537;
	border-radius:6px;
	border:1px solid #d02718;
	display:inline-block;
	cursor:pointer;
	color:#ffffff;
	font-family:Arial;
	font-size:15px;
	font-weight:bold;
	padding:6px 24px;
	text-decoration:none;
	text-shadow:0px 1px 0px #810e05;
}
.myButton2:hover {
	background:linear-gradient(to bottom, #c62d1f 5%, #f24537 100%);
	background-color:#c62d1f;
}
.myButton2:active {
	position:relative;
	top:1px;
}
.back{
  background: none;
  margin-left: 40px;
  float: left;
}
</style>