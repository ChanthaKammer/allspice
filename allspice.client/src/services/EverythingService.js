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
}

//SECTION FAVORITES
class FavoriteService {
   async getFavoritesByAccountId() {
      const res = await api.get("account/favorites");
      AppState.favorites = res.data;
      logger.log(AppState.favorites)
   }
   async createFavorite(recipeId) {
      const res = await api.post('api/favorites', recipeId);
   }
}

export const everythingService = new EverythingService();

export const ingredientService = new IngredientService();

export const favoriteService = new FavoriteService();

