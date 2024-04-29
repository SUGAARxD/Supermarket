using System.Configuration;
using System.Data.SqlClient;

namespace SupermarketApp.Model.DataAccessLayer
{
    internal class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
