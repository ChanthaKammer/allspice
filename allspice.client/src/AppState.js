import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  recipes: [
    {title: "Mac and Cheese", instructions: "Heat some cheese up.", img: "Placeholder", category: "Pasta"},
    {title: "Spaghetti", instructions: "Boil some noodles.", img: "Placeholder", category: "Pasta"},
    {title: "Chicken Alfredo", instructions: "Heat some chicken up.", img: "Placeholder", category: "Pasta"},
    {title: "Chicken Parmesan", instructions: "Heat some chicken and parmesan up.", img: "Placeholder", category: "Pasta"},
    {title: "Chicken Noodle Soup", instructions: "Boil some noodles and chicken.", img: "Placeholder", category: "Soup"}
  ]
})



// public string Title {get;set;}
// public string Instructions {get;set;}
// public string Img {get;set;}
// public string Category {get;set;}