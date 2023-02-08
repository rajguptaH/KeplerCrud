using System.Data;

namespace KeplerCrud.Connection
{
    public interface IKeplerConnection
    {
        public IDbConnection GetConnection { get; }
        public string ConnectionString { get; }
    }
}
