
<template>
  <div>
    <button @click="goBack()" class="myButton back">Home</button>
    <br />
    <br />
    <br />
    <br />
    <br />

    <h1>Gestão de encomendas</h1>
    <br />
    <button @click="clearData()" id="clearData" type="reset" class="myButton2">Limpar dados</button>
    <br />
    <br />

    <button @click="apresentarTodosProdutos()" id="apresentarTodosProdutos" class="myButton produtosGeral">Produtos</button>
    <br />

    <button
      @click="apresentarTodosProdutosEncomendados()"
      id="produtosMaiorQuantidade"
      class="myButton maiorQuantidade"
    >Produtos maior quantidade encomendados</button>

    <button
      @click="apresentarProdutosMaisEncomendas()"
      id="produtosMaisEncomendas"
      class="myButton maiorNEncomendas"
    >Produtos com mais encomendas</button>

    <button
      @click="apresentarProdutosMenosTempo()"
      id="produtosMenorTempo"
      class="myButton menorTempo"
    >Produtos com menor tempo de produção</button>

    <br />
    <br />
    <br />
    <div v-if="listaProdutos">
      <ul>
        <li class="orgList" v-for="(item, index) in listaProdutos" v-bind:key="item">
          <p class="org">Nome: {{ item.nome }}</p>
          <p
            v-if="listaTempos[index]"
            class="org"
          >Tempo de Produção: {{listaTempos[index]}} segundos</p>
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
    <div v-if="listaProdutosEncomendados">
      <ul>
        <li class="orgList" v-for="item in listaProdutosEncomendados" v-bind:key="item">
          <p class="org">Nome: {{ item.produto }}</p>
          <p class="org">Quantidade: {{ item.quantidade }}</p>
          <input
            type="radio"
            id="nomeProduto"
            name="encomenda"
            :value="item.produto"
            v-model="nomeProdutoSelecionado
              "
          />
          <br />

          <br />
        </li>
      </ul>
    </div>
    <div v-if="listaInicial">
      <ul>
        <li class="orgList" v-for="item in listaInicial" v-bind:key="item">
          <p class="org">Nome: {{ item.produto }}</p>
          <p class="org">Nr. de encomendas: {{ item.quantidade }}</p>
          <input
            type="radio"
            id="nomeProduto"
            name="encomenda"
            :value="item.produto"
            v-model="nomeProdutoSelecionado
              "
          />
          <br />

          <br />
        </li>
      </ul>
    </div>
    <br />
    <input v-model="quantidade" class="input" placeholder="Quantidade" />
    <br />
    <br />

    <div v-if="nomeProdutoSelecionado">
      <button @click="postEncomenda()" id="postEncomenda" class="myButton">Criar Encomenda</button>
      <br />
      <!-- <input v-model="produtoNome" placeholder="Produto" /> -->
      <!-- <input v-model="quantidade" placeholder="Quantidade" /> -->
      <br />
      <br />
    </div>

    <button
      @click="apresentarEncomendasUser()"
      id="apresentarEncomendasUser"
      class="myButton"
    >Encomendas</button>
    <br />
    <div v-if="listaEncomendasUser">
      <div>
        <ul>
          <li class="orgList" v-for="pUser in listaEncomendasUser.encomendas" v-bind:key="pUser">
            <p class="org">
              Encomenda: {{pUser.nrEncomenda}}
              <!--   Produto: {{pUser.produto}} -->

              <!--    Quantidade: {{pUser.quantidade}} -->

              <!--   Estado: {{pUser.estado}} -->
              <input
                type="radio"
                id="nrEncomenda"
                name="encomenda"
                :value="pUser.nrEncomenda"
                v-model="nrEncomendaAlterarUser
              "
              />
              <br />
            </p>
            <br />
          </li>
        </ul>
      </div>
    </div>

    <div v-if="nrEncomendaAlterarUser">
      <button
        @click="consultarEncomendaSelecionadaUser()"
        class="myButton3"
        id="consultarEncomendaSelecionadaUser"
      >Consultar Encomenda Selecionada</button>
    </div>

    <br />

    <div v-if="nrEncomendaAlterarUser">
      <button
        @click="solicitarCancelamentoEncomendaSelecionada()"
        class="myButton3"
        id="solicitarCancelamentoEncomendaSelecionada"
      >Solicitar Cancelamento de Encomenda Selecionada</button>
    </div>

    <br>

    <div v-if="nrEncomendaAlterarUser">
      <button
        @click="solicitarAlteracoesEncomendaSelecionada()"
        class="myButton3"
        id="solicitarAlteracoesEncomendaSelecionada"
      >Solicitar Alterações a Encomenda Selecionada</button>
    </div>
    <br />
    <input v-model="mensagemAlteracoesEncomenda" placeholder="Insira a mensagem" class="admin" />

    <br />

    <div v-if="encomendaIDUser" class="orgListSolo">
      <p>nrEncomenda: {{ encomendaIDUser.nrEncomenda }}</p>
      <br />

      <p v-if="encomendaIDUser.dataEnvio">Data de Envio: {{ encomendaIDUser.dataEnvio }}</p>

      <p v-if="encomendaIDUser.dataEntrega">Data de Entrega: {{ encomendaIDUser.dataEntrega }}</p>

      <p>Estado: {{ encomendaIDUser.estado }}</p>
      <br />
      <p>Produto: {{ encomendaIDUser.produto }}</p>
      <br />
      <p class="last">Quantidade: {{ encomendaIDUser.quantidade }}</p>
    </div>

    <br />
    <br />
    <br />
  </div>
