<template>
   <div class="col-md-4 p-4">
      <div class="d-flex text-center flex-column recipe-card rounded-4" :style="{ 'background-image': 'url(' +recipe.img +')' }">
         <h5>{{ recipe.title.split(' ').splice(0, 3).join(' ') }}</h5>
         <h3>{{  recipe.category }}</h3>
         <p>{{ recipe.instructions }}</p>
         <p>{{ recipe.creator.name }}</p>
         <!-- <img :src="recipe.img" class="img-fluid object-fit-cover" :title="recipe.title"> -->
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { Recipe } from '../models/Recipe.js';
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
   .recipe-card img{
      max-height: 250px;
   }

</style>