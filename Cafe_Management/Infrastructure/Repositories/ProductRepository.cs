using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using System.Collections.Generic;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0M },
            new Product { Id = 2, Name = "Product 2", Price = 20.0M }
        };

        public IEnumerable<Product> GetAllProducts() => _products;

        public Product GetProductById(int id) => _products.Find(p => p.Id == id);
    }
}
