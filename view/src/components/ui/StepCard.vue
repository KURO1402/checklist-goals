<script setup>
    defineProps({
        number_step: String,
        icon: {
            type: Object,
            required: true
        },
        title: String,
        details: String
    })
</script>
<template>
    <div class="border border-border rounded-2xl p-5 bg-surface flex flex-col gap-2">
        <p class="text-primary font-bold text-sm">{{ number_step }}</p>
        <div class="flex">
            <div class="bg-primary/10 p-1.5 rounded-xl">
                <Component :is="icon" class="text-primary"/>
            </div>
        </div>
        <div class="text-text-muted text-sm flex flex-col gap-2">
            <h3 class="font-bold">{{ title }}</h3>
            <p>{{ details }}</p>
        </div>
    </div>
</template>