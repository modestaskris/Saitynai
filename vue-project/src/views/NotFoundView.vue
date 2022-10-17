<template>
    <div class="flex justify-center">
        <div>
            <div class="justify-center flex">
                <div class="max-w-lg">
                    <img src="./../assets/NotFoundPng3.png" alt="" width="3000" height="3500">
                </div>
            </div>
            <div class="justify-center flex">
                <button class="text-purple-400" @click="pushBack">
                    Go back
                </button>
            </div>
            <RouterLink to="/login" class="text-purple-400 justify-center flex">
                Login
            </RouterLink>

        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    methods: {
        pushBack() {
            this.$router.back();
        }
    }
})
</script>
