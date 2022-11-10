<script setup lang="ts">
import AddModelVue from "@/components/AddModel.vue";
import ModelRow from "@/components/ModelRow.vue";
import route from "@/router/route";
import PageHeader from "@/components/PageHeader.vue";
import ModalVue from "@/components/Modal.vue";
</script>

<template>
  <div>
    <PageHeader label="Playlists">
      <!-- Filter  -->
      <template v-slot:center>
        <ModalVue
          modal-header="Filters"
          modal-open-button-name="Filters"
          :submitButtonPressed="filterPlaylists"
        >
          <div class="text-white grid grid-cols-2">
            <div class="">From</div>
            <input
              type="datetime-local"
              class="p-1 border-black border-2 rounded-xl text-black"
              v-model="dateFrom"
            />
            <div>To</div>
            <input
              type="datetime-local"
              class="p-1 border-black border-2 rounded-xl text-black"
              v-model="dateTo"
            />
          </div>
        </ModalVue>
      </template>
      <AddModelVue
        v-if="playlistContainsInCategory"
        modelType="playlist"
        @create-button-pressed="createPlaylist"
      />
    </PageHeader>
    <div v-if="filteredPlaylists.length > 0">
      <ModelRow
        v-for="(playlist, index) in filteredPlaylists"
        v-bind:key="playlist.playlistId"
        @deleteModel="deletePlaylist"
        @editModel="editPlaylist"
        :modelId="playlist.playlistId"
        :name="playlist.title"
        :index="index"
        :url="playlist.url"
        :route-root="route.PLAYLISTS"
        model-type="playlist"
      />
    </div>
    <div v-else>No playlist found...</div>
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
  categoryId: number;
  created: Date;
}

export default defineComponent({
  data() {
    return {
      playlists: [] as Array<IPlaylist>,
      dateFrom: "2022-07-03",
      dateTo: "2022-07-04",
      filteredPlaylists: [] as Array<IPlaylist>,
      categoryId: parseInt(`${this.$route.params.categoryId}`),
    };
  },
  computed: {
    playlistContainsInCategory() {
      const router = useRoute();
      return router.path !== route.PLAYLISTS;
    },
  },
  methods: {
    async getPlaylists() {
      const categ = this.categoryId;
      var resp: AxiosResponse; // TODO: maybe does not require to initialize...
      if (this.playlistContainsInCategory) {
        // fetches playlist of selected category
        console.log("fetching playlists by category");
        resp = await CategoryService.getPlaylists(categ);
      } else {
        // fetches all playlists
        console.log("fetching all playlists..");
        resp = await PlaylistService.getList();
      }
      if (resp.status === 200) {
        this.playlists = resp.data;
        this.filteredPlaylists = this.playlists;
        console.log(this.playlists);
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
      const playlist = this.playlists.find((x) => x.playlistId === playlistId);
      if (!playlist) {
        console.log("No playlist found on editing...");
        return;
      }
      const obj = {
        categoryId: playlist.categoryId,
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
    filterPlaylists() {
      const newDateFrom = new Date(this.dateFrom);
      const newDateTo = new Date(this.dateTo);
      const aa: Array<IPlaylist> = this.playlists.filter((x) => {
        console.log(new Date(x.created).getTime());
        if (
          newDateFrom.getTime() <= new Date(x.created).getTime() &&
          newDateTo.getTime() >= new Date(x.created).getTime()
        ) {
          return x;
        }
      });
      this.filteredPlaylists = aa;
    },
    setInitialDates() {
      const today = new Date();
      this.dateTo = today.toISOString().slice(0, 16);
      const monthAgo = today;
      monthAgo.setMonth(today.getMonth() - 1);
      const dateMonthAgo = monthAgo; // month ago
      this.dateFrom = dateMonthAgo.toISOString().slice(0, 16);
    },
  },
  watch: {
    "dateFrom"(newValue) {
      this.filterPlaylists();
    },
    "dateTo"(newValue) {
      this.filterPlaylists();
    },
  },
  mounted() {
    this.setInitialDates();
    this.getPlaylists();
  },
});
</script>
