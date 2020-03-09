<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <h1>Master Data Fabrica</h1>
    <h2>Linha Producao</h2>
    <button @click="clearData()" type="reset" class="myButton2">Limpar dados</button>
    <br />
    <br />
    <br />

    <button @click="getLinhasProducao()" id="getLinhasProducao" class="myButton">Obter Linhas de Produção</button>
    <div v-if="lista">
      <ul>
        <li class="listaProducao" v-for="item in lista" v-bind:key="item">
          <p>Descricao: {{ item.descricao.descricao }}</p>
          <br />
          <hr />
        </li>
      </ul>
    </div>

    <button
      @click="PostLinhaProducao()"
      id="postLinhaProducao"
      class="myButton"
    >Criar Linha de Produção</button>
    <br />
    <input v-model="descricaoLP1" placeholder="Inserir descrição" />
    <br>

    <br />

    <button
      @click="PutLinhaProducaoMaquina()"
      id="putLinhaProducaoMaquina"
      class="myButton"
    >Inserir máquinas na linha de produção</button>
    <br />
    <input v-model="descricaoLP2" placeholder="Inserir descrição da LP" />
    <br />
    <p>Maquina:</p>
    <vue-numeric-input v-model="numMaquinas" placeholder="Máquinas:" :min="1" :max="10" :step="1"></vue-numeric-input>
    <div v-if="numMaquinas">
      <ul>
        <li v-for="n in numMaquinas" v-bind:key="n">
          <input v-model="descricao[n]" placeholder="Descrição da máquina">
          <input v-model="posicao[n]" placeholder="Posição da máquina" />
        </li>
      </ul>
    </div>

  </div>
</template>

<script>
import Vue from "vue";

export default {
  name: "linhaproducao",
  data() {
    return {
      descricao: [],
      numMaquinas: null,
      descricaoLP1: "",
      descricaoLP2: "",
      lista: [],
      posicao: []
    };
  },
  methods: {
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    clearData() {
      this.descricao = [];
      this.numMaquinas = null,
      this.descricaoLP1 = "",
      this.descricaoLP2 = "",
      this.lista = [],
      this.posicao = []
    },
    PostLinhaProducao() {
      Vue.axios
        .post("https://localhost:5003/api/linhaproducao", {
          descricao: {
            descricao: this.descricaoLP1
          }
        })
        .catch(error => {
          this.$alert(
            "Não é possivel criar uma linha de produção com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },

    getLinhasProducao() {
      Vue.axios
        .get("https://localhost:5003/api/linhaproducao")
        .then(response => {
          this.lista = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    },

    PutLinhaProducaoMaquina() {
      var desc = this.descricaoLP2;

      Vue.axios;
      var base = "[";
      var i;
      for (i = 1; i <= this.numMaquinas; i++) {
        if (i == this.numMaquinas) {
          base = base + '{"descricao": "' + this.descricao[i] + '", "posicao": "' + this.posicao[i] + '"}';
        } else {
          base = base + '{"descricao": "' + this.descricao[i] + '", "posicao": "' + this.posicao[i] + '"},';
        }
      }

      base = base + "]";
      this.json = JSON.parse(base);

      Vue.axios
        .put(
          "https://localhost:5003/api/linhaproducaomaquina/" + desc,
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel alterar com a informação disponibilizada!"
          );
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
.back{
  background: none;
  margin-left: 40px;
  float: left;
}
</style>