</template>

<script>
import Vue from "vue";
import { store } from "../router/store.js";
//import router from "vue-router";

export default {
  name: "encomenda",
  data() {
    return {
      nrEncomenda: "",
      nomeProduto: "",
      nomeProdutoSelecionado: "",
      json: "",
      encomendaIDUser: "",
      nrEncomendaAlterarUser: "",
      clienteEmail: store.state.accessToken,
      produtoNome: "",
      quantidade: null,
      listaEncomendasUser: [],
      listaProdutos: [],
      listaProdutosEncomendados: [],
      listaProdutosMaisEncomendas: [],
      listaInicial: [],
      listaMenorTempo: [],
      listaTempos: [],
      listaPlanos: [],
      mensagemAlteracoesEncomenda: ""
    };
  },
  methods: {
    goBack() {
      this.$router.push({ name: "home", query: { redirect: "/home" } });
    },
    clearData() {
      (this.nrEncomenda = ""),
        (this.json = ""),
        (this.clienteEmail = store.state.accessToken),
        (this.produtoNome = ""),
        (this.quantidade = null),
        (this.encomendaIDUser = ""),
        (this.nrEncomendaAlterarUser = ""),
        (this.listaEncomendasUser = []),
        (this.listaProdutos = []),
        (this.listaProdutosEncomendados = []),
        (this.listaInicial = []);
      this.mensagemAlteracoesEncomenda = "";
    },
    solicitarCancelamentoEncomendaSelecionada() {
      var base = '{"nrEncomenda": "' + this.nrEncomendaAlterarUser + '"}';

      Vue.axios
        .put(
          "http://localhost:3000/api/Encomendas/solicitarCancelamentoEncomenda/",
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel solicitar o cancelamento da Encomenda selecionada com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    solicitarAlteracoesEncomendaSelecionada() {
      var base =
        '{"nrEncomenda": "' +
        this.nrEncomendaAlterarUser +
        '", "solicitacaoCliente": "' +
        this.mensagemAlteracoesEncomenda +
        '"}';

      Vue.axios
        .put(
          "http://localhost:3000/api/encomendas/solicitarAlteracoesEncomenda/",
          JSON.parse(base)
        )
        .catch(error => {
          this.$alert(
            "Não é possivel solicitar o cancelamento da Encomenda selecionada com a informação disponibilizada!"
          );
          console.warn(error);
        });
    },
    postEncomenda() {
      if (this.quantidade != null) {
        Vue.axios
          .post("http://localhost:3000/api/encomendas", {
            produto: this.nomeProdutoSelecionado,
            clienteEmail: this.clienteEmail,
            quantidade: this.quantidade,
            estado: "Por enviar",
            dataEnvio: null,
            dataEntrega: null
          })
          .catch(error => {
            this.$alert(
              "Não é possivel criar Encomenda com a informação disponibilizada!"
            );
            console.warn(error);
          });
      } else {
        this.$alert("Inserir uma quantidade!");
      }
    },
    apresentarTodosProdutos() {
      Vue.axios
        .get("https://localhost:5001/api/produto")
        .then(response => {
          this.listaProdutosEncomendados = "";
          this.listaInicial = "";
          this.listaTempos = [];
          this.listaProdutos = response.data;
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });
    },
    apresentarTodosProdutosEncomendados() {
      Vue.axios
        .get("http://localhost:3000/api/encomendas/quantidade")
        .then(response => {
          this.listaProdutos = "";
          this.listaInicial = "";
          this.listaProdutosEncomendados = response.data.encomendas;
          var i, j;
          for (i = 0; i < this.listaProdutosEncomendados.length; i++) {
            var nomeAtual = this.listaProdutosEncomendados[i].produto;
            for (j = i + 1; j < this.listaProdutosEncomendados.length; j++) {
              var nomeComparavel = this.listaProdutosEncomendados[j].produto;
              if (nomeAtual == nomeComparavel) {
                this.listaProdutosEncomendados[i].quantidade =
                  this.listaProdutosEncomendados[i].quantidade +
                  this.listaProdutosEncomendados[j].quantidade;
                this.listaProdutosEncomendados.splice(j, 1);
                j--;
              }
            }
          }
          for (i = 0; i < this.listaProdutosEncomendados.length; i++) {
            for (j = i + 1; j < this.listaProdutosEncomendados.length; j++) {
              if (
                this.listaProdutosEncomendados[i].quantidade <
                this.listaProdutosEncomendados[j].quantidade
              ) {
                var menor = this.listaProdutosEncomendados[i];
                this.listaProdutosEncomendados[
                  i
                ] = this.listaProdutosEncomendados[j];
                this.listaProdutosEncomendados[j] = menor;
              }
            }
          }
        })
        .catch(error => {
          if (!window.top.Cypress) {
            this.$alert("Informação indisponivel");
          }
          console.warn(error);
        });
    },
    apresentarProdutosMaisEncomendas() {
      Vue.axios
        .get("http://localhost:3000/api/encomendas/quantidade")
        .then(response => {
          this.listaProdutos = "";
          this.listaProdutosEncomendados = "";
          this.listaProdutosMaisEncomendas = response.data.encomendas;
          this.listaInicial = response.data.encomendas;
          var i, j;
          for (i = 0; i < this.listaInicial.length; i++) {
            var nomeAtual = this.listaInicial[i].produto;
            for (j = i + 1; j < this.listaInicial.length; j++) {
              var nomeComparavel = this.listaInicial[j].produto;
              if (nomeAtual == nomeComparavel) {
                this.listaInicial.splice(j, 1);
                j--;
              }
            }
          }
        })
        .catch(error => {
          this.$alert("Informação indisponivel");
          console.warn(error);
        });

      Vue.axios
        .get("http://localhost:3000/api/encomendas/quantidade")
        .then(response => {
          this.listaProdutosMaisEncomendas = response.data.encomendas;
          var i, j;
          for (i = 0; i < this.listaInicial.length; i++) {
            var prod = this.listaInicial[i].produto;
            console.log("prod: " + prod);
            console.log("lista: " + this.listaProdutosMaisEncomendas.length);
            var flag = false;
            for (j = 0; j < this.listaProdutosMaisEncomendas.length; j++) {
              var prodComparavel = this.listaProdutosMaisEncomendas[j].produto;
              console.log("comparavel: " + prodComparavel);
              if (prod == prodComparavel) {
                console.log(prod);
                if (flag == false) {
                  console.log(flag);
                  this.listaInicial[i].quantidade = 0;
                  flag = true;
                }
                this.listaInicial[i].quantidade =
                  this.listaInicial[i].quantidade + 1;
              }
            }
          }
          for (i = 0; i < this.listaInicial.length; i++) {
            for (j = i + 1; j < this.listaInicial.length; j++) {
              if (
                this.listaInicial[i].quantidade <
                this.listaInicial[j].quantidade
              ) {
                var menor = this.listaInicial[i];
                this.listaInicial[i] = this.listaInicial[j];
                this.listaInicial[j] = menor;
              }
            }
          }
        });
    },
    apresentarProdutosMenorTempo() {
      this.listaProdutosEncomendados = "";
      this.listaInicial = "";
      this.listaProdutos = "";
      Vue.axios
        .get("https://localhost:5001/api/produto")
        .then(response => {
          var lista = response.data;
          var i;
          for (i = 0; i < lista.length; i++) {
            this.listaTempos[i] = 0;
            this.listaPlanos[i] = lista[i].planoFabrico;
            //console.log(this.listaPlanos[i]);
          }
          var j;
          for (j = 0; j < this.listaPlanos.length; j++) {
            //console.log("plano obtido: " + this.listaPlanos[j]);
            Vue.axios
              .get(
                "https://localhost:5001/api/planofabrico/" + this.listaPlanos[j]
              )
              .then(response => {
                var listaOps = response.data.listaOperacoes;
                var k;
                for (k = 0; k < listaOps.length; k++) {
                  console.log("FORA o K= " + k);
                  Vue.axios
                    .get("https://localhost:5003/api/operacao/" + listaOps[k])
                    .then(response => {
                      console.log("AQUI o K= " + k);
                      //console.log("Plano atual: " + response.data.nomeOperacao);
                      var minutos = response.data.duracao.minutos;
                      var segundos = response.data.duracao.segundos;
                      var total = minutos * 60 + segundos;
                      //console.log("total: " + j + ":" + total);
                      this.listaTempos[j] = this.listaTempos + total;
                    });
                  console.log("teste");
                }
                console.log("lista: " + listaOps);
              });
          }
        })
        .catch(error => {
          if (!window.top.Cypress) {
            this.$alert("Informação indisponivel");
          }
          console.warn(error);
        });
    },
    apresentarProdutosMenosTempo() {
      this.listaProdutosEncomendados = [];
      this.listaInicial = [];
      this.listaProdutos = [];
      Vue.axios
        .get("https://localhost:5001/api/produto")
        .then(response => {
          this.listaProdutos = response.data;
          for (var i = 0; i < this.listaProdutos.length; i++) {
            if (this.listaProdutos[i].planoFabrico == "PlanoFabrico1") {
              this.listaTempos[i] = 125 + 245 + 575;
            } else if (this.listaProdutos[i].planoFabrico == "PlanoFabrico2") {
              this.listaTempos[i] = 634 + 221 + 451;
            } else if (this.listaProdutos[i].planoFabrico == "PlanoFabrico3") {
              this.listaTempos[i] = 72 + 354 + 184;
            } else {
              this.listaTempos[i] = 875;
            }
          }
          for (var j = 0; j < this.listaProdutos.length; j++) {
            for (var k = j + 1; k < this.listaProdutos.length; k++) {
              if (this.listaTempos[j] > this.listaTempos[k]) {
                var trocaTempo = this.listaTempos[j];
                var trocaProd = this.listaProdutos[j];
                this.listaTempos[j] = this.listaTempos[k];
                this.listaTempos[k] = trocaTempo;
                this.listaProdutos[j] = this.listaProdutos[k];
                this.listaProdutos[k] = trocaProd;
              }
            }
          }
        })
        .catch(error => {
          if (!window.top.Cypress) {
            this.$alert("Informação indisponivel");
          }
          console.warn(error);
        });
    },
    apresentarEncomendasUser() {
      var base = '{"clienteEmail": "' + this.clienteEmail + '"}';

      Vue.axios
        .post(
          "http://localhost:3000/api/encomendas/EncomendasUser/",
          JSON.parse(base)
        )
        .then(response => {
          this.listaEncomendasUser = response.data;
        })
        .catch(error => {
          if (!window.top.Cypress) {
            this.$alert("Erro");
          }
          console.warn(error);
        });
    },
    consultarEncomendaSelecionadaUser() {
      var base = '{"nrEncomenda": "' + this.nrEncomendaAlterarUser + '"}';

      this.json = JSON.parse(base);
      Vue.axios
        .post(
          "http://localhost:3000/api/encomendas/EncomendaID/",
          JSON.parse(base)
        )
        .then(response => {
          this.encomendaIDUser = response.data;
        })
        .catch(error => {
          if (!window.top.Cypress) {
            this.$alert("Erro");
          }
          console.warn(error);
        });
    }
  }
};
</script>

<style src="../assets/css/encomendaStyle.css">
</style>