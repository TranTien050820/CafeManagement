using Cafe_Management.Code;
using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductRecipeRepository
    {
        APIResult GetAllRecipeOfProduct(int productId);
        APIResult AddProductRecipe(ProductRecipe productRecipe);
    }
}
