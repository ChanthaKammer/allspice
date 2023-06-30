namespace allspice.Services;

public class FavoriteService{
   private readonly FavoriteRepository _repo;

   public FavoriteService(FavoriteRepository repo){
      _repo = repo;
   }

   internal Favorite createFavorite(Favorite favoriteData)
   {
      Favorite favorite = _repo.createFavorite(favoriteData);
      return favorite;
   }

   internal List<FavoriteRecipe> getMyFavorites(string accountId)
   {
      List<FavoriteRecipe> myFavorites = _repo.GetMyFavorites(accountId);
      return myFavorites;
   }

   internal Favorite GetFavoriteById(int favoriteId)
   {
      Favorite favorite = _repo.GetFavoriteById(favoriteId);
      if(favorite == null){
         throw new Exception("Invalid favorite Id");
      }
      return favorite;
   }

   internal void DeleteFavorite(int favoriteId, string userId)
   {
      Favorite favoriteToDelete = GetFavoriteById(favoriteId);
      if(favoriteToDelete == null){
         throw new Exception("Invalid Favorite");
      }
      if(favoriteToDelete.AccountId != userId){
         throw new Exception("NACHO FAVORITE");
      }
      int row = _repo.DeleteFavorite(favoriteId);
      if(row > 1){
         throw new Exception("check your db bb");
      }
   }

   internal List<FavoritesAccount> GetFavoritesByRecipeId(int recipeId)
   {
     return _repo.GetFavoritesByRecipeId(recipeId);
   }
}