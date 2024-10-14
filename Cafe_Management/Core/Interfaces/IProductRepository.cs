using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductRepository
    {
        APIResult GetAllProducts(int? productId);
        APIResult AddProducts(Product product);
    }
}
