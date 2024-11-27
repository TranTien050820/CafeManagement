using Cafe_Management.Application.Services;
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
        public IActionResult GetAllRecipeOfProduct(int productID)
        {
            var result = _productRecipeService.GetllRecipeOfProduct(productID);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProductRecipe(ProductRecipe productRecipe)
        {
            var result = _productRecipeService.AddProductRecipe(productRecipe);
            return Ok(result);
        }
    }
}
