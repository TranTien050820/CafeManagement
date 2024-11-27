using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class ProductRecipeService
    {
        private readonly IProductRecipeRepository _productRecipeRepository;

        public ProductRecipeService(IProductRecipeRepository productRecipeRepository)
        {
            _productRecipeRepository = productRecipeRepository;
        }

        public APIResult GetllRecipeOfProduct(int productId)
        {
            var result = _productRecipeRepository.GetAllRecipeOfProduct(productId);
            return result;
        }

        public APIResult AddProductRecipe(ProductRecipe productRecipe)
        {
            return _productRecipeRepository.AddProductRecipe(productRecipe);
        }

    }
}
