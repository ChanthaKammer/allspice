namespace allspice.Services;

public class IngredientService{
   private readonly IngredientRepository _repo;
   private readonly RecipeService _recipeService;

   public IngredientService(IngredientRepository repo, RecipeService recipeService)
   {
      _repo = repo;
      _recipeService = recipeService;
   }


   internal Ingredient createIngredient(Ingredient ingredientData)
   {
      Ingredient ingredient = _repo.createIngredient(ingredientData);
      return ingredient;
   }

   internal void DeleteIngredient(int ingredientId, string userId)
   {
      Ingredient ingredient = GetById(ingredientId);
      Recipe recipe = _recipeService.GetById(ingredient.recipeId);
      if(userId != recipe.CreatorId) throw new Exception($"You do not have permission to delete ingredient: ${ingredientId}");
      int rows = _repo.DeleteIngredient(ingredientId);
      if(rows > 1) throw new Exception("YOU DELETED TOO MANY ROWS");
   }

   internal List<Ingredient> getAllIngredients()
   {
      List<Ingredient> ingredients = _repo.getAllIngredients();
      return ingredients;
   }
   internal Ingredient GetById(int ingredientId){
      Ingredient ingredient = _repo.GetById(ingredientId);
      if(ingredient == null) throw new Exception($"No ingredient found with id: {ingredientId}.");
      return ingredient;
   }

   internal List<Ingredient> getIngredientsByRecipeId(int recipeId)
   {
      List<Ingredient> ingredients = _repo.getIngredientsByRecipeId(recipeId);
      return ingredients;
   }
}