<script setup>
    import StepCard from '../components/ui/StepCard.vue';
    import { Check, Clock4, Grid2X2Plus } from 'lucide-vue-next';
</script>
<template>
  <section id="funciona" class="bg-background border-b border-border py-10 md:py-16 px-5 md:px-16 lg:px-48">
    
    <!-- Título -->
    <div class="flex gap-3 md:gap-5 flex-col">
      <h1 class="text-primary text-center text-base font-bold tracking-widest">CÓMO FUNCIONA</h1>
      <h2 class="text-text text-center text-2xl md:text-3xl">Tres pasos, sin complicaciones</h2>
      <p class="text-text-muted text-sm text-center">Empieza en menos de un minuto.</p>
    </div>

    <!-- Cards -->
    <div class="grid grid-cols-1 sm:grid-cols-3 gap-4 md:gap-5 mt-8 md:mt-10">
      <StepCard number_step="01" :icon="Grid2X2Plus" title="Define tu objetivo" details="Dale un nombre y decide cuántos días quieres mantenerlo." />
      <StepCard number_step="02" :icon="Check" title="Marca tu día" details="Cada día que cumples, un toque y listo. Sin formularios." />
      <StepCard number_step="03" :icon="Clock4" title="Completa el objetivo" details="Al llegar al total de días, el objetivo se marca completo." />
    </div>

  </section>
</template>