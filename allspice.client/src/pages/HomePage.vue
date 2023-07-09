<template>
  <!-- <section class="container-fluid">
    <div class="row">
      <TestCard/>
    </div>
  </section> -->
  <section class="container-fluid">
    <div class="row position-relative text-center">
      <img src="../assets/img/alt-background.png" alt="All Spice Background Picture" class="header-photo object-fit-cover p-4">
      <div class="position-absolute top-50 start-50 translate-middle fs-5">
          <h1 style="font-size:5em; color: white;" class="">Allspice</h1>
      </div>
    </div>
  </section>
  <section class="container-fluid">
    <div class="row p-4 justify-content-center">
      <FilterBar class="elevation-5 col-md-6"/>
    </div>
  </section>
  <section class="container-fluid d-flex justify-content-center">
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#createRecipeModal" aria-controls="createRecipeModal">
      Create Recipe
    </button>
    <Modal id="createRecipeModal">
      <RecipeForm/>
    </Modal>
  </section>
  <section class="container-fluid">
    <div class="row justify-content-between animate__animated animate__slideInUp animate__fast">
      <RecipeCard :recipe="r" v-for="r in recipes" :key="r.id"/>
    </div>
  </section>
</template>

<script>
import { AppState } from '../AppState.js';
import { computed, onMounted } from 'vue';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeForm from '../components/RecipeForm.vue';
import Modal from '../components/Modal.vue';
import FilterBar from '../components/FilterBar.vue';
import { everythingService, favoriteService } from '../services/EverythingService.js';
// import {Recipe} from '../models/Recipe.js';
import Ingredient from '../models/Ingredient.js';
import Favorite from '../models/Favorite.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
      async function GetRecipes(){
        try {
          await everythingService.getRecipes();
          // logger.log('recipes', AppState.recipes)
        } catch (error) {
          Pop.error(error);
          logger.error(error);
        }
      }
      async function getFavoritesByAccountId(){
        try {
          await favoriteService.getFavoritesByAccountId()
          logger.log('favorites', AppState.favorites)
        } catch(error){
          Pop.error(error);
          logger.error(error);
        }
      }
      onMounted(() => {
        GetRecipes();
        setTimeout(() => {
          getFavoritesByAccountId();
        }, 5000);
      })
        return {
          recipes: computed (() => AppState.recipes),
          appState: computed(() => AppState.ingredients),
          account: computed(() => AppState.account)
        };
    },
    components: { RecipeCard, RecipeForm, FilterBar, Modal }
}
</script>

<style scoped lang="scss">
.modal-backdrop{
  display: none;
}
* {
  border: 0px solid green;
}

.header-photo{
  max-height: 320px;
  top: 50px;
}
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
  
}
</style>
