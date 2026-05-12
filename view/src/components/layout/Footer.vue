<script setup>
import { Github } from 'lucide-vue-next'
const currentYear = new Date().getFullYear()
</script>

<template>
  <footer class="bg-background border-t border-border py-4 px-6 transition-colors duration-300">
    <div class="container mx-auto flex flex-col md:flex-row justify-between items-center gap-6">

      <!-- Info proyecto -->
      <div class="flex flex-col items-center md:items-start gap-2">
        <a href="/" class="flex items-center gap-2">
          <!-- Logo dinámico usando Primary -->
          <div class="w-[18px] h-[18px] bg-primary rounded-[4px] flex items-center justify-center">
            <div class="w-[6px] h-[6px] rounded-full bg-background"></div>
          </div>
          <span class="text-[14px] font-bold text-tertiary">AimHigh</span>
        </a>
        <p class="text-xs text-muted">Seguimiento de objetivos diarios</p>
      </div>

      <!-- GitHub + copyright -->
      <div class="flex flex-col items-center md:items-end gap-3">
        <a
          href="https://github.com/KURO1402"
          target="_blank"
          class="flex items-center gap-2 bg-primary/5 border border-primary/20 px-4 py-2 rounded-full text-tertiary hover:bg-primary hover:text-white transition-all duration-300"
        >
          <span class="text-sm font-medium">KURO1402</span>
          <Github :size="18" />
        </a>
        <p class="text-xs text-muted/60">
          © {{ currentYear }} AimHigh — Creado por PabloDEV
        </p>
      </div>

    </div>
  </footer>
</template>