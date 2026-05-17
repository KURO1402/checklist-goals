<script setup>
defineProps({
    tag: String,
    title: String,
    description: String
})
</script>
<template>
    <div class="flex flex-col gap-3 border border-border bg-surface rounded-2xl p-5 hover:bg-bg-hover">
        <h2 class="text-text-muted text-sm">{{ tag }}</h2>
        <h1 class="text-primary font-bold text-2xl">{{ title }}</h1>
        <p class="text-text-muted text-sm">{{ description }}</p>
    </div>
</template>