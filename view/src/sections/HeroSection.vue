<script setup>
    import GoalCard from '../components/ui/GoalCard.vue';
    import StartButton from '../components/ui/StartButton.vue';
</script>
<template>
    <section class="bg-background border-b border-border flex items-center flex-col py-10 px-[20rem]">
        <!--Mensaje incial-->
        <div class="flex items-center border border-primary rounded-2xl py-2 px-5 font-bold text-xs bg-bg-muted">
            <div class="h-2 w-2 bg-primary rounded-full mr-3"></div>
            <p class="text-primary">Construye hábitos que duran</p>
        </div>
        <!--Titulo y subtitulo-->
        <div class="mt-7">
            <h1 class="text-text text-6xl text-center">Define tus objetivos. Cumple cada día.</h1>
            <div class="px-[10rem] pt-5">
                <p class="text-center text-[#5D866B] text-lg font-bold">Marca tu progreso diario, define cuántos días te toma cada meta y mira cómo los completas uno a uno.</p>
            </div>
            
        </div>
        <!--pequeñas cards-->
        <div class="flex gap-5 mt-10">
            <GoalCard nombre="Leer 30 min" :actual="21" :total="30"/>
            <GoalCard nombre="Ejercicio diario" :actual="8" :total="60"/>
            <GoalCard nombre="Comer saludable" :actual="14" :total="14"/>
        </div>
        <div>
            <StartButton />
        </div>
    </section>
</template>