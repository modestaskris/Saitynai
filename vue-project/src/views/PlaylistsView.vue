<script setup lang="ts">
import AddModelVue from "@/components/AddModel.vue";
import ModelRow from "@/components/ModelRow.vue";
import route from "@/router/route";
</script>

<template>
  <div>
    <AddModelVue v-if="playlistContainsInCategory" modelType="playlist" @create-button-pressed="createPlaylist" />
    <!-- TODO: endpoint returns all playlists... -->
    <ModelRow
      v-for="playlist in playlists"
      v-bind:key="playlist.playlistId"
      @deleteModel="deletePlaylist"
      @editModel="editPlaylist"
      :modelId="playlist.playlistId"
      :name="playlist.title"
      :url="playlist.url"
      :route-root="route.PLAYLISTS"
      model-type="playlist"
    />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { CategoryService } from "@/services/categoryService";
import { PlaylistService } from "@/services/playlistService";
import type { AxiosResponse } from "axios";
import { useRoute } from "vue-router";

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
  computed:{
    playlistContainsInCategory(){
      const router = useRoute();
      return router.path !== route.PLAYLISTS;
    }
  },
  methods: {
    async getPlaylists() {
      const categ = this.categoryId;
      var resp: AxiosResponse; // TODO: maybe does not require to initialize...
      if(this.playlistContainsInCategory){
        // todo if false, 
        // fetches playlist of selected category
        console.log("fetching playlists by category");
        resp = await CategoryService.getPlaylists(categ);
      } else {
        // fetches all playlists
        console.log("fetching all playlists..");
        resp = await PlaylistService.getList();
      }
      // await CategoryService.getPlaylists(categ);
      if (resp.status === 200) {
        this.playlists = resp.data;
      } else {
        console.error("Error while fetching category playlists...");
      }
    },
    async createPlaylist(title: string, url: string) {
      const obj = {
        categoryId: this.categoryId,
        title: title,
        url: url,
      };
      const resp = await PlaylistService.create(obj);
      console.log(resp);
      if (resp.status === 201) {
        this.playlists.push(resp.data);
      } else {
        throw Error("Error while creating playlist, code" + resp.status);
      }
    },
    async deletePlaylist(playlistId: Number) {
      const resp = await PlaylistService.delete(playlistId);
      console.log(resp);
      // TODO: test
      if (resp.status == 204) {
        this.playlists = this.playlists.filter(
          (x) => x.playlistId !== playlistId
        );
      } else {
        throw Error("Error while delete playlist... errorcode:" + resp.status);
      }
    },
    async editPlaylist(playlistId: Number, newName: string, newUrl: string) {
      const obj = {
        categoryId: this.categoryId,
        title: newName,
        url: newUrl,
      };
      const resp = await PlaylistService.update(playlistId, obj);
      if (resp.status === 200) {
        this.playlists = this.playlists.map((x) => {
          if (x.playlistId === playlistId) {
            x = resp.data;
          }
          return x;
        });
      } else {
        throw Error(
          "Unhandled error code while updating playlist.." + resp.status
        );
      }
    },
  },
  mounted() {
    this.getPlaylists();
  },
});
</script>