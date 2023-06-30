namespace allspice.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientController : ControllerBase
{
   private readonly IngredientService _ingredientService;
   private readonly Auth0Provider _auth0;

   public IngredientController(IngredientService ingredientService, Auth0Provider auth0){
      _ingredientService = ingredientService;
      _auth0 = auth0;
   }

   [HttpGet]
   public ActionResult<List<Ingredient>> GetAllIngredients(){
      try {
         List<Ingredient> ingredients = _ingredientService.getAllIngredients();
         return Ok(ingredients);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpPost]
   [Authorize]
   public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         Ingredient ingredient = _ingredientService.createIngredient(ingredientData);
         return Ok(ingredient);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}