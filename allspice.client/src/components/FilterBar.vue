<template>
   <ul class="d-flex nav justify-content-around text-dark bg-light align-items-center pt-2">
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="getRecipes()">
            All
         </h3>
      </li>
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="filterRecipes('mine')">
            My Recipes
         </h3>
      </li>
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="filterRecipes('favorites')">
            Favorites
         </h3>
      </li>
   </ul>
</template>

<!-- ['concert', 'convention', 'sport', 'digital'] -->

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { everythingService } from '../services/EverythingService.js';
   export default {
      setup(){
         return {
            async filterRecipes(type){
               try {
                  logger.log("Filtering by" +type)
                  await everythingService.filterRecipes(type);
               } catch (error) {
                  Pop.error(error)
                  logger.log(error)
               }
            },
            async getRecipes(){
            try {
               AppState.recipes = [];
               logger.log("getRecipes All Recipes")
               await everythingService.getRecipes()
            } catch (error) {
               Pop.error(error)
               logger.log(error)
            }
            }
         }
      }
   }
</script>


<style lang="scss" scoped>
   * {
      border: 0px solid green;
   }
   ul li a {
      text-decoration: none;
   }
</style>