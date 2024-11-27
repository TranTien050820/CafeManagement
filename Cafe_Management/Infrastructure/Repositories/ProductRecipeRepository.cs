using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Data.Odbc;
using System.Data;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class ProductRecipeRepository : IProductRecipeRepository
    {
        private readonly string _connectionString = "DSN=CafeManagement";

        public APIResult GetAllRecipeOfProduct(int productID)
        {
            APIResult result = new APIResult();
            try
            {
                using (OdbcConnection con = new OdbcConnection(_connectionString))
                {
                    OdbcCommand command = new OdbcCommand();
                    con.Open();
                    command.Connection = con;

                    string query = @"SELECT * FROM DBO.ProductRecipe ";
                    if (productID != null)
                    {
                        query += "WHERE Product_ID = ?";
                        command.Parameters.AddWithValue("Product_ID", productID);
                    }

                    command.CommandText = query;
                    DataTable table = new DataTable("ProductRecipe");
                    table.Load(command.ExecuteReader());
                    List<ProductRecipe> productRecipe = JsonConvert.DeserializeObject<List<ProductRecipe>>(JsonConvert.SerializeObject(table));

                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = productRecipe;

                }
            }
            catch (Exception ex)
            {
                result.Status = 0;
                result.Message = ex.Message;
            }

            return result;
        }

        public APIResult AddProductRecipe(ProductRecipe _productRecipe)
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
                    command.CommandText = "SELECT MAX(Recipe_ID) FROM DBO.ProductRecipe";
                    int recipeID = (int)command.ExecuteScalar();

                    command.CommandText = @"INSERT INTO ProductRecipe(Recipe_ID, Product_ID, Ingredient_ID, Quantity, Unit, IsActive,CreatedDate, ModifiedDate)
                                            VALUES (?,?,?,?,?,?,?,?)  ";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("Recipe_ID", (recipeID + 1));
                    command.Parameters.AddWithValue("Product_ID", _productRecipe.Product_ID);
                    command.Parameters.AddWithValue("Ingredient_ID", _productRecipe.Ingredient_ID);
                    command.Parameters.AddWithValue("Quantity", _productRecipe.Quantity);
                    command.Parameters.AddWithValue("Unit", _productRecipe.Unit);
                    command.Parameters.AddWithValue("IsActive", true);
                    command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
                    command.ExecuteNonQuery();

                    string query = "SELECT * FROM DBO.ProductRecipe WHERE Product_ID = " + ((_productRecipe.Product_ID) + 1) + "";

                    command.CommandText = query;
                    DataTable table = new DataTable("ProductRecipe");
                    table.Load(command.ExecuteReader());
                    List<ProductRecipe> productRecipes = JsonConvert.DeserializeObject<List<ProductRecipe>>(JsonConvert.SerializeObject(table));

                    odbcTransact.Commit();
                    result.Status = 200;
                    result.Message = "Successfully";
                    result.Data = productRecipes;

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
