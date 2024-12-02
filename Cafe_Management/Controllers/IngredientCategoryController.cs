using Cafe_Management.Application.Services;
using Cafe_Management.Code;
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
            if (ingredientCategories != null && ingredientCategories.Any()) 
            {
                APIResult result = new APIResult
                {
                    Data = ingredientCategories,
                    Message = "Successfully",
                    Status = 200
                };
                return Ok(result);
            }

           
            return NotFound(new APIResult { Message = "No ingredient category found", Status = 404 });
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredientCategory([FromBody] IngredientCategory ingredientCategory)
        {
            try
            {

                await _ingredientCategoryService.AddIngredientCategory(ingredientCategory);
                APIResult result = new APIResult
                {
                    Data = ingredientCategory, // Set the added product as data
                    Message = "Successfully",
                    Status = 200
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResult
                {
                    Message = ex.Message,
                    Status = 400
                });
            }
 
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIngredientCategory([FromBody] IngredientCategory ingredientCategory)
        {
            try
            {
                await _ingredientCategoryService.UpdateIngredientCategory(ingredientCategory);
                APIResult result = new APIResult
                {
                    Data = ingredientCategory,
                    Message = "Successfully added the product",
                    Status = 200
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResult
                {
                    Message = ex.Message,
                    Status = 400
                });
            }
        }


    }
}
