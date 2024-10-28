using Cafe_Management.Code;
using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface IProductCategoryRepository
    {
        APIResult GetAllProductCategories(int? categoryID);

        APIResult AddProductCategory(ProductCategory  category);

        APIResult UpdateProductCategoryName(ProductCategory category);


    }
}
