using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.Odbc;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository 
    {
        private readonly string _connectionString = "DSN=CafeManagement";

        public APIResult GetAllProductCategories(int? categoryID)
        {
            APIResult result = new APIResult();
            try {
                using (OdbcConnection con = new OdbcConnection(_connectionString))
                {
                    OdbcCommand command = new OdbcCommand();
                    con.Open();
                    command.Connection= con;

                    string query = @"SELECT * FROM DBO.ProductCategory ";
                    if(categoryID != null)
                    {
                        query += "WHERE Category_Id = ?";
                        command.Parameters.AddWithValue("Category_Id", categoryID);
                    }

                    command.CommandText = query;
                    DataTable table = new DataTable("ProductCategory");
                    table.Load(command.ExecuteReader());
                    List<ProductCategory> productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(JsonConvert.SerializeObject(table));

                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = productCategories;

                }
            } 
            catch (Exception ex)
            {
                result.Status = 0;
                result.Message = ex.Message;
            }
            
            return result;
        }


        public APIResult AddProductCategory(ProductCategory category)
        {
            APIResult result = new APIResult();

            using (OdbcConnection con = new OdbcConnection(_connectionString))
            {
                OdbcCommand command = new OdbcCommand();
                con.Open();
                command.Connection= con;

                OdbcTransaction odbcTransact = null;
                try
                {
                    odbcTransact = con.BeginTransaction();
                    command.Transaction = odbcTransact;
                    command.CommandText = "SELECT MAX(Category_ID) FROM DBO.ProductCategory";
                    int CategoryID = (int)command.ExecuteScalar();

                    command.CommandText = @"INSERT INTO ProductCategory(Category_ID,Category_Name, IsActive, CreatedDate, ModifiedDate)
                                           VALUES(?,?,?,?,?)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("Category_ID", (CategoryID + 1));
                    command.Parameters.AddWithValue("Category_Name", category.Category_Name);
                    command.Parameters.AddWithValue("IsActive", category.IsActive);
                    command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
                    command.ExecuteNonQuery();

                    string query = "SELECT * FROM DBO.ProductCategory WHERE Category_ID = " + (CategoryID + 1) + "";

                    command.CommandText = query;
                    DataTable table = new DataTable("ProductCategory");
                    table.Load(command.ExecuteReader());
                    List<ProductCategory> categories = JsonConvert.DeserializeObject<List<ProductCategory>>(JsonConvert.SerializeObject(table));

                    odbcTransact.Commit();
                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = categories;

                }
                catch(Exception ex) {
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


        [HttpPut("Update")]

        public APIResult UpdateProductCategoryName(ProductCategory category)
        {
            APIResult result = new APIResult();
            using(OdbcConnection con = new OdbcConnection(_connectionString))
            {
                OdbcCommand command = new OdbcCommand();
                con.Open();
                command.Connection = con;

                OdbcTransaction odbcTransact = null;
                odbcTransact = con.BeginTransaction();
                try
                {
                   
                    command.Transaction = odbcTransact;
                    command.CommandText = "UPDATE ProductCategory SET Category_Name = ?, ModifiedDate = ? WHERE Category_ID = ? ";
                    command.Parameters.AddWithValue("Category_Name", category.Category_Name);
                    
                    command.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
                    command.Parameters.AddWithValue("Category_ID", category.Category_ID);
                    command.ExecuteNonQuery();

                    DataTable table = new DataTable("ProductCategory");
                    table.Load(command.ExecuteReader());
                    List<ProductCategory> categories = JsonConvert.DeserializeObject<List<ProductCategory>>(JsonConvert.SerializeObject(table));

                    odbcTransact.Commit();
                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = categories;
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
