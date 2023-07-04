<template>
  <section class="container-fluid">
    <div class="row">
      <TestCard/>
    </div>
  </section>
<section class="container-fluid">
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
  </section>
  <div class="row">
    <div class="col-md-4 p-5">
        <div class="d-flex text-center flex-column bg-light recipe-card rounded-4">
          <h5>Title</h5>
          <h3>Categories</h3>
          <p>Description</p>
        </div>
    </div>
    <RecipeCard/>
    <div class="col-md-4 recipe-card">

    </div>
  </div>
</template>

<script>
import TestCard from '../components/TestCard.vue';
import { AppState } from '../AppState.js';
import { computed } from 'vue';
import RecipeCard from '../components/RecipeCard.vue';
export default {
    setup() {
        return {
          recipes: computed (() => AppState.recipes)
        };
    },
    components: { TestCard, RecipeCard }
}
</script>

<style scoped lang="scss">
* {
  border: 1px solid green;
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
