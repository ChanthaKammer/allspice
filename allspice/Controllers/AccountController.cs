namespace allspice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;

  private readonly FavoriteService _favoriteService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, FavoriteService favoriteService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _favoriteService = favoriteService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<FavoriteRecipe>> GetFavoriteRecipes(){
    try {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> myFavorites = _favoriteService.getMyFavorites(userInfo.Id);
      return Ok(myFavorites);
    } catch (Exception e){
      return BadRequest(e.Message);
    }
  }
}
