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

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAllProducts();
        public Product GetProductById(int id) => _productRepository.GetProductById(id);
    }
}
