import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  favoritess: [],

  // recipes: [
  //   {id: 1, title: "Mac and Cheese", instructions: "Heat some cheese up.", img: "Placeholder", category: "Pasta"},
  //   {id: 2, title: "Spaghetti", instructions: "Boil some noodles.", img: "Placeholder", category: "Pasta"},
  //   {id: 3, title: "Chicken Alfredo", instructions: "Heat some chicken up.", img: "Placeholder", category: "Pasta"},
  //   {id: 4, title: "Chicken Parmesan", instructions: "Heat some chicken and parmesan up.", img: "Placeholder", category: "Pasta"},
  //   {id: 5, title: "Chicken Noodle Soup", instructions: "Boil some noodles and chicken.", img: "Placeholder", category: "Soup"},
  //   {id: 6, title: "French Onion Soup", instructions: "Caramelize some onions.", img: "Placeholder", category: "Soup"}
  // ]
  recipes : [],
  ingredients: []
})



// public string Title {get;set;}
// public string Instructions {get;set;}
// public string Img {get;set;}
// public string Category {get;set;}