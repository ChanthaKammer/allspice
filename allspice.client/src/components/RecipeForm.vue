<template>
   <form>
      <div class="modal-body ">
         <div class="container-fluid">
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
            <!-- <div class="d-flex justify-content-align-items-end">
               <div class="col-8 d-flex align-items-end">
                  <label for="Recipe Category" class="form-label">Ingredient</label>
               </div>
               <div class="col-2">
                  <label for="Recipe Category" class="form-label">Quantity</label>
               </div>
            </div> -->
            <div class="d-flex mb-3 justify-content-between">
               <div class="col-8 pe-1">
                  <input type="text" class="form-control" id="recipeCategory" placeholder="Ingredient">
               </div>
               <div class="col px-1">
                  <input type="text" class="form-control" id="recipeCategory" placeholder="Quantity">
               </div>
               <button class="btn btn-info">
                     Add
               </button>
            </div>
            <div class="d-flex mb-3 justify-content-between align-items-end">
               <div class="col">
                  <h5>Radishes</h5>
               </div>
               <div class="col text-center">
                  <h5>2 Pounds</h5>
               </div>
               <button class="btn btn-danger">
                     <i class="mdi mdi-trash-can"></i>
               </button>
            </div>
            <div class="d-flex mb-3 justify-content-between align-items-end">
               <div class="col">
                  <h5>Radishes</h5>
               </div>
               <div class="col text-center">
                  <h5>1 Cup</h5>
               </div>
               <button class="btn btn-danger">
                     <i class="mdi mdi-trash-can"></i>
               </button>
            </div>
            <div class="d-flex justify-content-end gap-2">
               <button type="submit" class="btn btn-primary">Submit</button>
               <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            </div>
         </div>
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


<style scoped lang="scss">
*{
   border: 1px solid green;
}

</style>