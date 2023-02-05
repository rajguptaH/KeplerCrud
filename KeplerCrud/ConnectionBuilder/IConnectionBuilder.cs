using System.Data;

namespace KeplerCrud.ConnectionBuilder
{
    public interface IConnectionBuilder
    {
        public IDbConnection Connection { get; }
    }
}
