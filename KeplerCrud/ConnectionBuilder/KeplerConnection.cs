using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KeplerCrud.Connection
{
    public class KeplerConnection : IKeplerConnection
    {
        private readonly IConfiguration _configuration;
        public KeplerConnection(IConfiguration configuration)
        {

           _configuration = configuration;
        }
        /// <summary>
        ///  services.AddSingleton<IConnectionBuilder, ConnectionString>();
        /// </summary>
        public string ConnectionString => _configuration["ConnectionStrings:Value"];
        public IDbConnection GetConnection => new SqlConnection(ConnectionString);

        
    }
}
