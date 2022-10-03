<script setup lang="ts">
import AddModelVue from "@/components/AddModel.vue";
import ModelRow from "@/components/ModelRow.vue";
import route from "@/router/route";
</script>
    
<template>
  <div>
    <AddModelVue modelType="song" @create-button-pressed="createSong" />
    <!-- TODO: endpoint returns all playlists... -->
    <ModelRow
      v-for="song in songs"
      v-bind:key="song.songId"
      @deleteModel="deleteSong"
      @editModel="editSong"
      :modelId="song.songId"
      :name="song.songId + `song`"
      :url="song.url"
      :route-root="route.PLAYLISTS"
      model-type="song"
    />
    <!--   :route-root="route.PLAYLISTS"  TODO: -->
  </div>
</template>
    
<script lang="ts">
import { defineComponent } from "vue";
import { SongService } from "@/services/songService";
import { PlaylistService } from "@/services/playlistService";

interface ISong {
  songId: number;
  url: string;
  downloaded: boolean;
}

export default defineComponent({
  data() {
    return {
      songs: [] as Array<ISong>,
      playlistId: parseInt(`${this.$route.params.playlistId}`),
    };
  },
  methods: {
    async getSongs() {
      const playlistId = this.playlistId;
      const resp = await SongService.getPlaylistList(playlistId);
      if (resp.status === 200) {
        this.songs = resp.data;
      } else {
        console.error("Error while fetching category playlists...");
      }
    },
    async createSong(title: string, url: string) {
        const obj = {
          playlistId: this.playlistId,
          url: url,
        };
        const resp = await SongService.create(obj);
        console.log(resp);
        if (resp.status === 201) {
          this.songs.push(resp.data);
        } else {
          throw Error("Error while creating playlist, code" + resp.status);
        }
    },
    async deleteSong(songId: Number) {
        const resp = await SongService.delete(songId);
        console.log(resp);
        if (resp.status == 204) {
          this.songs = this.songs.filter(
            (x) => x.songId !== songId
          );
        } else {
          throw Error("Error while delete playlist... errorcode:" + resp.status);
        }
    },
    async editSong(modelId: Number, newName: string, newUrl: string) {
      // newName is empty, reusing components, that passes more than one param through emit....
      const obj = {
        playlistId: this.playlistId,
        url: newUrl,
      };
      const resp = await SongService.update(modelId, obj);
      console.log(resp);
      if (resp.status === 200) {
        this.songs = this.songs.map((x) => {
          if (x.songId === modelId) {
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
    this.getSongs();
  },
});
</script>