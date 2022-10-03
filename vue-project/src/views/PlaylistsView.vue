<script setup lang="ts">
import Playlist from "../components/playlists/Playlist.vue";
import AddModelVue from "@/components/AddModel.vue";
import ModelRow from "@/components/ModelRow.vue";
</script>

<template>
  <div>
    <AddModelVue modelName="Playlist" @create-button-pressed="createPlaylist" />

    <!-- TODO: endpoint returns all playlists... -->
    <ModelRow
      v-for="playlist in playlists"
      v-bind:key="playlist.playlistId"
      @deleteModel="deletePlaylist"
      :modelId="playlist.playlistId"
      :name="playlist.title"
      :url="playlist.url"
    />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { CategoryService } from "@/services/categoryService";

interface IPlaylist {
  playlistId: number;
  title: string;
  url: string;
}

export default defineComponent({
  data() {
    return {
      playlists: [] as Array<IPlaylist>,
      categoryId: parseInt(`${this.$route.params.categoryId}`),
    };
  },
  methods: {
    async getPlaylists() {
      const categ = this.categoryId;
      const resp = await CategoryService.getPlaylists(categ);
      if (resp.status === 200) {
        this.playlists = resp.data;
      } else {
        console.error("Error while fetching category playlists...");
      }
    },
    createPlaylist(playlistName: string) {
      // TODO: implement
      console.log(playlistName);
      throw Error("Not implemented");
    },
    deletePlaylist(playlistId: Number){
      // TODO: implement
      throw Error("Not implemented");
    },
  },
  mounted() {
    // TODO fetch information about category playlists...
    this.getPlaylists();
  },
});
</script>