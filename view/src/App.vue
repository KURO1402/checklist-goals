<script setup>
import Header from './components/layout/Header.vue'
import Footer from './components/layout/Footer.vue'
</script>

<template>
  <div class="flex flex-col min-h-screen bg-bg-background transition-colors duration-300">
    <Header />
    <main class="flex-grow bg-background">
      <RouterView />
    </main>
    <Footer />
  </div>
</template>