using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using System.Collections.Generic;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product {Product_ID = 1, Product_Name = "Product 1", Price = 10},
            new Product { Product_ID = 2, Product_Name = "Product 2", Price = 20 }
        };

        public IEnumerable<Product> GetAllProducts() => _products;

        public Product GetProductById(int id) => _products.Find(p => p.Product_ID == id);
    }
}
