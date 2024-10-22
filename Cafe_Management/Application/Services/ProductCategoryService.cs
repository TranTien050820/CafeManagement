using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class ProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public APIResult GetAllProductCategories(int? categoryID)
        {
            return _productCategoryRepository.GetAllProductCategories(categoryID);
        }

        public APIResult AddProductCategory(ProductCategory category)
        {
            return _productCategoryRepository.AddProductCategory(category);
        }

        public APIResult UpdateProductCategoryName(ProductCategory category)
        {
            return _productCategoryRepository.UpdateProductCategoryName(category);
        }
    }
}
