<script setup>
import { Menu, X } from 'lucide-vue-next';
import { ref } from 'vue';
import ButtonInit from '../ui/ButtonInit.vue';
import ThemeToggle from '../ui/ThemeToggle.vue';

const isMenuOpen = ref(false);
</script>

<template>
  <header class="p-4 md:p-6 bg-background border-b border-border sticky top-0 z-50">
    <div class="container mx-auto flex items-center justify-between">
      
      <!-- Logo -->
      <a href="/" class="flex items-center shrink-0">
        <div aria-hidden="true" class="w-[24px] h-[24px] md:w-[30px] md:h-[30px] bg-primary rounded-[4px] flex items-center justify-center mr-2">
          <div class="w-[8px] h-[8px] md:w-[10px] md:h-[10px] rounded-full bg-background"></div>
        </div>
        <p class="font-bold text-xl md:text-2xl text-tertiary leading-none text-text">AimHigh</p>
      </a>

      <!-- Navegación Desktop -->
      <nav class="hidden md:block">
        <ul class="flex items-center text-tertiary font-bold gap-6">
          <li><a href="#funciona" class="text-text hover:text-primary transition-colors">Cómo funciona</a></li>
          <li><a href="#porque" class="text-text hover:text-primary transition-colors">Por qué</a></li>
        </ul>
      </nav>

      <div class="flex items-center gap-3">
        <ThemeToggle />
        
        <div class="hidden sm:block pl-5">
          <ButtonInit />
        </div>

        <button 
          @click="isMenuOpen = !isMenuOpen"
          class="md:hidden p-2 text-tertiary"
        >
          <Menu v-if="!isMenuOpen" :size="24" />
          <X v-else :size="24" />
        </button>
      </div>
    </div>

    <!-- Menú Desplegable Móvil -->
    <transition
      enter-active-class="transition duration-200 ease-out"
      enter-from-class="transform -translate-y-4 opacity-0"
      enter-to-class="transform translate-y-0 opacity-100"
      leave-active-class="transition duration-150 ease-in"
      leave-from-class="transform translate-y-0 opacity-100"
      leave-to-class="transform -translate-y-4 opacity-0"
    >
      <nav v-if="isMenuOpen" class="md:hidden pt-4 pb-2 border-t border-border mt-4">
        <ul class="flex flex-col gap-4 text-tertiary font-bold">
          <li><a href="#funciona" class="block py-2 hover:text-primary">Cómo funciona</a></li>
          <li><a href="#porque" class="block py-2 hover:text-primary">Por qué</a></li>
          <li class="sm:hidden pt-2">
            <ButtonInit class="w-full justify-center" />
          </li>
        </ul>
      </nav>
    </transition>
  </header>
</template>