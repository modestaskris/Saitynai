<script setup lang="ts">
import { defineComponent } from "vue";
import { RouterLink } from "vue-router";
import route from "@/router/route";
</script>

<template>
  <div class="flex justify-between">
    <RouterLink
      :to="`${route.CATEGORIES}/${categoryId}`"
      class="font-semibold bg-blue-400 text-white p-1 m-1 rounded-lg"
    >
      <!-- TODO use router link -->
      {{ name }}
    </RouterLink>
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
    categoryId: Number,
  },
  emits: {
    deleteCategory(paylaod: number) {
      return true;
    },
  },
  methods: {
    deleteCategoryClicked() {
      if (this.categoryId != undefined) {
        this.$emit("deleteCategory", this.categoryId);
      }
    },
  },
});
</script>