namespace allspice.Repositories;

public class IngredientRepository
{
   private readonly IDbConnection _db;

   public IngredientRepository(IDbConnection db){
      _db = db;
   }

   internal Ingredient createIngredient(Ingredient ingredientData)
   {
      string sql = @"
      INSERT INTO ingredients
      (quantity, name, recipeId)
      VALUES
      (@quantity, @name, @recipeId);
      SELECT * FROM ingredients WHERE id = LAST_INSERT_ID();
      ";

      Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
      return ingredient;
   }

   internal int DeleteIngredient(int ingredientId)
   {
      string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
      int rows = _db.Execute(sql, new {ingredientId});
      return rows;
   }

   internal List<Ingredient> getAllIngredients()
   {
      string sql = "SELECT * FROM ingredients;";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql).ToList();
      return ingredients;
   }

   internal Ingredient GetById(int ingredientId)
   {
      string sql = @"
      SELECT * FROM ingredients 
      WHERE id = @ingredientId;
      ";
      Ingredient ingredient = _db.Query<Ingredient>(sql, new {ingredientId}).FirstOrDefault();
      return ingredient;
   }

   internal List<Ingredient> getIngredientsByRecipeId(int recipeId)
   {
      string sql = @"
      SELECT
      ing.*,
      rcp.*
      FROM ingredients ing
      JOIN recipes rcp ON ing.recipeId = rcp.Id
      WHERE ing.recipeId = @recipeId;
      ";
      List<Ingredient> ingredients = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) => {
      ingredient.recipeId = recipe.Id;
      return ingredient;
   }, new { recipeId }).ToList();
   return ingredients;
   }
}