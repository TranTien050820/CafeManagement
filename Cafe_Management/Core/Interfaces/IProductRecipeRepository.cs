using Cafe_Management.Code;
using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductRecipeRepository
    {
        Task<IEnumerable<ProductRecipe>> GetAllRecipeByProductID(int id);
        Task AddProductRecipe(ProductRecipe recipe);
        Task UpdateProductRecipe(ProductRecipe productRecipe);
    }
}
