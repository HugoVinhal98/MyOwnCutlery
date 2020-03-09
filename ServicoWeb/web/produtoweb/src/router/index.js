import Vue from 'vue'
import Produto from '@/components/Produto.vue'
import VueRouter from 'vue-router'
import Home from '@/App.vue'
import Operacao from '@/components/Operacao.vue'
import TipoMaquina from '@/components/TipoMaquina.vue'
import Maquina from '@/components/Maquina.vue'
import LinhaProducao from '@/components/LinhaProducao.vue'
import Login from '@/components/Login.vue'
import Registo from '@/components/Registo.vue'
import Cliente from '@/components/Cliente.vue'
import Encomenda from '@/components/Encomenda.vue'
import EncomendaAdmin from '@/components/EncomendaAdmin.vue'
import AlterarCliente from '@/components/AlterarCliente.vue'
import AlterarClienteAdmin from '@/components/AlterarClienteAdmin.vue'
import Termos from '@/components/Termos.vue'
import Perfil from '@/components/Perfil.vue'
import ApagarDados from '@/components/ApagarDados.vue'
import { store } from './store';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    component: Home
  },
  {
    path: '/home',
    name: 'home',
    component: Home
  },
  {
    path: '/produto',
    name: 'produto',
    component: Produto
  },
  {
    path: '/operacao',
    name: 'operacao',
    component: Operacao
  },
  {
    path: '/tipoMaquina',
    name: 'tipoMaquina',
    component: TipoMaquina
  },
  {
    path: '/maquina',
    name: 'maquina',
    component: Maquina
  },
  {
    path: '/linhaproducao',
    name: 'linhaproducao',
    component: LinhaProducao
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/registo',
    name: 'registo',
    component: Registo
  },
  {
    path: '/cliente',
    name: 'cliente',
    component: Cliente
  },
  {
    path: '/encomenda',
    name: 'encomenda',
    component: Encomenda
  },
  {
    path: '/encomendaAdmin',
    name: 'encomendaAdmin',
    component: EncomendaAdmin
  },
  {
    path: '/alterarCliente',
    name: 'alterarCliente',
    component: AlterarCliente
  },
  {
    path: '/perfil',
    name: 'perfil',
    component: Perfil
  },
  {
    path: '/termos',
    name: 'termos',
    component: Termos
  },
  {
    path: '/alterarClienteAdmin',
    name: 'alterarClienteAdmin',
    component: AlterarClienteAdmin
  },
  {
    path: '/apagarDados',
    name: 'apagarDados',
    component: ApagarDados
  }
]

const router = new VueRouter({
  routes
})

router.beforeEach((to, from, next) => {
  if (to.path !== '/login' && to.path !== '/registo') {
    if (store.state.accessToken === undefined ||
      store.state.accessToken === null ||
      store.state.accessToken === "") {
      next({ path: '/login', replace: true });
    }
    else {
      next();
    }
  }
  else {
    if (store.state.accessToken !== undefined &&
      store.state.accessToken !== null &&
      store.state.accessToken !== "") {
      next({ path: '/', replace: true });
    }
    else {
      next();
    }
  }
});

export default router