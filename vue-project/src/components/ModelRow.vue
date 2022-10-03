<script setup lang="ts">
import { defineComponent } from "vue";
import { RouterLink } from "vue-router";
import route from "@/router/route";
import { CategoryService } from "@/services/categoryService";
</script>
<template>
  <div class="flex justify-between">
    <RouterLink
      :to="`${route.CATEGORIES}/${modelId}`"
      class="font-semibold bg-blue-400 text-white p-1 m-1 rounded-lg"
    >
      <!-- TODO use router link -->
      {{ name }}
    </RouterLink>
    <div v-if="url !== undefined">
      <a :href="url" class="">
        link
      </a>
    </div>
    <button
      @click="deleteCategoryClicked"
      class="bg-red-200 p-1 m-1 rounded-lg"
    >
      Remove
    </button>
  </div>
  <hr />
</template>
    
<script lang="ts">
export default defineComponent({
  props: {
    name: String,
    modelId: Number,
    url: String||undefined,
  },
  emits: ['deleteModel'],
  methods: {
    deleteCategoryClicked() {
      if (this.modelId != undefined) {
        this.$emit("deleteModel", this.modelId);
      }
    },
  },
});
</script>