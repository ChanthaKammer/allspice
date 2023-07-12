<template>
   <form @submit.prevent="createRecipe">
      <div class="modal-body ">
         <div class="container-fluid">
            <div class="mb-3">
               <label for="recipeTitle" class="form-label">Recipe Title</label>
               <input type="text" class="form-control" id="recipeTitle" aria-describedby="recipeTitle" v-model="editable.title">
               <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
            </div>
            <div class="mb-3">
               <label for="recipeImage" class="form-label">Recipe Image</label>
               <input type="text" class="form-control" id="recipeTitle" aria-describedby="recipeTitle" v-model="editable.img">
               <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
            </div>
            <div class="mb-3">
               <label for="Recipe Category" class="form-label">Category</label>
               <select class="form-select" aria-label="Type Selection" v-model="editable.category" placeholder="">
                        <option selected>Select Type</option>
                        <option value="sandwich">Sandwich</option>
                        <option value="soup">Soup</option>
                        <option value="miata">Miata</option>
                        <option value="Miscalanias">Miscalanias</option>
               </select>
            </div>
            <div class="mb-3">
               <label for="Instructions" class="form-label">Instructions</label>
               <textarea type="textarea" rows="4" class="form-control" id="recipeInstructions" v-model="editable.instructions"></textarea>
            </div>
            <!-- <div class="d-flex justify-content-align-items-end">
               <div class="col-8 d-flex align-items-end">
                  <label for="Recipe Category" class="form-label">Ingredient</label>
               </div>
               <div class="col-2">
                  <label for="Recipe Category" class="form-label">Quantity</label>
               </div>
            </div> -->
            <!-- <div class="d-flex mb-3 justify-content-between">
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
            </div> -->
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
import { everythingService } from '../services/EverythingService.js';
import {ref} from 'vue';
   export default {
      setup(){
         const editable = ref({});
         return {
            editable,
            async createRecipe(){
               try {
                  logger.log("Creating Recipe")
                  await everythingService.createRecipe(editable.value);
               } catch (error) {
                  Pop.error(error)
                  logger.log(error)
               }
            }
         }
      }
   }
</script>


<style scoped lang="scss">
*{
   border: 0px solid green;
}

</style>