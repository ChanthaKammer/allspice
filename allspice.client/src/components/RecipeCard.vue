<template>
<div class="col-md-4 p-4">
   <div class="d-flex flex-column recipe-card justify-content-center position-relative " type="button" 
      data-bs-toggle="modal"
      :data-bs-target="'#exampleModal-' + recipe.id">
      <img
      :src="recipe.img"
      class="img-fluid object-fit-cover elevation-5"
      :title="recipe.title"/>
   <!-- <div class="d-flex flex-column recipe-card justify-content-center position-relative">
   <img
   :src="recipe.img"
   class="img-fluid object-fit-cover elevation-5"
   :title="recipe.title"/> -->
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-start"
      >
      <button class="bg-light text-white fs-5">
         <router-link :to="{ name: 'Recipe', params: {id: recipe.id}}" class="btn text-success lighten-30 selectable text-uppercase">
            <a class="cursor-pointer">View Recipe</a>
         </router-link>
      </button>
      </div>
      <div
      class="position-absolute top-0 start-0 w-100 h-100 d-flex flex-column justify-content-end p-2"
      >
      <div class="glass p-2 text-white rounded-3 elevation-5">
         <h5>{{ recipe.title }}</h5>
         <h3>{{ recipe.category }}</h3>
      </div>
      </div>
   </div>
</div>
   <!-- Button trigger modal -->
   <!-- <button
      type="button"
      class="btn btn-primary"
      data-bs-toggle="modal"
      data-bs-target="#exampleModal"
   >
      Launch demo modal
   </button> -->

   <!-- Modal -->
   <div
   :id="'exampleModal-' + recipe.id" class="modal fade sticky-top" tabindex="-1" :aria-labelledby="'exampleModalLabel-' + recipe.id" aria-hidden="true"
   >
      <div class="modal-dialog modal-lg modal-dialog-scrollable">
         <div class="modal-content">
            <div class="d-flex flex-row justify-content-between p-3 fs-5">
               <button
                  type="button"
                  class="btn-close"
                  data-bs-dismiss="modal"
                  aria-label="Close"
               ></button>
               <i class="mdi mdi-heart float-end" style="font-size: 2rem" role="button"></i>
            </div>
            <div class="modal-header container-fluid">
               <div class="row justify-content-around p-3">
                  <div class="col-md-4">
                     <img :src="recipe.img" alt="" class="img-fluid rounded-4 recipe-img">
                  </div>
                  <div class="col-md-6">
                     <div class="d-flex flex-row justify-content-between">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">{{ recipe.title }}</h1>
                        <h1 class="modal-title fs-5 text-success" id="exampleModalLabel">{{ recipe.category }}</h1>
                     </div>
                     <p> {{ recipe.instructions }} </p>
                  </div>
               </div>
            </div>
            <div class="modal-footer d-flex flex-row justify-content-between">
               <div class="d-flex flex-row align-items-center gap-2">
                  <img :src="recipe.creator.picture" :alt="recipe.creator.name" class="img-fluid rounded-circle object-fit-cover" style="height: 3rem; width: 3rem;">
                  <h4>{{ recipe.creator.name }}</h4>
               </div>
               <button v-if="account.id != recipe.creator.id" type="button" class="btn btn-success">Edit Recipe</button>
               <!-- <button
                  type="button"
                  class="btn btn-secondary"
                  data-bs-dismiss="modal"
               >
                  Close
               </button> -->
               <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
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
import { computed } from "vue";
export default {
props: {
   recipe: { type: Recipe, required: true },
},
setup() {
   return {
      account: computed(() => AppState.account)
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


</style>
