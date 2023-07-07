<template>
   <ul class="d-flex nav justify-content-around text-dark bg-light align-items-center pt-2">
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="getTowerEvents">
            All
         </h3>
      </li>
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="filterEvents('concert')">
            My Recipes
         </h3>
      </li>
      <li class="nav-item">
         <h3 href="" class="" role="button" @click="filterEvents('convention')">
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
   export default {
      setup(){
         return {
            async filterEvents(type){
               try {
                  // await towerEventService.getTowerEvents()
                  // await towerEventService.filterEvents(type)
               } catch (error) {
                  Pop.error(error)
                  logger.log(error)
               }
            },
            async getTowerEvents(){
            try {
               logger.log("getTowerEvents")
               // await towerEventService.getTowerEvents()
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