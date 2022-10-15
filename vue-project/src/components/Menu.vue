<template>
    <div :class="menuStyle">
        <div class="flex justify-center w-36">
            <div>
                MENU
            </div>
        </div>
        <hr class="border-white bottom-1 my-2" />
        <ul class="pt-3">
            <li class="py-1">
                <font-awesome-icon icon="fa-solid fa-folder-open" />
                <RouterLink :class="navLinkStyle" to="/categories">Categories
                </RouterLink>
            </li>
            <li class="py-1">
                <font-awesome-icon icon="fa-solid fa-list" />
                <RouterLink :class="navLinkStyle" to="/playlists">Playlists</RouterLink>
            </li>
            <li class="py-1">
                <font-awesome-icon icon="fa-solid fa-music" />
                <RouterLink :class="navLinkStyle" to="/songs">Songs</RouterLink>
            </li>
            <li class="py-1" v-if="isAdmin">
                <font-awesome-icon icon="fa-solid fa-users-rectangle" />
                <RouterLink :class="navLinkStyle" to="/users">Users</RouterLink>
            </li>
        </ul>
    </div>
    <button class="my-7 bg-gray-700 hover:bg-gray-500 h-10 w-10 text-white text-center rounded-r-full"
        @click="trigerMenuDisplay">
        <div v-if="displayMenu">
            <font-awesome-icon icon="fa-solid fa-angles-left" />
        </div>
        <div v-else>
            <font-awesome-icon icon="fa-solid fa-angles-right" />
        </div>
    </button>
</template>

<script lang="ts">
import testService from '@/services/testService';
import { TokenService } from '@/services/tokenService';
import { defineComponent } from 'vue';

export default defineComponent({
    data() {
        return {
            navLinkStyle: 'ml-2 bg-transparent p-1 rounded-lg hover:bg-gray-600',
            displayMenu: true as boolean
        }
    },
    computed: {
        menuStyle() {
            const defaultStyle = " bg-gray-800 text-white  h-screen my-4 ml-4 rounded-xl p-4";
            return defaultStyle + ` ${this.displayMenu ? ("") : ("hidden")}`
        },
        isAdmin(): boolean {
            return true;
            // TODO: only admin can access admin page...
            // return TokenService.parsedJwtToken().role === "Admin"
        }
    },
    methods: {
        trigerMenuDisplay() {
            console.log(this.displayMenu);
            this.displayMenu = !this.displayMenu;
        }
    },
    mounted() {
        testService.printHelloWorld();
    }
});
</script>