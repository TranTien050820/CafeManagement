using Cafe_Management.Application.Services;
using Cafe_Management.Core.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Cafe_Management.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController :ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SupplierController (SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers(int? supplierId) {
            var result = _supplierService.GetAllSuppliers(supplierId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            var result = _supplierService.AddSupplier(supplier);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSupplier(Supplier supplier) { 
            var result = _supplierService.UpdateSupplier(supplier);
            return Ok(result);
        }
    }
}
