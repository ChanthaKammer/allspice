<template>
  <header>
    <Navbar />
  </header>
  <main class="bg-tan">
    <router-view />
  </main>
  <link
    rel="stylesheet"
    href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"
  />
    <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>

<RecipeDetailsModal/>

</template>


<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'


export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}

.bg-tan{
  background-color: tan;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
