<template>
    <div class="flex justify-between mb-5">
        <div class="text-2xl font-semibold">
            {{this.label}}
        </div>
        <div>
            <slot/>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    props: {
        label: String
    },
});
</script>