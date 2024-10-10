using Cafe_Management.Core.Entities;
using System.Collections.Generic;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
