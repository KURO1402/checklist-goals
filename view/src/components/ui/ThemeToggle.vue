<script setup>
import { Sun, Moon } from 'lucide-vue-next';
// Aquí podrías integrar tu lógica de cambio de tema (ej. con VueUse o un Store)
</script>

<template>
  <button 
    class="relative p-2 rounded-full border border-border text-tertiary hover:bg-primary/10 hover:text-primary transition-all duration-300"
    aria-label="Cambiar tema"
  >
    <div class="relative w-5 h-5">
      <!-- Icono Sol (Tema Claro) -->
      <Sun 
        class="absolute inset-0 transform transition-all duration-500 rotate-0 scale-100 dark:-rotate-90 dark:scale-0" 
        :size="20" 
      />
      <!-- Icono Luna (Tema Oscuro) -->
      <Moon 
        class="absolute inset-0 transform transition-all duration-500 rotate-90 scale-0 dark:rotate-0 dark:scale-100" 
        :size="20" 
      />
    </div>
  </button>
</template>