using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class ProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesByProductID(int productId)
        {
            return await _productImageRepository.GetProductImagesByProductID(productId);
        }
        public async Task AddProductImage(ProductImage productImage)
        {
            await _productImageRepository.AddProductImage(productImage);
        }

        public async Task UpdateProductImage(ProductImage productImage)
        {
            await _productImageRepository.UpdateProductImage(productImage);
        }
    }
}
