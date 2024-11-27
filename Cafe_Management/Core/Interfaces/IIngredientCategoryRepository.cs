using Cafe_Management.Code;
using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IIngredientCategoryRepository
    {
        Task<IngredientCategory?> GetIngredientCategoryById(int id);
        Task<IEnumerable<IngredientCategory>> GetAllIngredientCategories();
        Task AddIngredientCategory(IngredientCategory category);
        Task UpdateIngredientCategory(IngredientCategory category);

    }
}
