<script setup>
defineProps({
    nombre: String,
    descripcion: String
})
</script>
<template>
    <div class="border bg-primary p-5 rounded-2xl">
        <p>{{ nombre }}</p>
        <p>{{ descripcion }}</p>
        <div>
            
        </div>
    </div>
</template>