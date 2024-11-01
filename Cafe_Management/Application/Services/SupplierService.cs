using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class SupplierService 
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public APIResult GetAllSuppliers(int? supplierId)
        {
            return _supplierRepository.GetAllSuppliers(supplierId);
        }

        public APIResult AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public APIResult UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);    
        }
    }
}
