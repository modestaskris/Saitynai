<template>
  <div>
    <a :href="url">
      {{ title }}
    </a>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import AddModel from "../AddModel.vue";

export default defineComponent({
    props: {
        playlistId: Number,
        title: String,
        url: String,
    },
    components: { AddModel }
});
</script>