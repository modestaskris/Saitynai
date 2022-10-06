<script setup lang="ts">
import { defineComponent } from 'vue';
</script>

<template>
    <div class="justify-center flex mb-4">
        <div class="flex justify-center bg-stone-200 p-2 rounded-b-full w-3/4">
            <div>
                <RouterLink to='/register' class="mx-2">Register</RouterLink>
            </div>
            <div>
                <RouterLink to="/login">Login</RouterLink>
            </div>
            <div>
                <RouterLink to="/categories">Categories</RouterLink>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
export default defineComponent({
    data() {
        return {
        }
    }

})
</script>