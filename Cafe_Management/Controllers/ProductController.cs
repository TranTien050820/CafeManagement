using Cafe_Management.Application.Services;
using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productService;

        public ProductController(IProductRepository productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts(int? productId = null)
        {
            var result = _productService.GetAllProducts(productId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            var result = _productService.AddProducts(product);
            return Ok(result);
        }
    }
}
