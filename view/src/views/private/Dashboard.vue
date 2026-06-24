<script setup>
    import MyGoalCard from "../../components/ui/MyGoalCard.vue";
    import { ref } from "vue";

    const objetivos = ref([
        {
            id: 1,
            nombreObjetivo: "Correr",
            descripcionObjetivo: "Correr diariamente 5 km",
            totalDias: 30,
            diasCompletados: 12,
            estadoObjetivo: "en_progreso"
        },
        {
            id: 2,
            nombreObjetivo: "Leer",
            descripcionObjetivo: "Leer 20 páginas al día",
            totalDias: 21,
            diasCompletados: 21,
            estadoObjetivo: "completado"
        },
        {
            id: 3,
            nombreObjetivo: "Meditar",
            descripcionObjetivo: "Meditar 10 minutos",
            totalDias: 14,
            diasCompletados: 5,
            estadoObjetivo: "en_progreso"
        }
    ]);
</script>

<template>
    <div class="space-y-4"> 
        <div>
            <h2 class="text-text font-bold text-2xl">Tus objetivos</h2>
        </div>

        <div v-if="objetivos.length === 0">
            <span class="text-gray-500">Aún no tienes objetivos</span>
        </div>

        <div v-else class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
            <MyGoalCard 
                v-for="obj in objetivos" 
                :key="obj.id" 
                :nombre="obj.nombreObjetivo" 
                :descripcion="obj.descripcionObjetivo"
                :actual="obj.diasCompletados"
                :total="obj.totalDias"
                :estado="obj.estadoObjetivo"
            />
        </div>
    </div>
</template>