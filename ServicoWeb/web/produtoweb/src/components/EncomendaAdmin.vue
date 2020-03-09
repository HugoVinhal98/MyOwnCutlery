
<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <br />
    <br />
    <br />
    <h1>Gestão de encomendas</h1>
    <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
    <br />
    <br />

    <button @click="apresentarEncomendas()" id="apresentarEncomendas" class="myButton">Encomendas</button>
    <br />
    <div v-if="listaEncomendas">
      <div>
        <b v-for="p in listaEncomendas.encomendas" v-bind:key="p">
          <p>
            Encomenda: {{p.nrEncomenda}}
            <br />
            Produto: {{p.produto}}
            <br />
            Quantidade: {{p.quantidade}}
            <br />
            Estado: {{p.estado}}
            <br />
            Cliente: {{p.clienteEmail}}
            <br />
            <br />
            <input
              type="radio"
              name="encomenda"
              id="nrEncomenda"
              :value="p.nrEncomenda"
              v-model="nrEncomendaAlterar"
            />
            <br />
          </p>
          <br />
        </b>
      </div>
    </div>

    <div v-if="nrEncomendaAlterar">
      <button @click="apresentarTodosProdutos()" id="produtos" class="myButton3">Produtos</button>
      <div v-if="listaProdutos">
        <ul>
          <li class="listaProdutos" v-for="item in listaProdutos" v-bind:key="item">
            <p>Nome : {{ item.nome }}</p>
            <br />
            <input
              type="radio"
              id="nomeProduto"
              name="encomenda"
              :value="item.nome"
              v-model="nomeProdutoSelecionado
              "
            />
            <br />
            <br />
          </li>
        </ul>
      </div>
    </div>

    <div v-if="nrEncomendaAlterar">
      <button
        @click="alterarEncomendaSelecionada()"
        id="alterarEncomendaSelecionada"
        class="myButton3"
      >Alterar Encomenda Selecionada</button>
      <br />
      <br />
      <!-- <input v-model="produtoAlterar" placeholder="Produto" /> -->
      <input v-model="quantidadeAlterar" placeholder="Quantidade" />
      <input v-model="dataEnvio" placeholder="Data de Envio" />
      <input v-model="dataEntrega" placeholder="Data de Entrega" />
    </div>

    <br />

    <div v-if="nrEncomendaAlterar">
      <button
        @click="cancelarEncomendaSelecionada()"
        class="myButton3"
        id="cancelarEncomendaSelecionada"
      >Cancelar Encomenda Selecionada</button>
    </div>

    <br />

    <div v-if="nrEncomendaAlterar">
      <button
        @click="consultarEncomendaSelecionada()"
        class="myButton3"
        id="consultarEncomendaSelecionada"
      >Consultar Encomenda Selecionada</button>
    </div>

    <div v-if="encomendaID">
      <ul>
        <p>nrEncomenda: {{ encomendaID.nrEncomenda }}</p>
        <br />
        <p>Data de Envio: {{ encomendaID.dataEnvio }}</p>
        <br />
        <p>Data de Entrega: {{ encomendaID.dataEntrega }}</p>
        <br />
        <p>Estado: {{ encomendaID.estado }}</p>
        <br />
        <p>Produto: {{ encomendaID.produto }}</p>
        <br />
        <p>Solicitacao Cancelamento: {{ encomendaID.cancelamentoCliente }}</p>
        <br />
        <p>Solicitacao Alteracoes: {{ encomendaID.solicitacaoCliente }}</p>
        <br />
      </ul>
    </div>

    <br />
  </div>
</template>

<script>
import Vue from "vue";
//import { store } from "../router/store.js";
//import router from "vue-router";

export default {
  name: "encomenda",
  data() {
    return {
      nrEncomenda: "",
      json: "",
      encomendaID: "",
      produtoAlterar: "",
      nomeProdutoAlterado: "",
      quantidadeAlterar: null,
      nrEncomendaAlterar: "",
      estado: "",
      dataEnvio: null,
      dataEntrega: null,
      listaEncomendas: [],
      listaProdutos: []
    };
  },
  methods: {
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    clearData() {
      (this.nrEncomenda = ""),
        (this.json = ""),
        (this.encomendaID = ""),
        (this.nomeProdutoAlterado = ""),
        (this.produtoAlterar = ""),
        (this.quantidadeAlterar = null),
        (this.nrEncomendaAlterar = ""),
        (this.estado = ""),
        (this.quantidade = null),
        (this.dataEnvio = null),
        (this.dataEntrega = null),
        (this.listaEncomendas = [])((this.listaProdutos = []));
    },
    apresentarEncomendas() {
      Vue.axios
        .get("http://localhost:3000/api/encomendas")
        .then(response => {
          this.listaEncomendas = response.data;
        })
        .catch(error => {
          this.$alert("Erro");
          console.warn(error);
        });
    },
    apresentarTodosProdutos() {
      Vue.axios
        .get("https://localhost:5001/api/produto")
        .then(response => {
          this.listaProdutos = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    },
    cancelarEncomendaSelecionada() {
      var base = '{"nrEncomenda": "' + this.nrEncomendaAlterar + '"}';

      Vue.axios
        .put(
          "http://localhost:3000/api/encomendas/cancelarEncomenda/",
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel cancelar a Encomenda selecionada com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    alterarEncomendaSelecionada() {
      var base =
        '{"nrEncomenda": "' +
        this.nrEncomendaAlterar +
        '", "produto":{"nome": "' +
        this.nomeProdutoSelecionado +
        '"}, "quantidade": "' +
        this.quantidadeAlterar +
        '", "dataEnvio": "' +
        this.dataEnvio +
        '", "dataEntrega": "' +
        this.dataEntrega +
        '"}';
      Vue.axios
        .put(
          "http://localhost:3000/api/encomendas/alterarEncomenda/",
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel alterar a Encomenda selecionada com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    consultarEncomendaSelecionada() {
      var base = '{"nrEncomenda": "' + this.nrEncomendaAlterar + '"}';

      this.json = JSON.parse(base);
      Vue.axios
        .post(
          "http://localhost:3000/api/encomendas/EncomendaID/",
          JSON.parse(base)
        )
        .then(response => {
          this.encomendaID = response.data;
        })
        .catch(error => {
          this.$alert("Erro");
          console.warn(error);
        });
    }
  }
};
</script>


<style src="../assets/css/encomendaAdminStyle.css">
</style>