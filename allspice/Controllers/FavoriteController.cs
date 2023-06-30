namespace allSpice.Controllers;

[ApiController]
[Route("api/favorites")]

public class FavoriteController : ControllerBase
{
   private readonly FavoriteService _favoriteService;
   private readonly Auth0Provider _auth0;

   public FavoriteController(FavoriteService favoriteService, Auth0Provider auth0){
      _favoriteService = favoriteService;
      _auth0 = auth0;
   }

   [HttpPost]
   [Authorize]
   public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData){
      try{
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         favoriteData.AccountId = userInfo.Id;
         Favorite favorite = _favoriteService.createFavorite(favoriteData);
         return Ok(favorite);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
   [HttpDelete("{favoriteId}")]
   [Authorize]
   public async Task<ActionResult<Favorite>> DeleteFavorite(int favoriteId){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         _favoriteService.DeleteFavorite(favoriteId, userInfo.Id);
         return Ok("Favorite Delorted");
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}