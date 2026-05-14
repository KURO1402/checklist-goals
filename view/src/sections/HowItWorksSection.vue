<script setup>
    import StepCard from '../components/ui/StepCard.vue';
</script>
<template>
    <section class="bg-background border-b border-border py-10">
        <!-- Titulo y subtitulo -->
        <div class="flex gap 5 flex-col gap-4">
            <h1 class="text-primary text-center text-base font-bold">CÓMO FUNCIONA</h1>
            <h2 class="text-text text-center text-3xl">Tres pasos, sin complicaciones</h2>
            <p class="text-text-muted text-sm text-center">Empieza en menos de un minuto.</p>
        </div>
        <!-- Cards -->
         <div>
            <StepCard :number_step="1" icon="a" title="Define tu objetivo" details="Dale un nombre y decide cuántos días quieres mantenerlo."/>
            <StepCard :number_step="2" icon="a" title="Marca tu día"  details="Cada día que cumples, un toque y listo. Sin formularios."/>
            <StepCard :number_step="3" icon="a" title="Completa el objetivo"  details="Al llegar al total de días, el objetivo se marca completo."/>
         </div>

    </section>
    

</template>