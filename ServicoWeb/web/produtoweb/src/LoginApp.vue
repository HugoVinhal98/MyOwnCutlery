<template>
  <div id="app">
    <h1 class="titulo hide">MyOwnCutlery</h1>
    <img class="hide logo" alt="Vue logo" src="./assets/cutlery.png" />
    <div class="nav hide">
      <router-link to="/login">Login</router-link>
      <router-link to="/registo">Sign-up</router-link>
    </div>
    <main class="App__main">
      <transition name="fade" mode="out-in">
        <router-view />
      </transition>
    </main>
  </div>
</template>

<script>
</script>

<style src="./assets/css/loginAppStyle.css"></style>
