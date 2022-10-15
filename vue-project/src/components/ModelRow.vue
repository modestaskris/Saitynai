<script setup lang="ts">
import { defineComponent } from "vue";
import { RouterLink, useRoute } from "vue-router";
import route from "@/router/route";
import { CategoryService } from "@/services/categoryService";
import EditModel from "./EditModel.vue";
</script>

<template>
  <div class="flex justify-between bg-zinc-600 rounded-3xl m-1 p-2" @click="(e) => navigate(e)">
    <!-- TODO: use variable as prop to pass route... -->
    <RouterLink v-if="!isSong" :to="`${routeRoot}/${modelId}`" class="font-semibold text-white p-1 m-1 rounded-lg">
      <!-- TODO use router link -->
      {{ name }}
    </RouterLink>
    <a v-else class="font-semibold text-black p-1 m-1 rounded-lg">
      {{ name }}
    </a>
    <div v-if="url !== undefined">
      <a :href="url"> link TODO update style</a>
    </div>
    <div>
      <div class="flex justify-end">
        <EditModel @editModelPressed="editModelClicked" :model-name="name" :model-type="modelType" />
        <button @click="deleteModelClicked" class="bg-red-200 mx-1 p-1 rounded-lg">
          Remove
        </button>
      </div>
    </div>
  </div>
</template>
    
<script lang="ts">
export default defineComponent({
  props: {
    name: String,
    modelId: Number,
    url: String || undefined,
    routeRoot: String,
    modelType: String,
  },
  emits: ["deleteModel", "editModel"],
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
  },
  methods: {
    deleteModelClicked() {
      if (this.modelId != undefined) {
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
    navigate(e: any) {
      console.log(e);
      console.log(e.bubbles);
      // e.stopPropagation();
      // console.log("navigating...");
      // TODO: if buttons are clicked, ignore routing...
      // this.$router.push(`${this.routeRoot}/${this.modelId}`);
    }
  },
});
</script>