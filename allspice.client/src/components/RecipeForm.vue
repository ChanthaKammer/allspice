<template>
   <form>
      <div class="modal-body">
         <div class="mb-3">
            <label for="recipeTitle" class="form-label">Recipe Title</label>
            <input type="text" class="form-control" id="recipeTitle" aria-describedby="recipeTitle">
            <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
         </div>
         <div class="mb-3">
            <label for="Recipe Category" class="form-label">Category</label>
            <input type="text" class="form-control" id="recipeCategory">
         </div>
         <div class="mb-3">
            <label for="Instructions" class="form-label">Instructions</label>
            <textarea type="textarea" rows="4" class="form-control" id="recipeInstructions"></textarea>
         </div>
         <div class="row mb-3">
            <div class="col-md-8">
               <label for="Recipe Category" class="form-label">Category</label>
               <input type="text" class="form-control" id="recipeCategory">
            </div>
            <div class="col-md-4">
               <label for="Recipe Category" class="form-label">Category</label>
               <input type="text" class="form-control" id="recipeCategory">
            </div>
         </div>
         <div class="mb-3 form-check">
            <input type="checkbox" class="form-check-input" id="exampleCheck1">
            <label class="form-check-label" for="exampleCheck1">Check me out</label>
         </div>
            <button type="submit" class="btn btn-primary">Submit</button>
      </div>
   </form>
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


<style>

</style>