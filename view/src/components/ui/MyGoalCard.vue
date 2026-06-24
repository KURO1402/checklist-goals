<script setup>
import { computed } from 'vue'

const props = defineProps({
  nombre: String,
  descripcion: String,
  actual: Number,
  total: Number,
  estado: String
})

const radius = 40
const circumference = 2 * Math.PI * radius

const progressOffset = computed(() => {
  if (!props.total) return circumference
  const progress = props.actual / props.total
  return circumference - Math.min(progress, 1) * circumference
})

const progreso = computed(() => {
  if (!props.total) return 0
  return Math.round((props.actual / props.total) * 100)
})
</script>

<template>
  <div class="flex flex-col items-center gap-2 p-4 md:p-5 rounded-2xl bg-surface border border-border w-full hover:bg-bg-hover transition-colors">
    <div class="relative flex items-center justify-center w-20 h-20 md:w-24 md:h-24 shrink-0">
      <svg viewBox="0 0 100 100" class="transform -rotate-90 w-full h-full">
        <circle
          cx="50" cy="50" :r="radius"
          stroke="currentColor" stroke-width="6" fill="transparent"
          class="text-surface-2"
        />
        <circle
          cx="50" cy="50" :r="radius"
          stroke="currentColor" stroke-width="6" fill="transparent"
          :stroke-dasharray="circumference"
          :stroke-dashoffset="progressOffset"
          stroke-linecap="round"
          class="text-primary transition-all duration-500 ease-out"
        />
      </svg>
      <span class="absolute text-text font-bold text-sm md:text-base">{{ progreso }}%</span>
    </div>

    <div class="flex flex-col items-center text-center min-w-0 gap-1">
      <h3 class="text-text font-semibold text-sm md:text-base leading-tight truncate max-w-full">
        {{ nombre }}
      </h3>
      <p v-if="descripcion" class="text-text-muted text-xs leading-tight line-clamp-2 max-w-full">
        {{ descripcion }}
      </p>
      <p class="text-text-muted text-xs mt-1">
        {{ actual }} de {{ total }} días
        <span v-if="actual >= total && total > 0" class="text-primary font-semibold"> — completado</span>
      </p>
    </div>
  </div>
</template>
