<template>
  <div>
    <Category
      v-for="playlist in playlists"
      :categoryId="playlist.categoryId"
      :name="playlist.name"
    />
  </div>
</template>

<script lang="ts">
import Category from "../components/Category.vue";
export default {
  data() {
    return {
      playlists: [
        {
          categoryId: 3,
          name: "Rap",
        },
        {
          categoryId: 4,
          name: "Chill",
        },
        {
          categoryId: 5,
          name: "Trap",
        },
      ],
    };
  },
  mounted() {
    // this.playlists =
  },
  components: { Category },
};
</script>