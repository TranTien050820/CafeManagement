using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Repositories;

namespace Cafe_Management.Application.Services
{
    public class IngredientCategoryService 
    {
        private readonly IIngredientCategoryRepository _ingredientCategoryRepository;

        public IngredientCategoryService(IIngredientCategoryRepository ingredientCategoryRepository)
        {
            _ingredientCategoryRepository= ingredientCategoryRepository;
        }
        public async Task<IEnumerable<IngredientCategory>> GetAllIngredientCategories()
        {
            return await _ingredientCategoryRepository.GetAllIngredientCategories();
        }

        public async Task<IngredientCategory?> GetIngredientCategoryById(int id)
        {
            return await _ingredientCategoryRepository.GetIngredientCategoryById(id);
        }
        public async Task AddIngredientCategory(IngredientCategory ingredientCategory)
        {


            await _ingredientCategoryRepository.AddIngredientCategory(ingredientCategory);
        }

        public async Task UpdateIngredientCategory(IngredientCategory ingredientCategory)
        {
            await _ingredientCategoryRepository.UpdateIngredientCategory(ingredientCategory);
        }

    }
}
