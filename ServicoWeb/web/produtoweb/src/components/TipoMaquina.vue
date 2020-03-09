<template>
  <div>

    <button @click="goBack()" class="myButton back">Home</button><br><br>
    <h1>Master Data Fabrica</h1>
    <h2>Tipo de Maquina</h2>

    <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
    <br><br><br>

    <button
      @click="GetOperacoesByDescricaoTipoMaquina()"
      id="GetOperacoesByDescricaoTipoMaquina"
      class="myButton"
    >Consultar operações de tipo de maquina</button>
    <br />
    <input v-model="descricaoTipoMaquinaOperacao" placeholder="Inserir descricao TipoMaquina" />
    <div v-if="lista">
      <ul>
        <li class="listaOperacoesTipoMaquina" v-for="item in lista" v-bind:key="item">
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

    <button @click="AlterarOperacoesTipoMaquina()"  id="AlterarOperacoesTipoMaquina" class="myButton admin">Alterar operações de tipo de maquina</button>
    <br />
    <input v-model="descricaoTipoMaquinaOperacao1" placeholder="Inserir descricao TipoMaquina" class="admin"/>
    <br />
    <p class="admin">Operações:</p>
    <vue-numeric-input  v-model="numOperacoes" placeholder="Operações" :min="1" :max="10" :step="1" class="admin"></vue-numeric-input>
    <div v-if="numOperacoes">
      <ul>
        <li v-for="n in numOperacoes" v-bind:key="n">
          <input v-model="nomeOperacao[n]" placeholder="Nome da operacao">
        </li>
      </ul>
    </div>

    <br>
    <br>
    <button @click="getTipoMaquinaByDescricao()" id="getTipoMaquinaByDescricao" class="myButton">Obter Tipo Máquina</button>
    <br />
    <input v-model="descricaoTipoMaquina" placeholder="Inserir descricao" />
    <div v-if="operacao">
      <p>Descricao: {{ operacao.descricao }}</p>
      <br />
    </div>
    <br />
    <br>

    <button @click="PostTipoMaquina()" id="postTipoMaquina" class="myButton admin">Criar Tipo Máquina</button>
    <br />
    <input v-model="descricaoTipoMaquina2" placeholder="Inserir descricao" class="admin"/>

  </div>
</template>

<script>
import Vue from 'vue'
import VueNumericInput from 'vue-numeric-input'
import { store } from "../router/store.js";

export default {
  components: {
    VueNumericInput
  },
  name: 'operacao',
  data(){
    return{
      descricaoTipoMaquinaOperacao: null,
      descricaoTipoMaquinaOperacao1: null,
      descricaoTipoMaquina: null,
      descricaoTipoMaquina2: null,
      lista: [],
      numOperacoes: null,
      descricao: '',
      nomeOperacao: [],
      operacao: null
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
      this.descricaoTipoMaquinaOperacao = '';
      this.descricaoTipoMaquinaOperacao1 = '';
      this.descricaoTipoMaquina = null,
      this.descricaoTipoMaquina2 = null,
      this.lista = [];
      this.numOperacoes = null,
      this.descricao = '';
      this.nomeOperacao = [];
      this.operacao = null; 
    },
    GetOperacoesByDescricaoTipoMaquina(){
    var desc = this.descricaoTipoMaquinaOperacao;

      Vue.axios
        .get('https://localhost:5003/api/tiposMaquinaOperacao/' + desc)
        .then((response) => {this.lista = response.data})
        .catch((error) => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        })
    },
    AlterarOperacoesTipoMaquina(){
     var desc = this.descricaoTipoMaquinaOperacao1;

      Vue.axios
        var base = '[';
        var i;
        for(i=1;i<=this.numOperacoes;i++){
          if(i == this.numOperacoes){
            base = base + '{"nomeOperacao": "' + this.nomeOperacao[i] + '"}';
          }else{
            base = base + '{"nomeOperacao": "' + this.nomeOperacao[i] + '"},';
            }
        }
        
        base = base + ']';
        
        Vue.axios
        .put('https://localhost:5003/api/tiposmaquinaoperacao/' + desc, JSON.parse(base))
        .catch((error) => {
          this.$alert("Não é possivel alterar com a informação disponibilizada!");
          console.warn(error);
        })
  },
  getTipoMaquinaByDescricao() {

      var desc = this.descricaoTipoMaquina;

      Vue.axios
        .get("https://localhost:5003/api/tipomaquina/" + desc)
        .then((response) => {
          this.operacao = response.data
        })
        .catch(error => {
          this.$alert("TipoMaquina com descricao " + desc + " não encontrado!");
          console.warn(error);
        });
    },
    PostTipoMaquina() {
      Vue.axios
        .post("https://localhost:5003/api/tipomaquina", {
          descricao: {
            descricao: this.descricaoTipoMaquina2
          }
        })
        .catch((error) => {
          this.$alert("Não é possivel criar tipo de maquina com a informação disponibilizada!");
          console.warn(error);
        });
    }
}
}
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
.listaOperacoesTipoMaquina:hover {
  color: #ffd05c;
}
p{
  display: inline-block;
  margin: 10px;
  width: 100%;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  font-weight: bold;
}
hr{
  margin-top: 30px;
  border-color: #FFD05C;
  border-width: 5px;
  border-style: none;
  border-top-style: dotted;
  width: 5%;
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
