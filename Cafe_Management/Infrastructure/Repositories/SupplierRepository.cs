using Cafe_Management.Code;
using Cafe_Management.Core.Entities;
using Cafe_Management.Core.Interfaces;
using Newtonsoft.Json;
using System.Data.Odbc;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString = "DSN=CafeManagement";
        public  APIResult GetAllSuppliers(int? supplierId) {
            APIResult result = new APIResult();

            try
            {
                using (OdbcConnection con = new OdbcConnection(_connectionString))
                {
                    OdbcCommand command = new OdbcCommand();
                    con.Open();
                    command.Connection = con;

                    string query = @"SELECT * FROM DBO.Suppliers";
                    if (supplierId != null)
                    {
                        query += " WHERE Supplier_Id = ?";
                        command.Parameters.AddWithValue("SupplierId", supplierId);
                    }

                    command.CommandText = query;
                    DataTable table = new DataTable("Suppliers");
                    table.Load(command.ExecuteReader());
                    List<Supplier> products = JsonConvert.DeserializeObject<List<Supplier>>(JsonConvert.SerializeObject(table));

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

        public APIResult AddSupplier(Supplier supplier)
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
                    command.CommandText = "SELECT MAX(Supplier_ID) FROM DBO.Suppliers";
                    int SupplierID = (int)command.ExecuteScalar();

                    command.CommandText = @"INSERT INTO Suppliers(Supplier_ID,Supplier_Name, IsActive, CreatedDate, ModifiedDate)
                                           VALUES(?,?,?,?,?)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("Supplier_ID", (SupplierID + 1));
                    command.Parameters.AddWithValue("Supplier_Name", supplier.Supplier_Name);
                    command.Parameters.AddWithValue("IsActive", true);
                    command.Parameters.AddWithValue("CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("ModifiedDate", DateTime.Now);
                    command.ExecuteNonQuery();

                    string query = "SELECT * FROM DBO.Suppliers WHERE Supplier_ID = " + (SupplierID + 1) + "";

                    command.CommandText = query;
                    DataTable table = new DataTable("Supplier");
                    table.Load(command.ExecuteReader());
                    List<Supplier> categories = JsonConvert.DeserializeObject<List<Supplier>>(JsonConvert.SerializeObject(table));

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

        [HttpPut]
        public APIResult UpdateSupplier(Supplier supplier)
        {
            APIResult result = new APIResult();
            using (OdbcConnection con = new OdbcConnection(_connectionString))
            {
                OdbcCommand command = new OdbcCommand();
                con.Open();
                command.Connection = con;

                OdbcTransaction odbcTransact = null;
                odbcTransact = con.BeginTransaction();
                try
                {

                    command.Transaction = odbcTransact;

                    string query = "UPDATE Suppliers SET ModifiedDate = '" + supplier.ModifiedDate + "' ";

                    if (supplier.Supplier_Name != null)
                    {
                        query += " ,Supplier_Name = N'" + supplier.Supplier_Name + "' ";

                    }
                    if (supplier.IsActive != null)
                    {
                        query += " ,IsActive = '" + supplier.IsActive + "' ";
                    }
                    query += "  WHERE Supplier_ID = " + supplier.Supplier_ID;
                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    DataTable table = new DataTable("Suppliers");
                    table.Load(command.ExecuteReader());
                    List<Supplier> categories = JsonConvert.DeserializeObject<List<Supplier>>(JsonConvert.SerializeObject(table));

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
