namespace allspice.Services;

public class IngredientService{
   private readonly IngredientRepository _repo;

   public IngredientService(IngredientRepository repo){
      _repo = repo;
   }

   internal Ingredient createIngredient(Ingredient ingredientData)
   {
      Ingredient ingredient = _repo.createIngredient(ingredientData);
      return ingredient;
   }

   internal List<Ingredient> getAllIngredients()
   {
      List<Ingredient> ingredients = _repo.getAllIngredients();
      return ingredients;
   }

   internal List<Ingredient> getIngredientsByRecipeId(int recipeId)
   {
      List<Ingredient> ingredients = _repo.getIngredientsByRecipeId(recipeId);
      return ingredients;
   }
}