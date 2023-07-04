<template>
   <div class="col-md-4 p-5">
      <div class="d-flex text-center flex-column bg-light recipe-card rounded-4">
         <h5>{{ recipe.title }}</h5>
         <h3>{{  recipe.category }}</h3>
         <p>{{ recipe.instructions }}</p>
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Recipe from '../models/Recipe.js'
   export default {
      props: {
         recipe: {type: Recipe, required: true}
      },
      setup(){
         return {
         }
      }
   }
</script>


<style scoped lang="scss">
   * {
      border: 1px solid tan
   }
</style>