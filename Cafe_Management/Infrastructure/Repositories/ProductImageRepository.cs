using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _context;

        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesByProductID(int productId)
        {
            return await _context.ProductImage
                .Where(pi => pi.Product_ID == productId).ToListAsync();
        }

        public async Task AddProductImage(ProductImage productImage)
        {
            await _context.ProductImage.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductImage(ProductImage productImage)
        {
            var existingProductImage = await _context.ProductImage
                .FirstOrDefaultAsync(pi => pi.ProductImage_ID == productImage.ProductImage_ID);

            if (existingProductImage != null)
            {
                existingProductImage.Image_URL = productImage.Image_URL;
                existingProductImage.AltText = productImage.AltText;
                await _context.SaveChangesAsync();
            }
        }
    }
}
