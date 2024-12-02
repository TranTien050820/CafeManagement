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
    public class ProductRecipeController : ControllerBase
    {
        private readonly ProductRecipeService _productRecipeService;

        public ProductRecipeController(ProductRecipeService productRecipeService)
        {
            _productRecipeService = productRecipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipeByProductID(int id)
        {
            var products = await _productRecipeService.GetAllRecipeByProductID(id);

                APIResult result = new APIResult
                {
                    Data = products,
                    Message = "Successfully get recipes " + id,
                    Status = 200
                };
                return Ok(result);
         

        }

        [HttpPost]
        public async Task<IActionResult> AddProductRecipe([FromBody] ProductRecipe productRecipe)
        {
            try
            {
                await _productRecipeService.AddProductRecipe(productRecipe);

                APIResult result = new APIResult
                {
                    Data = productRecipe, // Set the added product as data
                    Message = "Successfully added the product recipe",
                    Status = 200
                };

                // Return the created result with the location of the new resource
                return CreatedAtAction(nameof(AddProductRecipe), new { id = productRecipe.Recipe_ID }, result);


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
        public async Task<IActionResult> UpdateProductRecipe([FromBody] ProductRecipe productRecipe)
        {
            try
            {
                await _productRecipeService.UpdateProductRecipe(productRecipe);
                APIResult result = new APIResult
                {
                    Data = productRecipe, // Set the added product as data
                    Message = "Successfully added the product recipe",
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
