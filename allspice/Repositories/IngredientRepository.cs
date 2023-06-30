namespace allspice.Repositories;

public class IngredientRepository
{
   private readonly IDbConnection _db;

   public IngredientRepository(IDbConnection db){
      _db = db;
   }

   internal List<Ingredient> getAllIngredients()
   {
      string sql = "SELECT * FROM ingredients;";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql).ToList();
      return ingredients;
   }
}