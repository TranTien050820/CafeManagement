using Cafe_Management.Code;
using Cafe_Management.Core.Entities;

namespace Cafe_Management.Core.Interfaces
{
    public interface ISupplierRepository
    {
        APIResult GetAllSuppliers(int? supplierID);

        APIResult AddSupplier(Supplier supplier);

        APIResult UpdateSupplier(Supplier supplier);
    }
}
