namespace allspice.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipeController : ControllerBase
{
   private readonly RecipeService _recipeService;
   private readonly IngredientService _ingredientService;
   private readonly Auth0Provider _auth0;

   public RecipeController(RecipeService recipeService, IngredientService ingredientService, Auth0Provider auth0){
      _recipeService = recipeService;
      _ingredientService = ingredientService;
      _auth0 = auth0;
   }

   [HttpGet]
   public ActionResult<List<Recipe>> GetAllRecipes(){
      try{
         List<Recipe> recipes = _recipeService.getAllRecipes();
         return Ok(recipes);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
   [HttpPost]
   [Authorize]
   public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         recipeData.CreatorId = userInfo.Id;
         Recipe recipe = _recipeService.createRecipe(recipeData);
         // return new ActionResult<Recipe>(Ok(recipe));
         return Ok(recipe);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpGet("{recipeId}")]
   public ActionResult<Recipe> GetById(int recipeId){
      try {
         Recipe recipe = _recipeService.GetById(recipeId);
         return Ok(recipe);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpGet("{recipeId}/ingredients")]
   public ActionResult<List<Ingredient>> getIngredientsByRecipeId(int recipeId){
      try {
         List<Ingredient> ingredients = _ingredientService.getIngredientsByRecipeId(recipeId);
         return Ok(ingredients);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
   

   [HttpPut("{recipeId}")]
   [Authorize]
   public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromBody] Recipe updateData){
      try{
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         updateData.Id = recipeId;
         Recipe recipe = _recipeService.UpdateRecipe(updateData, userInfo.Id);
         return Ok(recipe);
         // return Ok(recipe);
      } catch (Exception e) {
         return BadRequest(e.Message);
      }
   }

   [HttpDelete("{recipeId}")]
   [Authorize]
   public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         Recipe recipe = _recipeService.ArchiveRecipe(recipeId, userInfo.Id);
         return Ok(recipe);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}