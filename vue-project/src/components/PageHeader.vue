<template>
    <!-- <div class="flex justify-between mb-5"> -->
        <!-- TODO saitynai name should be in middle of navbar -->
    <div class="">
        <div class="grid grid-cols-3">
            <div class="text-2xl font-semibold">
                {{ this.label }}
            </div>
            <div>
                maybe use grid here...
            </div>
            <!-- <div>
            select list from - to (use different input methods)
        </div> -->
            <div>
                <slot />
            </div>
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