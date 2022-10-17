<template>
    <!-- make centered -->
    <div v-if="['login', 'register'].includes($route.name)" class="pt-56">
    </div>
    <div class="relative flex min-h-screen">
        <Menu v-if="$route.meta.displayMenu" class="w-64" />
        <div class="basis-full flex-1">
            <Navbar v-if="$route.meta.displayNavBar" />
            <div>
                <!-- content -->
                <div class="p-6">
                    <RouterView />
                </div>
            </div>
        </div>
    </div>
    <Footer v-if="$route.meta.displayFooter"/>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Menu from '../components/Menu.vue';
import Navbar from '../components/Navbar.vue';
import Footer from '../components/Footer.vue';


export default defineComponent({
    components: { Menu, Navbar, Footer }
})
</script>