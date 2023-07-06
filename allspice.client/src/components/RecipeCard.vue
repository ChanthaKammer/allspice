<template>
   <div class="col-md-4 p-4">
      <div class="d-flex flex-column recipe-card justify-content-center position-relative">
         <!-- :style="{ 'background-image': 'url(' +recipe.img+')' }" -->
         <!-- <h5>{{ recipe.title.split(' ').splice(0, 3).join(' ') }}</h5>
         <h3>{{  recipe.category }}</h3>
         <p>{{ recipe.instructions }}</p>
         <p>{{ recipe.creator.name }}</p> -->
         <img :src="recipe.img" class="img-fluid object-fit-cover elevation-5" :title="recipe.title">
         <div class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end">
            <div class="glass p-2 text-white">
               <h5>{{ recipe.title }}</h5>
               <h3>{{  recipe.category }}</h3>
            </div>
         </div>
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
      border: 0px solid tan
   }
   .recipe-card img{
      height: 20rem;
   }
   .glass{
   backdrop-filter: blur(3px);
   background-color: rgba(0, 0, 0, 0.345);
   }  
</style>