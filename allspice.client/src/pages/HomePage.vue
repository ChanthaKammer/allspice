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
          <h1 style="font-size:5em; color: white;">Allspice</h1>
      </div>
    </div>
    <div class="row p-4">
      <FilterBar class="elevation-5"/>
    </div>
  </section>
  <!-- <section class="container-fluid">
      <div class="row bg-dark text-white justify-content-center">
          <div class="col-md-8">
            <div class="row text-center">
                <h1>Filter By Category</h1>
            </div>
            <div class="row justify-content-center bg-light text-dark rounded-3">
                <div class="col-md-3">
                  <h1>Lorem</h1>
                </div>
                <div class="col-md-3">
                  <h1>Lorem</h1>
                </div>
                <div class="col-md-3">
                  <h1>Lorem</h1>
                </div>
            </div>
          </div>
      </div>
  </section> -->
  <!-- to solve the x overflow on this I had to make sure to put the child element inside of a container-fluid -->
  <section class="container-fluid">
    <div class="row justify-content-between">
      <RecipeCard :recipe="r" v-for="r in recipes" :key="r.id"/>
    </div>
  </section>
</template>

<script>
import { AppState } from '../AppState.js';
import { computed, onMounted } from 'vue';
import RecipeCard from '../components/RecipeCard.vue';
import FilterBar from '../components/FilterBar.vue';
import { everythingService } from '../services/EverythingService.js';
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
          logger.log('recipes', AppState.recipes)
        } catch (error) {
          Pop.error(error);
          logger.error(error);
        }
      }
      onMounted(() => {
        GetRecipes();
      })
        return {
          recipes: computed (() => AppState.recipes)
        };
    },
    components: { RecipeCard, FilterBar }
}
</script>

<style scoped lang="scss">
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
