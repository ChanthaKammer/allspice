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
      logger.log("GET RECIPES", res.data);
      AppState.recipes = res.data.map(r => new Recipe(r));
      // logger.log(AppState.recipes);
   }
}

class IngredientService {
   async getIngredientsByRecipeId(recipeId) {
      const res = await api.get(`api/recipes/${recipeId}/ingredients`);
      AppState.ingredients = res.data.map( i => {
         new Ingredient(i);
      });
   }
}

class FavoriteService {
   async getFavoritesByAccountId(accountId) {
      const res = await api.get(`api/accounts/${accountId}/favorites`);
      AppState.favorites = res.data;
   }
}

export const everythingService = new EverythingService();

export const ingredientService = new IngredientService();

export const favoriteService = new FavoriteService();

// import { AppState } from "../AppState.js"
// import { logger } from "../utils/Logger.js"
// import { api } from "./AxiosService.js"
// import { TowerEvent } from "../models/TowerEvent.js"

// class TowerEventService{
//    async getTowerEvents(){
//       const res = await api.get('api/events')
//       // logger.log(res.data)
//       AppState.TowerEvents = res.data.map(t => new TowerEvent(t))
//       // logger.log(AppState.TowerEvents)
//    }
//    async filterEvents(type){
//       // logger.log(type)
//       AppState.TowerEvents = AppState.TowerEvents.filter(t => t.type == type)
//       // logger.log(AppState.TowerEvents)
//    }
//    async getEventById(id){
//       const res = await api.get(`api/events/${id}`)
//       // logger.log(res.data)
//       AppState.activeTowerEvent = new TowerEvent(res.data)
//       logger.log(AppState.activeTowerEvent)
//       // logger.log("account",AppState.account)
//    }
//    async createEvent(editable){
//       const res = await api.post(`api/events`, editable)
//       logger.log(editable)
//       return res.data
//    }
//    async cancelEvent(eventId){
//       logger.log("cancelled event", eventId)
//       const res = await api.delete(`api/events/${eventId}`)
//       AppState.activeTowerEvent.isCanceled = !AppState.activeTowerEvent.isCanceled;
//    }
// }

// export const towerEventService = new TowerEventService()
