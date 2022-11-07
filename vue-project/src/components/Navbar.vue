<script setup lang="ts">
import { TokenService } from '@/services/tokenService';
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
import { AuthService } from '../services/authService';
</script>

<template>
    <div>
        <div class="m-4 rounded-lg p-4 bg-gray-800 text-white font-semibold">
            <div class="justify-between flex">
                <div class="flex justify-center">
                    Saitynai
                </div>
                <div>
                    <RouterLink to='/register' class="mx-2 hover:bg-gray-600 rounded-xl p-1 py-2">
                        <font-awesome-icon icon="fa-solid fa-user-plus " class="mr-1" />Register
                    </RouterLink>
                    <RouterLink to="/login" class="mx-2 hover:bg-gray-600 rounded-xl p-1">
                        <font-awesome-icon icon="fa-solid fa-arrow-right-to-bracket" class="mr-1" />
                        Login
                    </RouterLink>
                    <button class="mx-2 hover:bg-gray-600 rounded-xl p-1" @click="onLogout">
                        <font-awesome-icon icon="fa-solid fa-arrow-right-from-bracket" class="mr-1" />Logout
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
export default defineComponent({
    data() {
        return {
            router: useRouter()
        }
    },
    methods: {
        onLogout() {
            AuthService.logout();
            this.router.push({ path: '/login' });
        }
    }
})
</script>