<template>
    <div class="bg-gray-200 h-screen">
        <!-- <RouterLink :to="">Categories</RouterLink> -->
        <li>
            <RouterLink to="/categories">Categories</RouterLink>
        </li>
        <li>
            <RouterLink to="/playlists">Playlists</RouterLink>
        </li>
        <li>
            <RouterLink to="/categories">Songs</RouterLink>
        </li>
        <li>
            <RouterLink to="/categories">Users</RouterLink>
        </li>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
    data() {
        return {

        }
    }
});
</script>