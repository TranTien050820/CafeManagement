using Cafe_Management.Application.Services;
using Cafe_Management.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cafe_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly ProductImageService _productImageService;

        public ProductImageController(ProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetImagesByProductId(int productId)
        {
            var images = await _productImageService.GetProductImagesByProductID(productId);
            if (images == null || !images.Any())
            {
                return NotFound("No images found for the specified product.");
            }
            return Ok(images);
        }

        // Thêm mới ProductImage
        [HttpPost]
        public async Task<IActionResult> AddProductImage([FromBody] ProductImage productImage)
        {
            if (productImage == null)
            {
                return BadRequest("Invalid ProductImage data.");
            }

            await _productImageService.AddProductImage(productImage);
            return Ok("ProductImage added successfully.");
        }

        // Cập nhật ProductImage
        [HttpPut("{productImageId}")]
        public async Task<IActionResult> UpdateProductImage(int productImageId, [FromBody] ProductImage productImage)
        {
            if (productImage == null || productImage.ProductImage_ID != productImageId)
            {
                return BadRequest("Invalid ProductImage data.");
            }

            await _productImageService.UpdateProductImage(productImage);
            return Ok("ProductImage updated successfully.");
        }
    }

}
