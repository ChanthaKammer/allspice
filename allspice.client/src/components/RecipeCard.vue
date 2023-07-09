<template>
<div class="col-md-4 p-4">
   <div class="d-flex flex-column recipe-card justify-content-center position-relative " type="button" 
      data-bs-toggle="modal"
      :data-bs-target="'#exampleModal-' + recipe.id">
      <img
      :src="recipe.img"
      class="img-fluid object-fit-cover elevation-5"
      :title="recipe.title"/>
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-start"
      >
      <button class="bg-light text-white fs-5">
         <!-- <router-link :to="{ name: 'Recipe', params: {id: recipe.id}}" class="btn text-success lighten-30 selectable text-uppercase">
         </router-link> -->
         <a class="cursor-pointer">View Recipe</a>
      </button>
      </div>
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end p-2"
      >
      <div class="glass p-2 text-white rounded-3 elevation-5">
         <h5>{{ recipe.title }} {{recipe.id}}</h5>
         <h3>{{ recipe.category }}</h3>
      </div>
      </div>
   </div>
</div>
<!--Modal-->
<div
:id="'exampleModal-' + recipe.id" class="modal animate__animated animate__fadeIn animate__fast sticky-top " tabindex="-1" :aria-labelledby="'exampleModalLabel-' + recipe.id" aria-hidden="true" data-bs-scroll="true"
>
   <div class="modal-dialog modal-xl modal-dialog-scrollable">
      <div class="modal-content">
         <div class="d-flex flex-row justify-content-between p-3 fs-5">
            <button
               type="button"
               class="btn-close"
               data-bs-dismiss="modal"
               aria-label="Close"
            ></button>
            <div>
               <i v-if="account.id != recipe.creator.id" class="mdi mdi-delete float-end" style="font-size: 2rem; color:red" role="button"></i>
               <i class="mdi mdi-heart float-end" style="font-size: 2rem" role="button"></i>
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
               </div>
            </div>
            <div class="row justify-content-around p-3">
               {{ ingredients }}
            </div>
         </div>
         <div class="modal-footer d-flex flex-row justify-content-between">
            <div class="d-flex flex-row align-items-center gap-2">
               <img :src="recipe.creator.picture" :alt="recipe.creator.name" class="img-fluid rounded-circle object-fit-cover" style="height: 3rem; width: 3rem;">
               <h4>{{ recipe.creator.name }}</h4>
            </div>
            <button v-if="account.id != recipe.creator.id && !editing" type="button" class="btn btn-success" @click="editing = !editing; console.log(editing)">Edit Recipe</button>
            <button v-if="editing" type="button" class="btn btn-success" @click="editing = !editing; console.log(editing)">Save Changes</button>
         </div>
      </div>
   </div>
</div>
   
</template>

<script>
import Pop from "../utils/Pop.js";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { Recipe } from "../models/Recipe.js";
import { Modal } from "bootstrap";
import { computed, onMounted, ref, watchEffect } from "vue";
import { ingredientService } from "../services/EverythingService.js";
export default {
   props: {
   recipe: { type: Recipe, required: true }
},
setup(props) {
   const ingredients = ref({})
   onMounted(() => {
      getIngredients()
   })
   async function getIngredients(){
      try{
         await ingredientService.getIngredientsByRecipeId(props.recipe.id)
      } catch (error){
         logger.error(error.Message)
      }
   }
   const editing = ref(false);
   const editable = ref();
   watchEffect(() => {
      editable.value = props.recipe;
   })
   return {
      editing,
      editable,
      account: computed(() => AppState.account),
      ingredients: computed(() => AppState.ingredients.filter(i => i.recipeId === props.recipe.id))
      };
   },
};
</script>

<style scoped lang="scss">
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
