using System.Data;

namespace KeplerCrud.ConnectionBuilder
{
    public interface IConnectionBuilder
    {
        public IDbConnection GetConnection { get; }
        public string ConString { get; }
    }
}
