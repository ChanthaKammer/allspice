import { AppState } from "../AppState.js";
import { Account } from "../models/Account.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Recipe } from "../models/Recipe.js";
import Ingredient from "../models/Ingredient.js";

//SECTION - RECIPES

class EverythingService {
   async getRecipes() {
      const res = await api.get('api/recipes');
      // logger.log("GET RECIPES", res.data);
      AppState.recipes = res.data.map(r => new Recipe(r));
      // logger.log(AppState.recipes);
   }

   async getRecipeById(recipeId){
      // console.log("Getting recipe by", recipeId);
      const res = await api.get('api/recipes/'+ recipeId)
      AppState.activeRecipe = new Recipe(res.data);
      console.log(res.data);
   }
   async filterRecipes(query){
      if(query == 'mine'){
         // this.getRecipes();
         AppState.recipes = AppState.recipes.filter(r => r.creatorId == AppState.account.id);
      }
      if(query == 'favorites'){
         AppState.recipes = AppState.favorites;
      }
   }

   async createRecipe(recipeData){
      const res = await api.post('api/recipes', recipeData);
      AppState.recipes.push(new Recipe(res.data));
      logger.log("Creating recipe", recipeData);
   }

   async nukeRecipe(recipeId){
      const res = await api.delete(`api/recipes/${recipeId}`);
      AppState.recipes = AppState.recipes.filter(r => r.id != recipeId);
      logger.log("Deleting recipe", recipeId, res.data);
   }
}


//SECTION INGREDIENTS
class IngredientService {
   async getIngredientsByRecipeId(recipeId) {
      const res = await api.get(`api/recipes/${recipeId}/ingredients`);
      // AppState.ingredients = res.data.map(i => {
      //    new Ingredient(i);
      // });
      if (res.data.length > 0) {
         const ingredients = res.data.map(i => new Ingredient(i));
         AppState.ingredients.push(...ingredients);
      }
      // console.log(AppState.ingredients)
      // console.log("get ingredients by recipe id", recipeId,  res.data);
      // console.log(AppState.ingredients);
   }
   async addIngredient(ingredientData) {
      const res = await api.post('api/ingredients', ingredientData);
      AppState.ingredients.push(new Ingredient(res.data));
      logger.log("Adding ingredient", ingredientData);
   }
   async deleteIngredient(ingredientId){
      const res = await api.delete(`api/ingredients/${ingredientId}`);
      AppState.ingredients = AppState.ingredients.filter(i => i.id != ingredientId);
      logger.log("Deleting ingredient", ingredientId);
   }
}

//SECTION FAVORITES
class FavoriteService {
   async getFavoritesByAccountId() {
      const res = await api.get("account/favorites");
      AppState.favorites = res.data;
      logger.log(AppState.favorites)
   }
   async addFavorite(recipeId) {
      const res = await api.post('api/favorites', { recipeId: recipeId });
      this.getFavoritesByAccountId();
      console.log("Adding favorite", recipeId);
   }
   async removeFavorite(favoriteId){
      const res = await api.delete(`api/favorites/${favoriteId}`)
      this.getFavoritesByAccountId();
      console.log("Removing favorite", favoriteId)
   }
}

export const everythingService = new EverythingService();

export const ingredientService = new IngredientService();

export const favoriteService = new FavoriteService();

