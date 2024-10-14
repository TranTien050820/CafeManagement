using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using System.Collections.Generic;

namespace Cafe_Management.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public APIResult GetAllProducts(int? productId = null)
        {
            return _productRepository.GetAllProducts(productId); ;
        }

        public APIResult AddProducts(Product product)
        {

            return _productRepository.AddProducts(product); ;
        }
    }
}
