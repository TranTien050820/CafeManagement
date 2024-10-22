using Cafe_Management.Code;
using Cafe_Management.Controllers;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly string _connectString = "DSN=CafeManagement";

        public APIResult GetAllWarehouses(int? warehouseID)
        {
            APIResult result = new APIResult();

            try
            {
                using(OdbcConnection con = new OdbcConnection(_connectString))
                {
                    OdbcCommand command = new OdbcCommand();
                    con.Open();
                    command.Connection= con;

                    string query = "SELECT * FROM DBO.WareHouse";
                    if(warehouseID != null)
                    {
                        query += @"WHERE WareHouse_ID = ?";
                        command.Parameters.AddWithValue("WarehouseId", warehouseID);
                    }

                    command.CommandText= query;
                    DataTable table= new DataTable("WareHouse");
                    table.Load(command.ExecuteReader());
                    List<Warehouse> warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(JsonConvert.SerializeObject(table));

                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = warehouses;
                    
                }
            }
            catch (Exception ex) {
                result.Status = 0;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
