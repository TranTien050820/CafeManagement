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
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryController(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProductCategories()
        {
            var category = await _productCategoryService.GetAllProductCategories();
            if (category != null && category.Any()) 
            {
                APIResult result = new APIResult
                {
                    Data = category,
                    Message = "Successfully",
                    Status = 200
                };
                return Ok(result);
            }

            // If no products are found, return a NotFound or other relevant status
            return NotFound(new APIResult { Message = "No categories found", Status = 404 });
        }

        [HttpPost]

        public async Task<IActionResult> AddProductCategory([FromBody] ProductCategory category)
        {
            try
            {

                await _productCategoryService.AddProductCategory(category);
                return CreatedAtAction(nameof(GetAllProductCategories), new { id = category.Category_ID }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory([FromBody] ProductCategory category)
        {
            try
            {
                await _productCategoryService.UpdateProductCategory(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
