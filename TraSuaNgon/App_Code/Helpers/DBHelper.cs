using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["TraSuaNgonConnection"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}