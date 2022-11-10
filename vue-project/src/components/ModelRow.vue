<script setup lang="ts">
import { defineComponent } from "vue";
import { RouterLink } from "vue-router";
import EditModel from "./EditModel.vue";
</script>

<template>
  <!-- <div class="grid-cols-4" :class="divStyle" @click="(e) => navigate(e)"> -->
  <div class="grid-cols-4" :class="divStyle" @click="(e) => navigate(e)">
    <RouterLink
      v-if="!isSong"
      :to="`${routeRoot}/${modelId}`"
      class="font-semibold p-1 m-1 rounded-lg"
    >
      <!-- TODO use router link -->
      {{ name }}
    </RouterLink>
    <a v-else class="font-semibold p-1 m-1 rounded-lg">
      {{ name }}
    </a>
    <a
      v-if="url !== undefined"
      :href="url"
      class="font-semibold p-1 m-1 rounded-lg hover:bg-gray-500"
    >
      <font-awesome-icon icon="fa-solid fa-arrow-up-right-from-square" />
      Link
    </a>
    <div class="flex justify-end">
      <EditModel
        @modalActivation="modalActivate"
        @editModelPressed="editModelClicked"
        :model-name="name"
        :model-type="modelType"
      />
      <button
        @click="(e) => deleteModelClicked(e)"
        class="bg-red-400 mx-1 p-1 rounded-lg hover:bg-red-500"
      >
        <font-awesome-icon icon="fa-regular fa-trash-can" />
        Remove
      </button>
    </div>
  </div>
</template>

<script lang="ts">
export default defineComponent({
  props: {
    index: Number,
    name: String,
    modelId: Number,
    url: String || undefined,
    routeRoot: String,
    modelType: String,
  },
  emits: ["deleteModel", "editModel"],
  data() {
    return {
      modalIsActive: false,
    };
  },
  computed: {
    isCategory(): boolean {
      return this.modelType === "category";
    },
    isPlaylist(): boolean {
      return this.modelType === "playlist";
    },
    isSong(): boolean {
      return this.modelType === "song";
    },
    divStyle() {
      // return `flex justify-between rounded-3xl my-1 p-2 border-black border-4 hover:bg-gray-500 
      return `flex justify-between rounded-3xl my-1 p-2 border-black border-4 hover:bg-gray-500 
      ${this.index % 2 == 0 ? "bg-gray-300" : "bg-gray-400"}`;
    },
    // divStyle() {
    //   return `flex justify-between rounded-3xl my-1 p-2 border-black border-4 hover:bg-gray-500
    //   ${this.index % 2 == 0 ? "bg-gray-300" : "bg-gray-400"}`;
    // },
  },
  methods: {
    deleteModelClicked(e: any) {
      if (this.modelId != undefined) {
        e.stopPropagation();
        this.$emit("deleteModel", this.modelId);
      }
    },
    editModelClicked(newName: String, newUrl: String) {
      if (this.modelId == undefined) {
        // TODO: throw error
        return;
      }
      if (this.isCategory) {
        this.$emit("editModel", this.modelId, newName);
      } else if (this.isPlaylist) {
        this.$emit("editModel", this.modelId, newName, newUrl);
      } else if (this.isSong) {
        // TODO: implement...
        console.log("should emit song info...");
        this.$emit("editModel", this.modelId, newName, newUrl);
      } else {
        throw Error("type not found: " + this.modelType);
        // TODO emit not implemented.. or throw error
      }
    },
    modalActivate(state: boolean) {
      this.modalIsActive = state;
      console.log("State changed");
    },
    navigate(e: any) {
      if (this.isSong || this.modalIsActive) {
        // no navigation from song component
        return;
      }
      // TODO check if modal is closed, if true, allow routing...
      this.$router.push(`${this.routeRoot}/${this.modelId}`);
    },
  },
});
</script>
