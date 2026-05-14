<script setup>
    defineProps({
        number_step: Number,
        icon: String,
        title: String,
        details: String
    })
</script>
<template>
    <div>
        <p>{{ number_step }}</p>
        <div>
            <div>{{ icon }}</div>
        </div>
        <div>
            <h3>{{ title }}</h3>
            <p>{{ details }}</p>
        </div>
    </div>
</template>