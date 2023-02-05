using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KeplerCrud.ConnectionBuilder
{
    public class ConnectionBuilder : IConnectionBuilder
    {
        private readonly IConfiguration _configuration;
        public ConnectionBuilder(IConfiguration configuration)
        {

           _configuration = configuration;
        }
        /// <summary>
        ///  services.AddSingleton<IConnectionBuilder, ConnectionString>();
        /// </summary>
        public string ConString => _configuration["ConnectionString:Value"];
        public IDbConnection GetConnection
        {
            get
            {

                SqlConnection con = new SqlConnection(ConString);
                return con;
            }
        }

        
    }
}
