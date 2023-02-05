using System.Data;
using System.Data.SqlClient;

namespace KeplerCrud.ConnectionBuilder
{
    public class ConnectionString : IConnectionBuilder
    {
        public IDbConnection Connection
        {
            get
            {

                SqlConnection con = new SqlConnection("connectionStringPutHere");
                return con;
            }
        }

    }
}
