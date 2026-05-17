<script setup>
    import FeatureCard from "../components/ui/FeatureCard.vue";
</script>
<template>
    <section id="porque" class="bg-background border-b border-border py-10 md:py-16 px-5 md:px-16 lg:px-48">
    
    <!-- Título -->
    <div class="flex gap-3 md:gap-5 flex-col">
      <h1 class="text-primary text-center text-base font-bold tracking-widest">POR QUÉ FUNCIONA</h1>
      <h2 class="text-text text-center text-2xl md:text-3xl">La constancia vence al talento</h2>
      <p class="text-text-muted text-sm text-center">Un día a la vez construye hábitos que permanecen.</p>
    </div>

    <!-- Cards -->
    <div class="mt-10 grid grid-cols-1 gap-5 sm:grid-cols-2">
        <FeatureCard tag="Efecto del progreso" title="76%" description="más probabilidad de terminar cuando ves tu avance visual cada día."/>
        <FeatureCard tag="Simple a propósito" title="1 toque" description="Es todo lo que necesitas hacer por día. Sin fricción."/>
        <FeatureCard tag="Tus tiempos" title="Tú decides" description="7, 30 o 100 días. Cada objetivo tiene su propio ritmo."/>
        <FeatureCard tag="Sin distracción" title="0 ruido" description="Sin gamificación forzada. Solo tú y tus metas."/>
    </div>
  </section>
</template>