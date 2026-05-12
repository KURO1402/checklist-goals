<script setup>
import { MoveRight } from 'lucide-vue-next';
</script>

<template>
  <button class="animated-button">
    <!-- Icono que entra por la izquierda -->
    <MoveRight class="arr-2" />
    
    <span class="text">Empezar</span>
    
    <span class="circle"></span>
    
    <!-- Icono que sale por la derecha -->
    <MoveRight class="arr-1" />
  </button>
</template>

<style scoped>
.animated-button {
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 4px;
  padding: 16px 36px;
  border: 4px solid transparent;
  font-size: 16px;
  background-color: inherit;
  border-radius: 100px;
  font-weight: 600;
  color: var(--color-primary); 
  box-shadow: 0 0 0 2px var(--color-primary);
  cursor: pointer;
  overflow: hidden;
  transition: all 0.6s cubic-bezier(0.23, 1, 0.32, 1);
}

.animated-button :deep(svg) {
  position: absolute;
  width: 24px;
  height: 24px;
  z-index: 9;
  stroke: var(--color-primary);
  fill: none; 
  transition: all 0.8s cubic-bezier(0.23, 1, 0.32, 1);
}

.arr-1 {
  right: 16px;
}

.arr-2 {
  left: -25%;
}

.circle {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 20px;
  height: 20px;
  background-color: var(--color-primary);
  border-radius: 50%;
  opacity: 0;
  transition: all 0.8s cubic-bezier(0.23, 1, 0.32, 1);
}

.text {
  position: relative;
  z-index: 1;
  transform: translateX(-12px);
  transition: all 0.8s cubic-bezier(0.23, 1, 0.32, 1);
}

.animated-button:hover {
  box-shadow: 0 0 0 12px transparent;
  color: #212121;
  border-radius: 12px;
}

.animated-button:hover .arr-1 {
  right: -25%;
}

.animated-button:hover .arr-2 {
  left: 16px;
}

.animated-button:hover .text {
  transform: translateX(12px);
}

.animated-button:hover :deep(svg) {
  stroke: #212121; 
}

.animated-button:hover .circle {
  width: 220px;
  height: 220px;
  opacity: 1;
}

.animated-button:active {
  scale: 0.95;
  box-shadow: 0 0 0 4px var(--color-primary);
}
</style>