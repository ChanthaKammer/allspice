namespace allspice.Repositories;

public class RecipeRepository {
   private readonly IDbConnection _db;
   public RecipeRepository(IDbConnection db){
      _db = db;
   }

   internal Recipe createRecipe(Recipe recipeData)
   {
      string sql = @"
      INSERT INTO recipes
      (title, instructions, img, category, archived, creatorId)
      VALUES
      (@title, @instructions, @img, @category, @archived, @creatorId);

      SELECT rcp.*,
      creator.*

      FROM recipes rcp
      JOIN accounts creator ON rcp.creatorId = creator.id
      WHERE rcp.id = LAST_INSERT_ID();
      ";

      Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => {
         recipe.Creator = creator;
         return recipe;
      }, recipeData).FirstOrDefault(); 
      return recipe;
   }

   internal int DeleteRecipe(int recipeId)
   {
      string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
      int rows = _db.Execute(sql, new {recipeId});
      return rows;
   }

   internal List<Recipe> getAllRecipes()
   {
      string sql = @"
      SELECT rcp.*,
      creator.*

      FROM recipes rcp
      JOIN accounts creator ON rcp.creatorId = creator.id";
      List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => {
         recipe.Creator = creator;
         return recipe;
      }).ToList();
      return recipes;
   }

   internal Recipe GetById(int recipeId)
   {
      string sql = @"
      SELECT rcp.*,
      creator.*

      FROM recipes rcp
      JOIN accounts creator ON rcp.creatorId = creator.id
      WHERE rcp.id = @recipeId;
      ";
      Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => {
         recipe.Creator = creator;
         return recipe;
      }, new {recipeId}).FirstOrDefault();
      return recipe;
   }

   internal void UpdateRecipe(Recipe updateData)
   {
      string sql = @"
      UPDATE recipes SET
      title = @title,
      instructions = @instructions,
      img = @img,
      category = @category
      WHERE id = @id;
      ";
      _db.Execute(sql, updateData);
   }
}

