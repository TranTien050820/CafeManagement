using Cafe_Management.Application.Services;
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

        public IActionResult GetAllProductCategories(int? categoryID)
        {
            var result = _productCategoryService.GetAllProductCategories(categoryID);
            return Ok(result);
        }

        [HttpPost]

        public IActionResult AddProductCategory(ProductCategory category)
        {
            var result = _productCategoryService.AddProductCategory(category);
            return Ok(result);
        }

        [HttpPut("Update")]

        public IActionResult UpdateProductCategoryName(ProductCategory category) {
            var result = _productCategoryService.UpdateProductCategoryName(category);
            return Ok(result);
        }

       
    }
}
