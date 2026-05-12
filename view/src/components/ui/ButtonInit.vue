<script setup>
import { MoveRight } from 'lucide-vue-next';
</script>

<template>
  <a href="/login">
  <button class="aimhigh-button group">
    <span class="relative z-10 flex items-center gap-2">
      Entrar
      <MoveRight :size="18" />
    </span>
  </button>
  </a>
</template>

<style scoped>
.aimhigh-button {
  all: unset;
  display: flex;
  align-items: center;
  position: relative;
  /* Tamaño ajustado para el header */
  padding: 0.5rem 1.5rem;
  border: var(--color-primary) solid 0.15em;
  border-radius: 0.4em;
  color: var(--color-primary);
  font-size: 1rem;
  /* Tamaño base para el header */
  font-weight: 700;
  cursor: pointer;
  overflow: hidden;
  transition: border 300ms, color 300ms;
  user-select: none;
}

.aimhigh-button span {
  z-index: 1;
}

.aimhigh-button:hover {
  color: var(--color-background);
}

.aimhigh-button:active {
  border-color: var(--color-tertiary);
}

.aimhigh-button::after,
.aimhigh-button::before {
  content: "";
  position: absolute;
  width: 120%;
  aspect-ratio: 1;
  background: var(--color-primary);
  opacity: 0;
  border-radius: 50%;
  transition: transform 500ms, opacity 300ms;
  z-index: 0;
}

.aimhigh-button::before {
  left: 0;
  transform: translateX(-100%) translateY(-20%);
}

.aimhigh-button::after {
  right: 0;
  transform: translateX(100%) translateY(20%);
}

.aimhigh-button:hover::before {
  transform: translateX(-40%);
  opacity: 1;
}

.aimhigh-button:hover::after {
  transform: translateX(40%);
  opacity: 1;
}

.aimhigh-button:active::before,
.aimhigh-button:active::after {
  background: var(--color-tertiary);
}
</style>