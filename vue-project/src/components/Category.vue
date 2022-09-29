<template>
  <div>
    Category component
    {{this.categoryId}}
    {{this.name}}
  </div>
</template>

<script lang="ts">
export default {
  props: {
    categoryId: Number,
    name: String
  }
}
</script>