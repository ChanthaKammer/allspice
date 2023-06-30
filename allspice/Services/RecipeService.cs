namespace allspice.Services;

public class RecipeService{
   private readonly RecipeRepository _repo;

   public RecipeService(RecipeRepository repo){
      _repo = repo;
   }

   internal Recipe ArchiveRecipe(int recipeId, string userId)
   {
      Recipe recipe = GetById(recipeId);
      if(recipe.CreatorId != userId){
         throw new Exception($"You are not allowed to delete recipe:{recipeId}");
      }
      // recipe.Archived = !recipe.Archived;
      // _repo.UpdateRecipe(recipe);
      int rows = _repo.DeleteRecipe(recipeId);
      if(rows > 1) throw new Exception("YOU DELETED TOO MANY ROWS");
      return recipe;
   }

   internal Recipe createRecipe(Recipe recipeData)
   {
      Recipe recipe = _repo.createRecipe(recipeData);
      return recipe;
   }

   internal List<Recipe> getAllRecipes()
   {
      List<Recipe> recipes = _repo.getAllRecipes();
      return recipes;
   }

   internal Recipe GetById(int recipeId)
   {
      Recipe recipe = _repo.GetById(recipeId);
      if(recipe == null) throw new Exception($"No recipe found with id: {recipeId}");
      return recipe;
   }

   internal Recipe UpdateRecipe(Recipe updateData, string userId)
   {
      Recipe original = GetById(updateData.Id);
      if(original.CreatorId != userId){
         throw new Exception($"You are not allowed to delete recipe:{updateData.Id}");
      }
      original.Title = updateData.Title != null ? updateData.Title : original.Title;
      original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
      original.Img = updateData.Img != null ? updateData.Img : original.Img;
      original.Category = updateData.Category != null ? updateData.Category : original.Category;
      _repo.UpdateRecipe(original);
      return original;
   }
}
