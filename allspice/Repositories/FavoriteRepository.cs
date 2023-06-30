namespace allspice.Repositories;

public class FavoriteRepository
{
   private readonly IDbConnection _db;

   public FavoriteRepository(IDbConnection db){
      _db = db;
   }

   internal Favorite createFavorite(Favorite favoriteData)
   {
      string sql = @"
      INSERT INTO favorites
      (accountId, recipeId)
      VALUES
      (@accountId, @recipeId);
      SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";
      Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
      return favorite;
   }

   internal int DeleteFavorite(int favoriteId)
   {
      string sql = @"
      DELETE FROM favorites
      WHERE id = @favoriteId
      LIMIT 1;";
      int rows = _db.Execute(sql, new {favoriteId});
      return rows;
   }

   internal Favorite GetFavoriteById(int favoriteId)
   {
      string sql = @"
      SELECT 
         favs.*
      FROM favorites favs
      JOIN accounts acc
      ON acc.id = favs.accountId
      WHERE favs.id = @favoriteId;";

      Favorite favorite = _db.Query<Favorite>(sql, 
      new {favoriteId}).FirstOrDefault();
      return favorite;
   }

   internal List<FavoritesAccount> GetFavoritesByRecipeId(int recipeId)
   {
      string sql = @"
      SELECT 
      favs.*,
      acc.*
      FROM favorites favs
      JOIN accounts acc
      ON acc.id = favs.accountId
      WHERE favs.recipeId = @recipeId
      ;";

      List<FavoritesAccount> favorite = _db.Query<FavoritesAccount, Account, FavoritesAccount>(sql, (favorite, account) => {
         favorite.Id = account.Id;
         return favorite;
      }, new {recipeId}).ToList();
      return favorite;
   }

   internal List<FavoriteRecipe> GetMyFavorites(string accountId)
   {
      string sql = @"
      SELECT 
      favs.*,
      rec.*,
      acc.*
      FROM favorites favs
      JOIN recipes rec
         ON rec.id = favs.recipeId
      JOIN accounts acc
         ON acc.id = rec.creatorId
      WHERE favs.accountId = @accountId
      ;";
      List<FavoriteRecipe> favorites = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql, (favorites, recipe, account) => {
         recipe.FavoriteId = favorites.Id;
         recipe.Creator = account;
         return recipe;
      }, new { accountId }).ToList();
      return favorites;
   }
}