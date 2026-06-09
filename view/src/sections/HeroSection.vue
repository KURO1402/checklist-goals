<script setup>
import GoalCard from '../components/ui/GoalCard.vue'
import StartButton from '../components/ui/StartButton.vue'
</script>

<template>
  <section class="bg-background border-b border-border flex items-center flex-col py-10 md:py-16 px-5 md:px-16 lg:px-48">

    <!-- Badge -->
    <div class="flex items-center border border-primary rounded-2xl py-2 px-4 md:px-5 font-bold text-xs bg-primary/5">
      <div class="h-2 w-2 bg-primary rounded-full mr-3 shrink-0"></div>
      <p class="text-primary">Construye hábitos que duran</p>
    </div>

    <!-- Título y subtítulo -->
    <div class="mt-6 md:mt-7 w-full max-w-3xl">
      <h1 class="text-text text-3xl sm:text-4xl md:text-5xl lg:text-6xl text-center leading-tight">
        Define tus objetivos.<br />Cumple cada día.
      </h1>
      <p class="text-center text-text-muted text-sm md:text-base lg:text-lg font-bold mt-4 md:mt-5 px-0 md:px-10 lg:px-16">
        Marca tu progreso diario, define cuántos días te toma cada meta y mira cómo los completas uno a uno.
      </p>
    </div>

    <!-- Cards -->
    <div class="flex flex-col sm:flex-row gap-3 md:gap-5 mt-8 md:mt-10 w-full sm:w-auto">
      <GoalCard nombre="Leer 30 min" :actual="21" :total="30" />
      <GoalCard nombre="Ejercicio diario" :actual="8" :total="60" />
      <GoalCard nombre="Comer saludable" :actual="14" :total="14" />
    </div>

    <!-- Botón -->
    <StartButton />

  </section>
</template>