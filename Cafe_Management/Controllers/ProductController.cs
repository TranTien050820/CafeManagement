using Cafe_Management.Application.Services;
using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products != null && products.Any()) // Check if products is not null and contains items
            {
                APIResult result = new APIResult
                {
                    Data = products,
                    Message = "Successfully",
                    Status = 200
                };
                return Ok(result);
            }

            // If no products are found, return a NotFound or other relevant status
            return NotFound(new APIResult { Message = "No products found", Status = 404 });

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                await _productService.AddProductAsync(product);

                APIResult result = new APIResult
                {
                    Data = product, // Set the added product as data
                    Message = "Successfully added the product",
                    Status = 200
                };

                // Return the created result with the location of the new resource
                return CreatedAtAction(nameof(GetAllProducts), new { id = product.Product_ID }, result);
            

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
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await _productService.UpdateProductAsync(product);
                APIResult result = new APIResult
                {
                    Data = product, // Set the added product as data
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
