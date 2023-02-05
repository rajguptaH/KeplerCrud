using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KeplerCrud.KeplerBuilder
{
    public class KeplerBuilder : IKeplerBuilder
    {
        private readonly IConfiguration _configuration;
        public KeplerBuilder(IConfiguration configuration)
        {

           _configuration = configuration;
        }
        /// <summary>
        ///  services.AddSingleton<IConnectionBuilder, ConnectionString>();
        /// </summary>
        public string ConString => _configuration["ConnectionStrings:Value"];
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
