<template>
  <div>
  <button @click="goBack()" class="myButton back">Home</button><br><br>
      <h1>Master Data Producao</h1>
      <h2>Produtos</h2>
      <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
      <br><br><br>

  <button @click="getProdutos()" id="getProdutos" class="myButton">Obter Produtos</button>
    <div v-if="lista">
      <ul>
        <li class="listaProdutos" v-for="item in lista" v-bind:key="item">
           <p>Nome : {{ item.nome }}</p> <br>
           <p>Descrição: {{ item.descricao }}</p> <br>
           <p>Plano de Fabrico: {{ item.planoFabrico }}</p> <br>
        </li>
      </ul>
    </div>

    <button @click="getProdutoByNome()" id="getProdutoByNome" class="myButton">Obter Produto Por Nome</button>
    <br>
      <input v-model="nomeProduto" placeholder="Inserir o Nome">
      <div v-if="produto">
        <p>Nome : {{ produto.nome }}</p> <br>
        <p>Descrição: {{ produto.descricao }}</p> <br>
        <p>Plano de Fabrico: {{ produto.planoFabrico }}</p> <br>
        <p>Lista de Operações:</p> <br>
        <ul>
          <li v-for="op in planoFabrico.listaOperacoes" v-bind:key="op">
            {{op}}
          </li>
        </ul>
      </div>
    <br><br>

    <button @click="getPlanoFabrico()" id="getPlanoFabrico" class="myButton">Obter Plano de Fabrico de Produto</button> 
    <br>
    <input v-model="nomeProduto3" placeholder="Inserir o nome do produto">
    <div v-if="produto2">
        <p>Plano de Fabrico: {{ produto2.planoFabrico }}</p> <br>
        <p>Lista de Operações:</p> <br>
        <ul>
          <li v-for="op in planoFabrico.listaOperacoes" v-bind:key="op">
            {{op}}
          </li>
        </ul>
      </div>
    <br><br>

    <button @click="postProduto()" id="postProduto" class="myButton admin">Criar Produto</button>  
    <br>
    <input v-model="nomeProduto2" placeholder="Nome do Produto" class="admin">
    <input v-model="descricaoProduto" placeholder="Descrição do Produto" class="admin">
    <input v-model="nomePlanoFabrico2" placeholder="Nome do Plano de Fabrico" class="admin">
    <br><br>
  </div>
</template>

<script>
import Vue from 'vue'
import { store } from "../router/store.js";

export default {
  name: 'produto',
  data(){
    return{
      nomePlanoFabrico: '',
      nomePlanoFabrico2: '',
      produto: '',
      produto2: '',
      planoFabrico: '',
      planoFabrico1: '',
      lista: [],
      nomeProduto: '',
      nomeProduto2: '',
      nomeProduto3: '',
      descricaoProduto: '',
      json: '',
      pf: '',
      pf2: ''
    }
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
      this.nomePlanoFabrico = '',
      this.nomePlanoFabrico2 = '',
      this.produto = '',
      this.produto2 = '',
      this.planoFabrico = '',
      this.planoFabrico1 = '',
      this.lista = [],
      this.nomeProduto = '',
      this.nomeProduto2 = '',
      this.nomeProduto3 = '',
      this.descricaoProduto = '',
      this.json = '',
      this.pf = '',
      this.pf2 = ''
    },
    getProdutos(){
      Vue.axios
        .get('https://localhost:5001/api/produto')
        .then((response) => {this.lista = response.data})
        .catch((error) => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        })
    },
    getProdutoByNome(){
      this.produto = '';
      var nome = this.nomeProduto;

      Vue.axios
        .get('https://localhost:5001/api/produto/' + nome)
        .then((response) => {
          this.produto = response.data
          this.pf = this.produto.planoFabrico;
          Vue.axios
          .get('https://localhost:5001/api/PlanoFabrico/' + this.pf)
          .then((response) => {this.planoFabrico = response.data})  
          .catch((error) => {
          this.$alert("Plano fabrico com nome " + this.pf + " não encontrado!");
          console.warn(error);
        })
        })  
        .catch((error) => {
          this.$alert("Produto com nome " + nome + " não encontrado!");
          console.warn(error);
        })
    },
    getPlanoFabrico(){
      this.produto2 = '';
      var nome = this.nomeProduto3;

      Vue.axios
        .get('https://localhost:5001/api/produto/' + nome)
        .then((response) => {
          this.produto2 = response.data
          this.pf2 = this.produto2.planoFabrico;
          Vue.axios
          .get('https://localhost:5001/api/PlanoFabrico/' + this.pf2)
          .then((response) => {this.planoFabrico = response.data})  
          .catch((error) => {
          this.$alert("Plano fabrico com nome " + this.pf2 + " não encontrado!");
          console.warn(error);
        })
        })  
        .catch((error) => {
          this.$alert("Produto com nome " + nome + " não encontrado!");
          console.warn(error);
        })
    },
    postProduto(){
      var base = '{"nome":{"nome": "' + this.nomeProduto2 + '"}, "descricao":{"descricao": "' + this.descricaoProduto + '"}, "planoFabrico":{"nome": "' + this.nomePlanoFabrico2 + '"}}';
      this.json = base;   
      Vue.axios
        .post('https://localhost:5001/api/produto', JSON.parse(base))
    }
}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home{
  margin-top: 70px;
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

.listaProdutos:hover{
  color: #FFD05C;
}

input{
  margin: 0 2px 0 2px;
}


/* Botoes */
.myButton {
	box-shadow: 0px 1px 0px 0px #fff6af;
	background:linear-gradient(to bottom, #FFD05C 5%, #FFD05C 100%);
	background-color:#FFD05C;
	border-radius:6px;
	border:1px solid #ffaa22;
	display:inline-block;
	cursor:pointer;
	color:#333333;
	font-family:Arial;
	font-size:15px;
	font-weight:bold;
	padding:6px 24px;
	text-decoration:none;
	text-shadow:0px 1px 0px #ffee66;
  margin: 5px;
}
.myButton:hover {
	background:linear-gradient(to bottom, #ffab23 5%, #ffec64 100%);
	background-color:#ffab23;
}
.myButton:active {
	position:relative;
	top:1px;
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
