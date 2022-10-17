<script setup lang="ts">
import { defineComponent } from "vue";
import { RouterLink } from "vue-router";
import EditModel from "./EditModel.vue";
</script>

<template>
  <div class="flex justify-between bg-gray-400 rounded-3xl my-1 p-2 border-black border-4" @click="(e) => navigate(e)">
    <!-- TODO: use variable as prop to pass route... -->
    <RouterLink v-if="!isSong" :to="`${routeRoot}/${modelId}`" class="font-semibold  p-1 m-1 rounded-lg">
      <!-- TODO use router link -->
      {{ name }}
    </RouterLink>
    <a v-else class="font-semibold  p-1 m-1 rounded-lg">
      {{ name }}
    </a>
    <a v-if="url !== undefined" :href="url" class="font-semibold  p-1 m-1 rounded-lg hover:bg-gray-500">
      <font-awesome-icon icon="fa-solid fa-arrow-up-right-from-square" />
      Link
    </a>
    <div>
      <div class="flex justify-end">
        <EditModel @editModelPressed="editModelClicked" :model-name="name" :model-type="modelType" />
        <button @click="(e) => deleteModelClicked(e)" class="bg-red-400 mx-1 p-1 rounded-lg hover:bg-red-500">
          <font-awesome-icon icon="fa-regular fa-trash-can" />
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
    deleteModelClicked(e:any) {
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
    navigate(e: any) {
      if(this.isSong){ // no navigation from song component
        return;
      }
      this.$router.push(`${this.routeRoot}/${this.modelId}`);
    }
  },
});
</script>