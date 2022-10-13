<template>
    <!-- make centered  -->
    <div v-if="['login', 'register'].includes($route.name)" class="pt-56">
    </div>
    <div class="relative flex min-h-screen">
        <Menu v-if="!$route.meta.hideMenu" class="w-64" />
        <div class="basis-full flex-1">
            <Navbar v-if="!$route.meta.hideNavBar"/>
            <div>
                <!-- content -->
                <div class="p-6">
                    <RouterView />
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Menu from '../components/Menu.vue';
import Navbar from '../components/Navbar.vue';


export default defineComponent({
    components: { Menu, Navbar }
})
</script>