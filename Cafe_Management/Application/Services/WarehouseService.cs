using Cafe_Management.Code;
using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Application.Services
{
    public class WarehouseService
    {

        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public APIResult GetAllWarehouses(int? warehouseId = null)
        {
            return _warehouseRepository.GetAllWarehouses(warehouseId); ;
        }
    }
}
