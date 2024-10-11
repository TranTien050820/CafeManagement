using Cafe_Management.Application.Services;
using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public APIResult GetAllProducts(Nullable<int> Produc_ID = null)
        {
            APIResult result= new APIResult();
            OdbcConnection conPixelSqlbase = new OdbcConnection();
            try
            {
                conPixelSqlbase.ConnectionString = "DSN=CafeManagement";
                OdbcCommand command = new OdbcCommand();
                conPixelSqlbase.Open();
                command.Connection = conPixelSqlbase;

                string query = "SELECT * FROM DBO.Product";
                if(Produc_ID != null)
                {
                    query += " WHERE Product_Id = " + Produc_ID + "";
                }
                command.CommandText = query;
                DataTable table = new DataTable("Product");
                table.Load(command.ExecuteReader());
                List<Product> Attraction = JsonConvert.DeserializeObject<List<Product>>(JsonConvert.SerializeObject(table));

                result.Status = 200;
                result.Message = "Susseccfully";
                result.Data = Attraction;
                return result;

            }
            catch (Exception ex)
            {
                result.Status = 0;
                result.Message = ex.Message;
                return result;
                
            }
            finally 
            { 
                conPixelSqlbase.Close(); 
            }
        }

        [HttpPost]
        public APIResult PostProducts([FromBody] Product data)
        {
            APIResult result = new APIResult();
            OdbcConnection conPixelSqlbase = new OdbcConnection();
            try
            {
                conPixelSqlbase.ConnectionString = "DSN=CafeManagement";
                OdbcCommand command = new OdbcCommand();
                conPixelSqlbase.Open();
                command.Connection = conPixelSqlbase;

                if(data.Product_Name == null)
                {
                    result.Status = 0;
                    result.Message = "Product name can not be empty!";
                    return result;
                }

                command.CommandText = @"INSERT INTO Product(Product_ID, Product_Category, Product_Name, Price, Point, IsActive, CreatedDate, ModifiedDate)
                                        VALUES(?,?,?,?,?,?,?,?)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("Product_ID", data.Product_ID);
                command.Parameters.AddWithValue("Product_Category", data.Product_Category);
                command.Parameters.AddWithValue("Product_Name", data.Product_Name);
                command.Parameters.AddWithValue("Price", data.Price);
                command.Parameters.AddWithValue("Point", data.Point);
                command.Parameters.AddWithValue("IsActive", data.IsActive);
                command.Parameters.AddWithValue("CreatedDate", data.CreatedDate);
                command.Parameters.AddWithValue("ModifiedDate", data.ModifiedDate);
                command.ExecuteNonQuery();

                result.Status = 200;
                result.Message = "Susseccfully";
                return result;

            }
            catch (Exception ex)
            {
                result.Status = 0;
                result.Message = ex.Message;
                return result;

            }
            finally
            {
                conPixelSqlbase.Close();
            }
        }
    }
}
