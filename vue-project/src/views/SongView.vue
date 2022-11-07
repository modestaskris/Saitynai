<script setup lang="ts">
import AddModelVue from "@/components/AddModel.vue";
import ModelRow from "@/components/ModelRow.vue";
import route from "@/router/route";
import PageHeader from "@/components/PageHeader.vue";
import '../styles/transitions.css';
</script>

<template>
  <div>
    <PageHeader label="Songs">
      <AddModelVue
        v-if="!songContainsToPlaylist"
        modelType="song"
        @create-button-pressed="createSong"
      />
    </PageHeader>
    <div v-if="songs.length > 0">
      <TransitionGroup name="songList" tag="div">
        <ModelRow
          v-for="(song, index) in songs"
          v-bind:key="song.songId"
          @deleteModel="deleteSong"
          @editModel="editSong"
          :index="index"
          :modelId="song.songId"
          :name="song.songId + `song`"
          :url="song.url"
          :route-root="route.PLAYLISTS"
          model-type="song"
        />
      </TransitionGroup>
    </div>
    <div v-else>Songs does not exists...</div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { SongService } from "@/services/songService";
import { PlaylistService } from "@/services/playlistService";
import { useRouter } from "vue-router";
import router from "@/router/routes";
import type { AxiosResponse } from "axios";

interface ISong {
  songId: number;
  url: string;
  downloaded: boolean;
  playlistId: number;
  downloadedDate: Date;
}

export default defineComponent({
  data() {
    return {
      router: useRouter(),
      songs: [] as Array<ISong>,
      playlistId: parseInt(`${this.$route.params.playlistId}`),
    };
  },
  computed: {
    // TODO: CRITICAL add logic for /songs and playlist/1
    // /songs maybe will not have playlist id, so cannot update or delete... CRITICAL
    songContainsToPlaylist(): boolean {
      return router.currentRoute.value.path == route.SONGS;
    },
  },
  methods: {
    async getSongs() {
      const playlistId = this.playlistId;
      var resp: AxiosResponse;
      //@ts-ignore
      if (this.songContainsToPlaylist) {
        // TODO: maybe will throw error if song does not have playlist id...
        resp = await SongService.getList();
      } else {
        resp = await SongService.getPlaylistList(playlistId);
      }
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
      if (resp.status == 204) {
        this.songs = this.songs.filter((x) => x.songId !== songId);
      } else {
        throw Error("Error while delete playlist... errorcode:" + resp.status);
      }
    },
    async editSong(modelId: Number, newName: string, newUrl: string) {
      // newName is empty, reusing components, that passes more than one param through emit....
      var song = this.songs.find((x) => x.songId === modelId);
      if (!song) {
        console.error("Song with id not found");
        return;
      }
      const obj = {
        playlistId: song.playlistId,
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
