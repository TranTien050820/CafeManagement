using Cafe_Management.Application.Services;
using Cafe_Management.Code;
using Cafe_Management.Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Cafe_Management.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public IActionResult GetAllWarehouses(int? WarehouseID)
        {
            var result = _warehouseService.GetAllWarehouses(WarehouseID);
            return Ok(result);

        }

    }
}
