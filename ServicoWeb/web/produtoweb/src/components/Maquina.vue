<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <h1>Master Data Fabrica</h1>
    <h2>Máquina</h2>

    <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
    <br />
    <br />
    <br />

    <button @click="getMaquinas()" id="getMaquinas" class="myButton">Obter Máquinas</button>
    <div v-if="lista">
      <ul>
        <li class="listaMaquinas" v-for="item in lista" v-bind:key="item">
          <p>Descricao: {{ item.descricao }}</p>
          <br />
          <p>Marca: {{ item.marca }}</p>
          <br />
          <p>Modelo: {{ item.modelo }}</p>
          <br />
          <p>TipoMaquina: {{ item.descTipoMaquina }}</p>
          <br />
          <p>Ativa: {{ item.ativa }}</p>
          <br />
          <br />
          <hr />
        </li>
      </ul>
    </div>

    <button
      @click="getMaquinaByDescricao()"
      id="getMaquinaByDescricao"
      class="myButton"
    >Obter Máquina Por Descrição</button>
    <br />
    <input v-model="descricaoMaquina" placeholder="Inserir a descrição" />
    <div v-if="maquina">
      <p>Descricao: {{ maquina.descricao }}</p>
      <br />
      <p>Marca: {{ maquina.marca}}</p>
      <br />
      <p>Modelo: {{ maquina.modelo }}</p>
      <br />
      <p>TipoMaquina: {{ maquina.descTipoMaquina }}</p>
      <br />
    </div>
    <br />
    <br />

    <button
      @click="GetMaquinasTipoMaquina()"
      id="getMaquinasTipoMaquina"
      class="myButton"
    >Obter Máquinas de um Tipo de Máquina</button>
    <br />
    <input v-model="descricaoTipoMaquina" placeholder="Inserir a descricao do TM" />
    <div v-if="listaTP">
      <ul>
        <li class="listaMaquinas" v-for="item in listaTP" v-bind:key="item">
          <p>Descricao: {{ item.descricao }}</p>
          <br />
          <p>Marca: {{ item.marca }}</p>
          <br />
          <p>Modelo: {{ item.modelo }}</p>
          <br />
          <p>TipoMaquina: {{ item.descTipoMaquina }}</p>
          <br />
          <br />
          <hr />
        </li>
      </ul>
    </div>
    <br />
    <br />

    <button @click="postMaquina()" id="postMaquina" class="myButton admin">Criar Máquina</button>
    <br />
    <input v-model="descricao" placeholder="Descrição da Máquina" class="admin" />
    <input v-model="marca" placeholder="Marca" class="admin" />
    <input v-model="modelo" placeholder="Modelo" class="admin" />
    <input v-model="tipoMaquina" placeholder="Tipo de Máquina" class="admin" />
    <br />
    <br />

    <button
      @click="putTipoMaquinaInMaquina()"
      id="putTipoMaquinaInMaquina"
      class="myButton admin"
    >Alterar Tipo Máquina de Máquina</button>
    <br />
    <input v-model="descricaoMaquinaAlterar" placeholder="Máquina a alterar" class="admin" />
    <input v-model="descricaoTipoMaquinaAlterar" placeholder="Novo Tipo Máquina" class="admin" />
    <br />
    <br />
    <button
      @click="putMaquinaAtivada()"
      id="putMaquinaAtivada"
      class="myButton admin"
    >Ativar/Desativar máquina</button>
    <input v-model="descricaoMaquinaAtivada" placeholder="Maquina a ativar/desativar" class="admin" />
  </div>
</template>

<script>
import Vue from "vue";
import { store } from "../router/store.js";

export default {
  name: "maquina",
  data() {
    return {
      lista: [],
      descricaoMaquina: "",
      maquina: "",
      descricao: "",
      marca: "",
      modelo: "",
      tipoMaquina: "",
      descTipoMaquina: "",
      listaTP: "",
      descricaoMaquinaAlterar: "",
      descricaoTipoMaquinaAlterar: "",
      descricaoMaquinaAtivada: ""
    };
  },
  mounted() {
    if (store.state.accessToken !== "admin") {
      document
        .getElementsByClassName("admin")
        .forEach(e => (e.style.display = "none"));
    }
  },
  methods: {
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    clearData() {
      this.lista = [];
      this.descricaoMaquina = "";
      this.maquina = "";
      this.descricao = "";
      this.marca = "";
      this.modelo = "";
      this.tipoMaquina = "";
      this.descTipoMaquina = "";
      this.listaTP = "";
      this.descricaoMaquinaAlterar = "";
      this.descricaoTipoMaquinaAlterar = "";
      this.descricaoMaquinaAtivada = "";
    },
    getMaquinas() {
      Vue.axios
        .get("https://localhost:5003/api/Maquina")
        .then(response => {
          this.lista = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    },

    getMaquinaByDescricao() {
      this.maquina = "";
      var desc = this.descricaoMaquina;

      Vue.axios
        .get("https://localhost:5003/api/maquina/" + desc)
        .then(response => {
          this.maquina = response.data;
        })
        .catch(error => {
          this.$alert("Maquina com descrição" + desc + " não encontrada!");
          console.warn(error);
        });
    },
    putTipoMaquinaInMaquina() {
      var descM = this.descricaoMaquinaAlterar;

      var base = '{"descricao": "' + this.descricaoTipoMaquinaAlterar + '"}';

      Vue.axios
        .put(
          "https://localhost:5003/api/maquina/alterarTM/" + descM,
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel alterar com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    putMaquinaAtivada() {
      Vue.axios
        .put(
          "https://localhost:5003/api/maquina/alterarAtivada/" +
            this.descricaoMaquinaAtivada
        )
        .catch(error => {
          this.$alert(
            "Não é possivel alterar com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },

    postMaquina() {
      Vue.axios
        .post("https://localhost:5003/api/maquina", {
          descricao: this.descricao,
          marca: this.marca,
          modelo: this.modelo,
          descTipoMaquina: this.tipoMaquina
        })
        .catch(error => {
          this.$alert(
            "Não é possivel criar máquina com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    GetMaquinasTipoMaquina() {
      var desc = this.descricaoTipoMaquina;

      Vue.axios
        .get("https://localhost:5003/api/maquina/maquinasDeTipoMaquina/" + desc)
        .then(response => {
          this.listaTP = response.data;
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

input {
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
.back {
  background: none;
  margin-left: 40px;
  float: left;
}
</style>