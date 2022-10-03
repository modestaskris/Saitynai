<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <nav>
      <!-- <RouterLink to="/">Home</RouterLink> -->
      <!-- <br/> -->
      <!-- <RouterLink to="/about">About</RouterLink> -->
      <!-- TODO ROUTE CONSTANT DOES NOT WORK HERE  -->
      <!-- Maybe router ling object shit -->
      <!-- <RouterLink to={{ROUTE.REGISTER}}>Register</RouterLink>  -->
      <br/>
      <hr/>
      <RouterLink to='/register'>Register</RouterLink> 
      <br/>
      <RouterLink to="/login">login</RouterLink> 
      <br/>
      <RouterLink to="/categories">categories</RouterLink> 
      <br/>
      <hr/>
    </nav>
    
  </header>

  <RouterView />
</template>

<script lang="ts">
export default {
  data(){
    return{

    }
  }
}
</script>
