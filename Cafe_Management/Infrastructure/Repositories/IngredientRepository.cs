using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Odbc;
using System.Data;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class IngredientRepository: IIngredientRepository
    {
        private readonly AppDbContext _context;

        public IngredientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient?> GetIngredientById(int id)
        {
            return await _context.Ingredient.FindAsync(id);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _context.Ingredient.ToListAsync();
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            ingredient.CreatedDate = DateTime.Now;
            ingredient.ModifiedDate = DateTime.Now;

            // Tìm giá trị ProductID lớn nhất hiện tại
            var maxId = await _context.Ingredient.MaxAsync(p => (int?)p.Ingredient_ID) ?? 0;

            // Tự động tăng ID cho sản phẩm mới
            ingredient.Ingredient_ID = maxId + 1;
            await _context.Ingredient.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateIngredient(Ingredient ingredient)
        {
            var existingIngredient = await _context.Ingredient.FindAsync(ingredient.Ingredient_ID);
            if (existingIngredient != null)
            {
                if (ingredient.IsActive != null)
                {
                    existingIngredient.IsActive = ingredient.IsActive;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database
                    return;
                }
                if (ingredient.IsActive == null)
                {
                    existingIngredient.Ingredient_Name = ingredient.Ingredient_Name;
                    existingIngredient.Ingredient_Category = ingredient.Ingredient_Category;
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào database
                }

            }
        }
    }
}
