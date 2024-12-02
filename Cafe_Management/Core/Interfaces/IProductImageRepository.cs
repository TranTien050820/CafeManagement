using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetProductImagesByProductID(int productId);

        Task AddProductImage(ProductImage productImage);
        Task UpdateProductImage(ProductImage productImage);
    }
}
