using System.Data;

namespace KeplerCrud.KeplerBuilder
{
    public interface IKeplerBuilder
    {
        public IDbConnection GetConnection { get; }
        public string ConString { get; }
    }
}
