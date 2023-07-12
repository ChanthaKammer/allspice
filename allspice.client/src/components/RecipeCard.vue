<template>
<div class="col-md-4 p-4">
   <div class="bg-dark">
      <i v-if="isFavorite" class="ps-2 mdi mdi-heart fs-1 text-danger" @click="removeFavorite()" role="button"></i>
      <i v-if="!isFavorite" class="ps-2 mdi mdi-heart-outline fs-1" @click="addFavorite()" role="button"></i>
   </div>
   <div class="d-flex flex-column recipe-card justify-content-center position-relative ">
      <img
      :src="recipe.img"
      class="img-fluid object-fit-cover elevation-5"
      :title="recipe.title"/>
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-start"
      >
      <button class="bg-light text-white fs-5">
         <h1 class="bg-light" v-if="recipeIngredients.length > 0"> {{ recipeIngredients.length }} Ingredients </h1>
      </button>
      </div>
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end p-2"
      >
      <div class="glass p-2 text-white rounded-3 elevation-5">
         <h5>{{ recipe.title }} {{recipe.id}}</h5>
         <h3>{{ recipe.category }} <img class="img-fluid rounded-circle object-fit-cover w-25 h-25" :src="recipe.creator.picture"></h3>
      </div>
      <button class="btn btn-light" type="button"
         @click="setActiveRecipe()">View Recipe</button>
      </div>
   </div>
</div>
<!--Modal-->

   
</template>

<script>
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { Recipe } from "../models/Recipe.js";
import { Modal } from "bootstrap";
import { computed, onMounted, ref, watchEffect } from "vue";
import { favoriteService, ingredientService } from "../services/EverythingService.js";
import { everythingService } from "../services/EverythingService.js";
export default {
   props: {
   recipe: { type: Object, required: true }
},
setup(props) {
   // onMounted(() => {
   //    getIngredients()
   // })
   async function getIngredients(){
      try{
         await ingredientService.getIngredientsByRecipeId(props.recipe.id)
      } catch (error){
         logger.error(error.Message)
      }
   }
   const isFavorite = computed(() => {
      return AppState.favorites.some(f => f.id == props.recipe.id)
   });
   const favoriteId = computed(() => {
      return AppState.favorites.find(f => f.id == props.recipe.id)
   })
   const editing = ref(false);
   const editable = ref();
   // const recipeIngredients = ref();
   watchEffect(() => {
      editable.value = props.recipe;
   })
   return {
      async setActiveRecipe(){
         try{
            await everythingService.getRecipeById(props.recipe.id);
            await ingredientService.getIngredientsByRecipeId(props.recipe.id)
            Modal.getOrCreateInstance("#recipeDetails").show();
         } catch (e){
            logger.log(e.Message);
         }
      },
      async addFavorite(){
         try{
            isFavorite.value = true;
            logger.log("liking", props.recipe.id)
            await favoriteService.addFavorite(props.recipe.id)
            // Modal.getOrCreateInstance(`#exampleModal-${props.recipe.id}`).hide()
         } catch (error){
            logger.error(error.Message)
         }
      },
      async removeFavorite(){
         try{
            isFavorite.value = false;
            logger.log("liking", props.recipe.id)
            // logger.log(favoriteId)
            await favoriteService.removeFavorite(favoriteId.value.favoriteId)
         } catch (error){
            logger.error(error.Message)
         }
      },
      async deleteRecipe(){
         try{
            // logger.log("deleting recipe", props.recipe.id)
            await everythingService.nukeRecipe(props.recipe.id);
         } catch (error) {
            logger.error(error.Message)
         }
      },
      editing,
      editable,
      recipeIngredients: computed(() => AppState.ingredients.filter(i => i.recipeId == props.recipe.id)),
      account: computed(() => AppState.account),
      favorites: computed(() => AppState.favorites),
      isFavorite
      };
   },
};
</script>

<style scoped lang="scss">

.modal .modal-body{
   max-height: 50000px;
   overflow-y: auto;
}

* {
border: 0px solid tan;
}
.recipe-card img {
height: 20rem;
}

.recipe-img {
   max-height: 40vw;
   width: 100vw;
   object-fit: cover;
}
.glass {
backdrop-filter: blur(3px);
background-color: rgba(0, 0, 0, 0.345);
}

.modal {
   max-height:600px;
}


</style>
