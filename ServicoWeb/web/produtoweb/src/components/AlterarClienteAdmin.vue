<template>
  <div>
    <div>
      <button @click="goBack()" class="myButton back">Home</button>
      <br />
      <br />
      <br />
      <h2>Alterar informação pessoal de um cliente</h2>
      <br />
      <button @click="obterClientes()" id="obterClientes" class="myButton">Clientes</button>
      <br />
      <div v-if="listaClientes">
        <div>
          <b v-for="p in listaClientes.clientes" v-bind:key="p">
            <p>
              {{p.email}}
              <input
                type="radio"
                name="encomenda"
                :value="p.email"
                v-model="emailAlterar"
              />
            </p>
            <br />
          </b>
        </div>
      </div>
      <br />
      <br />
      <!-- <input class="css-input" placeholder="email" v-model="email1" /> -->
      <input class="css-input" placeholder="Nome" id="nome" v-model="nome" />
      <br />
      <br />
      <input class="css-input" placeholder="Morada" v-model="morada" />
      <br />
      <br />
      <input class="css-input" placeholder="Nº de telemovel" v-model="telemovel" />
      <br />
      <br />
      <button
        @click="alterarCliente()"
        id="alterarCliente"
        class="myButton"
      >Alterar informações pessoais</button>
    </div>
    <div>
      <h1>-----------------------------------------------</h1>
      <h2>Alterar permissões dos clientes</h2>
      <div class="padding">
        <div>
          <span v-for="(item, i) in items" :key="i" style="padding: 5px">
            <p v-if="i == 0 ">Permissão de encomendas</p>
            <p v-if="i == 1 ">Permissão de informação de clientes</p>
            <toggle-button
              :value="item.value"
              :color="item.color"
              :width="80"
              :height="30"
              :font-size="17"
              :sync="true"
              :labels="{checked: 'Sim', unchecked: 'Não'}"
              :key="i"
              @change="alterarDefinicoes(i)"
            />
            <br />
            <br />
          </span>
          <button @click="confirmarDefinicoes()" class="myButton">Confirmar Alterações</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import ToggleButton from "vue-js-toggle-button";
Vue.use(ToggleButton);
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
      nomeAux: document.getElementById("nome"),
      json: "",
      listaClientes: [],
      emailAlterar: "",
      toggled: false,
      items: [
        { color: "#ffaa22", value: true },
        { color: "#ffaa22", value: true }
      ],
      hodor: false,
      teste: "",
      teste2: ""
    };
  },
  mounted() {
    Vue.axios
      .get("http://localhost:3000/api/clientes/permissao")
      .then(response => {
        this.teste = response.data;
        if (this.teste == true) {
          this.items[0].value = true;
        } else {
          this.items[0].value = false;
        }
      })
      .catch(error => {
        console.warn(error);
      });

    Vue.axios
      .get("http://localhost:3000/api/clientes/permissao2")
      .then(response => {
        this.teste2 = response.data;
        if (this.teste2 == true) {
          this.items[1].value = true;
        } else {
          this.items[1].value = false;
        }
      })
      .catch(error => {
        console.warn(error);
      });
  },
  methods: {
    alterarDefinicoes(i) {
      this.items[i].value = !this.items[i].value;
      console.log("value: " + this.items[i].value);
    },
    confirmarDefinicoes() {
      if (this.items[0].value == true) {
        this.teste = "true";
      } else {
        this.teste = "false";
      }
      if (this.items[1].value == true) {
        this.teste2 = "true";
      } else {
        this.teste2 = "false";
      }
      var base = '{"permissao": "' + this.teste + '"}';
      var base2 = '{"permissao": "' + this.teste2 + '"}';
      Vue.axios
        .post(
          "http://localhost:3000/api/clientes/alterarConfiguracao",
          JSON.parse(base)
        )
        .catch(error => {
          console.warn(error);
        });
      Vue.axios
        .post(
          "http://localhost:3000/api/clientes/alterarConfiguracao2",
          JSON.parse(base2)
        )
        .catch(error => {
          console.warn(error);
        });
    },
    alterarCliente() {
      if (this.emailAlterar.length > 0) {
        if (
          this.nome.length > 0 &&
          this.morada.length > 0 &&
          this.telemovel.length > 0
        ) {
          var base =
            '{"nome": "' +
            this.nome +
            '", "morada": "' +
            this.morada +
            '", "telemovel": ' +
            this.telemovel +
            ', "email": "' +
            this.emailAlterar +
            '"}';
          this.json = base;
          Vue.axios
            .put(
              "http://localhost:3000/api/clientes/alterarClienteAdmin",
              JSON.parse(base)
            )
            .then(response => {
              if (response.data.message == "Client updated!") {
                this.$alert("Cliente alterado com sucesso!");
                this.$router.push({
                  name: "home",
                  query: { redirect: "/home" }
                });
              }
            })
            .catch(error => {
              this.$alert("E-mail inexistente!");
              console.warn(error);
            });
          this.erroCheck = "Erro ao alterar o cliente!";
        } else {
          this.$alert("Todos os campos são obrigatórios!");
        }
      } else {
        this.$alert("Tem de selecionar email de um cliente!");
      }
    },
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    obterClientes() {
      Vue.axios
        .get("http://localhost:3000/api/clientes")
        .then(response => {
          this.listaClientes = response.data;
        })
        .catch(error => {
          this.$alert("Não existem clientes");
          console.warn(error);
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style src="../assets/css/alterarClienteStyle.css">
</style>
