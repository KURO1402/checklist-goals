<script setup>
import { MoveRight } from 'lucide-vue-next'
</script>

<template>
  <button class="group relative flex items-center justify-center gap-2 overflow-hidden px-10 py-4 rounded-xl bg-primary text-text font-bold text-base cursor-pointer transition-all duration-300 active:scale-95 mt-8">
    
    <!-- Ícono que entra por la izquierda -->
    <MoveRight 
      :size="20" 
      class="absolute left-0 -translate-x-full opacity-0 group-hover:left-6 group-hover:translate-x-0 group-hover:opacity-100 transition-all duration-500" 
    />

    <!-- Texto -->
    <span class="relative z-10 transition-all duration-500 group-hover:translate-x-3">
      Empezar
    </span>

    <!-- Ícono que sale por la derecha -->
    <MoveRight 
      :size="20" 
      class="relative z-10 transition-all duration-500 group-hover:translate-x-3 group-hover:opacity-0" 
    />

    <!-- Overlay hover más oscuro -->
    <span class="absolute inset-0 bg-black/10 opacity-0 group-hover:opacity-100 transition-opacity duration-300 rounded-xl" />

  </button>
</template>