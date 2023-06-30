namespace allspice.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientController : ControllerBase
{
   private readonly IngredientService _ingredientService;

   public IngredientController(IngredientService ingredientService){
      _ingredientService = ingredientService;
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
}