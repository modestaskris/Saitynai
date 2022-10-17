<script setup lang="ts">
import { defineComponent } from "vue";
import { TokenService } from "./services/tokenService";
import LayoutView from "./views/LayoutView.vue";
</script>

<template>
  <!-- <div class="fafa"> -->
  <LayoutView />
  <!-- </div> -->
  <!-- <LayoutView /> -->
</template>

<script lang="ts">
export default defineComponent({
  mounted() {
    TokenService.updateTokenInterval();
  }
})
</script>


<style>
html,
body {
  font-family: 'Varela Round', sans-serif;
}

.fafa {
  background: #F7F8F8;
  /* fallback for old browsers */
  background: -webkit-linear-gradient(to right, #ACBB78, #F7F8F8);
  /* Chrome 10-25, Safari 5.1-6 */
  background: linear-gradient(to right, #ACBB78, #F7F8F8);
  /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
}
</style>