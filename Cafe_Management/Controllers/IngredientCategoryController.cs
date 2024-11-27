using Cafe_Management.Application.Services;
using Cafe_Management.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Cafe_Management.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientCategoryController :ControllerBase
    {
        private readonly IngredientCategoryService _ingredientCategoryService; 
        public IngredientCategoryController(IngredientCategoryService ingredientCategoryService) {
            _ingredientCategoryService= ingredientCategoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllIngredientCategories()
        {
            var ingredientCategories = await _ingredientCategoryService.GetAllIngredientCategories();
            return Ok(ingredientCategories);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientCategory([FromBody] IngredientCategory ingredientCategory)
        {
            try
            {

                await _ingredientCategoryService.AddIngredientCategory(ingredientCategory);
                return CreatedAtAction(nameof(GetAllIngredientCategories), new { id = ingredientCategory.Ingredient_Category_ID }, ingredientCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIngredientCategory([FromBody] IngredientCategory ingredientCategory)
        {
            try
            {
                await _ingredientCategoryService.UpdateIngredientCategory(ingredientCategory);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
