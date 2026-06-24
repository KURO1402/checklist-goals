<script setup>
    import MyGoalCard from "../../components/ui/MyGoalCard.vue";
    import {ref} from "vue";
    const objetivos = ref([
        {
            id: 1,
            nombreObjetivo: "Correr",
            descripcionObjetivo: "Correr diariamente"
        }
    ]);
    const objetivo = ref({
        id: 0,
        nombreObjetivo: "",
        decripcionObjetivo: ""
    })
</script>
<template>
    <div>
        <h2 class="text-text font-bold text-2xl">Tus objetivos</h2>
    </div>
    <div v-if="objetivos.length === 0">
        <span>Aun no tienes objetivos</span>
    </div>
    <div class="flex">
        <MyGoalCard v-for="obj in objetivos" :key="obj.id" :nombre="obj.nombreObjetivo" :descripcion="obj.descripcionObjetivo"/>
    </div>
</template>