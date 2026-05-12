<script setup>
import { computed } from 'vue';

const props = defineProps({
  nombre: String,
  actual: Number,
  total: Number
});

const radius = 35;
const circumference = 2 * Math.PI * radius;

const progressOffset = computed(() => {
  const progress = props.actual / props.total;
  return circumference - (progress * circumference);
});
</script>

<template>
  <div class="flex items-center gap-4 p-4 rounded-2xl bg-bg-card border border-border w-fit">
    <div class="relative flex items-center justify-center w-12 h-12">
      <svg class="transform -rotate-90 w-full h-full">
        <circle
          cx="24"
          cy="24"
          :r="radius / 2"
          stroke="currentColor"
          stroke-width="4"
          fill="transparent"
          class="text-surface-2"
        />
        <circle
          cx="24"
          cy="24"
          :r="radius / 2"
          stroke="currentColor"
          stroke-width="4"
          fill="transparent"
          :stroke-dasharray="circumference / 2"
          :stroke-dashoffset="progressOffset / 2"
          stroke-linecap="round"
          class="text-[#22c55e] transition-all duration-500 ease-out"
        />
      </svg>
    </div>

    <div class="flex flex-col">
      <h3 class="text-text font-semibold text-l leading-tight">
        {{ nombre }}
      </h3>
      <p class="text-gray-500 text-sm">
        <span class="text-gray-400">{{ actual }}</span> de {{ total }} días
        <span v-if="actual >= total" class="ml-1 text-[#22c55e]"> — listo</span>
      </p>
    </div>
  </div>
</template>