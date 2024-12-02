using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Cafe_Management.Infrastructure.Repositories;

namespace Cafe_Management.Application.Services
{
    public class ProductRecipeService
    {
        private readonly IProductRecipeRepository _productRecipeRepository;

        public ProductRecipeService(IProductRecipeRepository productRecipeRepository)
        {
            _productRecipeRepository = productRecipeRepository;
        }

        public async Task<IEnumerable<ProductRecipe>> GetAllRecipeByProductID(int id)
        {
            return await _productRecipeRepository.GetAllRecipeByProductID(id);
        }


        public async Task AddProductRecipe(ProductRecipe productRecipe)
        {


            await _productRecipeRepository.AddProductRecipe(productRecipe);
        }

        public async Task UpdateProductRecipe(ProductRecipe productRecipe)
        {
            await _productRecipeRepository.UpdateProductRecipe(productRecipe);
        }


    }
}
