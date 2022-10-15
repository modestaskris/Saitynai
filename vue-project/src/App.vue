<script setup lang="ts">
import { defineComponent } from "vue";
import { TokenService } from "./services/tokenService";
import LayoutView from "./views/LayoutView.vue";
</script>

<template>
  <LayoutView />
</template>

<script lang="ts">
export default defineComponent({
  mounted() {
    TokenService.updateTokenInterval();
  }
})
</script>