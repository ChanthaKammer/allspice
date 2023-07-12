<template>
<div v-if="recipe.id"
id="recipeDetails" class="modal animate__animated animate__fadeIn animate__fast " tabindex="-1" aria-labelledby="recipeDetails" aria-hidden="true" data-bs-scroll="true"
>
   <div class="modal-dialog  modal-dialog-scrollable">
      <div class="modal-content">
         <div class="d-flex flex-row justify-content-between p-3 fs-5">
            <button
               type="button"
               class="btn-close"
               data-bs-dismiss="modal"
               aria-label="Close"
            ></button>
            <div>
               <i v-if="account.id == recipe.creator.id" class="mdi mdi-delete float-end" style="font-size: 2rem; color:red" role="button" @click="deleteRecipe()"></i>
               <i class="mdi mdi-heart-outline float-end" style="font-size: 2rem" role="button" v-if="!isFavorite" @click="addFavorite()"></i>
               <i class="mdi mdi-heart float-end" style="font-size: 2rem" role="button" v-if="isFavorite" @click="removeFavorite()"></i>
            </div>
         </div>
         <div class="modal-header container-fluid">
            <div class="row justify-content-around">
               <div class="col-md-4">
                  <img :src="recipe.img" alt="" class="img-fluid recipe-img mb-2">
               </div>
               <div class="col-md-8">
                  <div class="d-flex flex-row justify-content-between align-items-center">
                     <h1 v-if="!editing" class="modal-title fs-5" id="exampleModalLabel">{{ recipe.title }}</h1>
                     <h1 v-if="!editing" class="modal-title fs-5 text-success bg-dark rounded-3 p-2" id="exampleModalLabel">{{ recipe.category }}</h1>
                  </div>
                  <p v-if="!editing" class="pt-2"> {{ recipe.instructions }} </p>
                  <label v-if="editing" for="recipeImg" class="form-label">Recipe Image</label>
                  <input v-if="editing" type="text" class="form-control mb-1" name="" id="titletext" v-model="editable.img">
                  <label v-if="editing" for="recipeTitle" class="form-label">Recipe Title</label>
                  <input v-if="editing" type="text" class="form-control mb-1" name="" id="titletext" v-model="editable.title">
                  <label v-if="editing" for="recipeCategory" class="form-label">Recipe Category</label>
                  <input v-if="editing" type="text" class="form-control mb-1" name="" id="categorytext" v-model="editable.category">
                  <label v-if="editing" for="recipeInstructions" class="form-label">Recipe Instructions</label>
                  <textarea v-if="editing" type="textarea" rows="4" class="form-control mb-1" name="" id="instructionstext" v-model="editable.instructions"></textarea>
                  <div class="container-fluid" v-if="recipeIngredients.length > 0">
                     <div v-for="i in recipeIngredients" :key="i.id">
                        COMPONENT
                     </div>
                        <h1 v-for="i in recipeIngredients" :key="i.id">
                           {{ i.name }} {{ i.quantity }}
                           <i class="mdi mdi-delete text-danger"></i>
                        </h1>
                  </div>
                  <div v-if="editing" class="d-flex justify-content-align-items-end">
                     <div class="col-8 d-flex align-items-end">
                        <label for="Recipe Category" class="form-label">Ingredient</label>
                     </div>
                     <div class="col-2">
                        <label for="Recipe Category" class="form-label">Quantity</label>
                     </div>
                  </div>
                  <div v-if="editing" class="d-flex mb-3 justify-content-between">
                     <div class="col-8 pe-1">
                        <input type="text" class="form-control" id="ingredientName" placeholder="Ingredient">
                     </div>
                     <div class="col px-1">
                        <input type="text" class="form-control" id="ingredientQuantity" placeholder="Quantity">
                     </div>
                     <button class="btn btn-info">
                           Add
                     </button>
                  </div>
                  <div class="container-fluid" v-if="recipeIngredients.length > 0">
                        <h1 v-for="i in recipeIngredients" :key="i.id">
                           {{ i.name }} {{ i.quantity }}
                        </h1>
                  </div>
               </div>
            </div>
         </div>
         <div class="modal-footer d-flex flex-row justify-content-between">
            <div class="d-flex flex-row align-items-center gap-2">
               <img :src="recipe.creator.picture" :alt="recipe.creator.name" class="img-fluid rounded-circle object-fit-cover" style="height: 3rem; width: 3rem;">
               <h4>{{ recipe.creator.name }}</h4>
            </div>
            <button v-if="account.id == recipe.creator.id && !editing" type="button" class="btn btn-success" @click="editing = !editing">Edit Recipe</button>
            <button v-if="editing" type="button" class="btn btn-success" @click="editing = !editing; console.log(editing)">Save Changes</button>
         </div>
      </div>
   </div>
</div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { computed, ref } from 'vue';
import { favoriteService } from '../services/EverythingService.js';
   export default {
      setup(){
         const editing = ref(false);
         const editable = ref({});
         return {
            async addFavorite(){
               try{
                  await favoriteService.addFavorite(AppState.activeRecipe.id)
               } catch (error){
                  logger.error(error.Message)
               }
            },
            async removeFavorite(){
               try{
                  await favoriteService.removeFavorite(this.favorite)
               } catch (error){
                  logger.error(error.Message)
               }
            },
            favorite: computed(() => AppState.favorites.find(f => f.id == AppState.activeRecipe.id)),
            editing,
            editable,
            recipe: computed(() => AppState.activeRecipe),
            recipeIngredients: computed(() => AppState.ingredients),
            account: computed(() => AppState.account)
         }
      }
   }
</script>


<style scoped lang="scss">
.recipe-img{
   height: 250px;
   width:auto;
}
</style>