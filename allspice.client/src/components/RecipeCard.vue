<template>
   <div class="col-md-4 p-5">
      <div class="d-flex text-center flex-column bg-light recipe-card rounded-4">
         <h5>Title</h5>
         <h3>Categories</h3>
         <p>Description</p>
      </div>
   </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
   export default {
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