<script setup lang="ts">
import { TokenService } from '@/services/tokenService';
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
import { AuthService } from '../services/authService';
</script>

<template>
    <div>
        <div class="p-2 bg-gray-800 text-white font-semibold">
            <div class="justify-between flex">
                <div>
                    Saitynai
                </div>
                <div>
                    <RouterLink to='/register' class="mx-2">Register</RouterLink>
                    <RouterLink to="/login" class="mx-2">Login</RouterLink>
                    <button class="mx-2" @click="onLogout">Logout</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
export default defineComponent({
    data(){
        return {
            router: useRouter()
        }
    },
    methods: {
        onLogout() {
            AuthService.logout();
            this.router.push({ path: '/' });
        }
    }
})
</script>