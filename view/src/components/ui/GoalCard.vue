<script setup>
import { computed } from 'vue'

const props = defineProps({
  nombre: String,
  actual: Number,
  total: Number
})

const radius = 35
const circumference = 2 * Math.PI * radius

const progressOffset = computed(() => {
  const progress = props.actual / props.total
  return circumference - progress * circumference
})
</script>

<template>
  <div class="flex items-center gap-3 p-3 md:p-4 rounded-2xl bg-surface border border-border w-full md:w-fit hover:bg-bg-hover">
    <div class="relative flex items-center justify-center w-10 h-10 md:w-12 md:h-12 shrink-0">
      <svg viewBox="0 0 48 48" class="transform -rotate-90 w-full h-full">
        <circle
          cx="24" cy="24" :r="radius / 2"
          stroke="currentColor" stroke-width="4" fill="transparent"
          class="text-surface-2"
        />
        <circle
          cx="24" cy="24" :r="radius / 2"
          stroke="currentColor" stroke-width="4" fill="transparent"
          :stroke-dasharray="circumference / 2"
          :stroke-dashoffset="progressOffset / 2"
          stroke-linecap="round"
          class="text-primary transition-all duration-500 ease-out"
        />
      </svg>
    </div>

    <div class="flex flex-col min-w-0">
      <h3 class="text-text font-semibold text-sm md:text-base leading-tight truncate">
        {{ nombre }}
      </h3>
      <p class="text-text-muted text-xs md:text-sm">
        <span>{{ actual }}</span> de {{ total }} días
        <span v-if="actual >= total" class="ml-1 text-primary"> — listo</span>
      </p>
    </div>
  </div>
</template>