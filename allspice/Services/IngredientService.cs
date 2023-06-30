namespace allspice.Services;

public class IngredientService{
   private readonly IngredientRepository _repo;

   public IngredientService(IngredientRepository repo){
      _repo = repo;
   }

   internal List<Ingredient> getAllIngredients()
   {
      List<Ingredient> ingredients = _repo.getAllIngredients();
      return ingredients;
   }
}