using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Data.Odbc;
using System.Data;
using Cafe_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRecipeRepository : IProductRecipeRepository
    {
        private readonly AppDbContext _context;

        public ProductRecipeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductRecipe>> GetAllRecipeByProductID(int id)
        {
            return await _context.ProductRecipe
                       .Where(recipe => recipe.Product_ID == id) // Lọc theo ProductId
                       .ToListAsync();
        }

        public async Task AddProductRecipe(ProductRecipe productRecipe)
        {

            // Tìm giá trị ProductID lớn nhất hiện tại
            var maxId = await _context.ProductRecipe.MaxAsync(p => (int?)p.Recipe_ID) ?? 0;

            // Tự động tăng ID cho sản phẩm mới
            productRecipe.Recipe_ID = maxId + 1;
            await _context.ProductRecipe.AddAsync(productRecipe);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductRecipe(ProductRecipe productRecipe)
        {
            var existingProductRecipe = await _context.ProductRecipe.FindAsync(productRecipe.Recipe_ID);
            if (existingProductRecipe != null)
            {
            //        existingProductRecipe.Product_Name = product.Product_Name;
            //        existingProduct.Price = product.Price;
            //        existingProduct.Product_Category = product.Product_Category;
            //        existingProduct.Point = product.Point;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database
                

            }
        }

    }
}
