using System.Data.Odbc;

namespace Cafe_Management.Infrastructure
{
    public class DBConnect
    {
        OdbcConnection conPixelSqlbase = new OdbcConnection();

        public DBConnect connectDB()
        {
            try{
                conPixelSqlbase.ConnectionString = "DSN=CafeManagement";
                OdbcCommand command = new OdbcCommand();
                conPixelSqlbase.Open();
                command.Connection = conPixelSqlbase;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return this;

        }
    }
}
