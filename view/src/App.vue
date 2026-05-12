<script setup>
import Header from './components/layout/Header.vue';
import Footer from './components/layout/Footer.vue';
</script>

<template>
  <div class="flex flex-col min-h-screen">
    <Header></Header>
    <main class="flex-grow">
      <RouterView />
    </main>
    <Footer></Footer>
  </div>
  
</template>
