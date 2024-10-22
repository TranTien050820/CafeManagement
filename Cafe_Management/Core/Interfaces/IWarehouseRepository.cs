using Cafe_Management.Code;

namespace Cafe_Management.Core.Interfaces
{
    public interface IWarehouseRepository
    {
        APIResult GetAllWarehouses(int? warehouseID);
    }
}
