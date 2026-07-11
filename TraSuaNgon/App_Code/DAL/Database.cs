using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class Database
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["TraSuaNgonConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}