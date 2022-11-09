<template>
    <!-- <div :class="`md:absolute ` + menuStyle"> -->
    <!-- <div class="flex sm:absolute"> -->
    <!-- <div class="flex md:absolute sm:absolute lg:relative"> -->
    <!-- <div class="flex "> -->
    <div class="flex absolute md:relative ">
        <div :class="menuStyle">
            <div class="flex justify-center w-36">
                <div>
                    MENU
                </div>
            </div>
            <hr class="border-white bottom-1 my-2" />
            <ul class="pt-3">
                <li class="py-1">
                    <RouterLink :class="navLinkStyle" to="/categories">
                        <font-awesome-icon icon="fa-solid fa-folder-open" />
                        Categories
                    </RouterLink>
                </li>
                <li class="py-1">
                    <RouterLink :class="navLinkStyle" to="/playlists">
                        <font-awesome-icon icon="fa-solid fa-list" />
                        Playlists
                    </RouterLink>
                </li>
                <li class="py-1">
                    <RouterLink :class="navLinkStyle" to="/songs">
                        <font-awesome-icon icon="fa-solid fa-music" />
                        Songs
                    </RouterLink>
                </li>
                <li class="py-1" v-if="isAdmin">
                    <RouterLink :class="navLinkStyle" to="/users">
                        <font-awesome-icon icon="fa-solid fa-users-rectangle" />
                        Users
                    </RouterLink>
                </li>
            </ul>
        </div>
        <button
            class="my-7 bg-gray-700 hover:bg-gray-500 h-10 w-10 text-white text-center rounded-r-full me-4"
            @click="trigerMenuDisplay">
            <div>
                <font-awesome-icon icon="fa-solid fa-bars" />
            </div>
            <!-- <div v-if="displayMenu">
            <font-awesome-icon icon="fa-solid fa-angles-left" />
        </div>
        <div v-else>
            <font-awesome-icon icon="fa-solid fa-angles-right" />
        </div> -->
        </button>
    </div>
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
            const defaultStyle = " bg-gray-800 text-white  h-screen my-4 ml-4 rounded-xl p-4 ";
            return defaultStyle + ` ${this.displayMenu ? ("") : ("hidden")}`
        },
        isAdmin(): boolean {
            return true;
            // TODO: only admin can access admin page...
            // return TokenService.parsedJwtToken().role === "Admin"
        },
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