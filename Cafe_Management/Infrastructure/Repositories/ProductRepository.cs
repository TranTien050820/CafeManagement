using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly string _connectionString = "DSN=CafeManagement";

        public APIResult GetAllProducts(int? productId)
        {
            APIResult result = new APIResult();

            try
            {
                using (OdbcConnection con = new OdbcConnection(_connectionString))
                {
                    OdbcCommand command = new OdbcCommand();
                    con.Open();
                    command.Connection = con;

                    string query = @"SELECT * FROM DBO.Product";
                    if (productId != null)
                    {
                        query += " WHERE Product_Id = ?";
                        command.Parameters.AddWithValue("ProductId", productId);
                    }

                    command.CommandText = query;
                    DataTable table = new DataTable("Product");
                    table.Load(command.ExecuteReader());
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(JsonConvert.SerializeObject(table));

                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = products;
                }
            }
            catch (Exception ex)
            {
                result.Status = 0;
                result.Message = ex.Message;
            }
            

            return result;
        }

        public APIResult AddProducts(Product product)
        {
            APIResult result = new APIResult();

            using (OdbcConnection con = new OdbcConnection(_connectionString))
            {
                OdbcCommand command = new OdbcCommand();
                con.Open();
                command.Connection = con;

                OdbcTransaction odbcTransact = null;
                try
                {
                    odbcTransact = con.BeginTransaction();
                    command.Transaction = odbcTransact;
                    command.CommandText = "SELECT MAX(Product_ID) FROM DBO.Product";
                    int ProductID = (int)command.ExecuteScalar();

                    command.CommandText = @"INSERT INTO Product(Product_ID, Product_Category, Product_Name, Price, Point, IsActive, CreatedDate, ModifiedDate)
                                        VALUES(?,?,?,?,?,?,?,?)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("Product_ID", (ProductID + 1));
                    command.Parameters.AddWithValue("Product_Category", product.Product_Category);
                    command.Parameters.AddWithValue("Product_Name", product.Product_Name);
                    command.Parameters.AddWithValue("Price", product.Price);
                    command.Parameters.AddWithValue("Point", product.Point);
                    command.Parameters.AddWithValue("IsActive", product.IsActive);
                    command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
                    command.ExecuteNonQuery();

                    string query = "SELECT * FROM DBO.Product WHERE Product_ID = " + (ProductID + 1) + "";

                    command.CommandText = query;
                    DataTable table = new DataTable("Product");
                    table.Load(command.ExecuteReader());
                    List<Product> Products = JsonConvert.DeserializeObject<List<Product>>(JsonConvert.SerializeObject(table));

                    odbcTransact.Commit();
                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = Products;
                }
                catch (Exception ex)
                {
                    odbcTransact.Rollback();
                    result.Status = 0;
                    result.Message = ex.Message;
                }
                finally
                {
                    con.Close();
                }
                
            }

            return result;
        }
    }
}
