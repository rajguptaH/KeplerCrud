using Dapper;
using KeplerCrud.Connection;
using KeplerCrud.Utility;
using System.Data;
using System.Text;

namespace KeplerCrud.Repository
{
    public class KeplerRepository<T> : IKeplerRepository<T> where T : class
    {
        string tableName;
        string isDeleted;
        List<string> columns;
        private readonly IKeplerConnection _connectionBuilder;
        public KeplerRepository(IKeplerConnection connectionBuilder)
        {
            isDeleted = "IsDeleted = 0";
            _connectionBuilder = connectionBuilder;
            tableName = Kepler22.GetTableName<T>();
            columns = Kepler22.GetDbColumnName<T>();

        }
        #region Public Methods
        public List<T> GetAll(List<ConditionPair> conditions, bool columnBase)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                string query;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()}");
                    keplerQuery.Remove(keplerQuery.Length - 1, 1);
                    keplerQuery.Append($"FROM [{tableName}] TN");
                    keplerQuery.Append($"{GenerateConditons(conditions)}");
                    query = keplerQuery.ToString();
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}] TN {GenerateConditons(conditions)}";
                }

                return con.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        public List<T> GetAll(bool columnBase)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                string query;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()} ");
                    keplerQuery.Append($"FROM [{tableName}] TN");
                    query = keplerQuery.ToString();
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}]";
                }

                return con.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        public T Get(List<ConditionPair> conditions, bool columnBase)
        {
            try
            {
                string query;
                using IDbConnection con = _connectionBuilder.GetConnection;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()}");
                    keplerQuery.Remove(keplerQuery.Length - 1, 1);
                    keplerQuery.Append($"FROM [{tableName}] TN {GenerateConditons(conditions)}");
                    query = keplerQuery.ToString();
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}] TN {GenerateConditons(conditions)}";
                }

                return con.Query<T>(query).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(T model)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                var query = GenerateInsertQuery();

                con.Execute(query, model);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(T model)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                var query = GenerateUpdateQuery();

                con.Execute(query, model);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool HardDelete(int id)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                var query = $"DELETE FROM [{tableName}] WHERE Id = {id}; ";

                con.Execute(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SoftDelete(int Id)
        {
            try
            {
                using IDbConnection con = _connectionBuilder.GetConnection;
                var query = $"UPDATE [{tableName}] SET IsDeleted = 1 WHERE Id = {Id} ";

                con.Execute(query);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        //Private Methods
        #region Private Methods
        private string GenerateColumns()
        {
            var keplerQuery = new StringBuilder();
            columns.ForEach(x => keplerQuery.Append($"TN.{x},"));
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            return keplerQuery.ToString();
        }
        public string GenerateConditons(List<ConditionPair> conditions)
        {
            var keplerQurey = new StringBuilder($"WHERE {isDeleted} AND ");
            conditions.ForEach(x => keplerQurey.Append($"TN.{x.Where} = '{x.Value}' AND"));

            keplerQurey.Remove(keplerQurey.Length - 3, 3);
            return keplerQurey.ToString();
        }
        public string GenerateInsertQuery()
        {
            var keplerQuery = new StringBuilder($"INSERT INTO [{tableName}] (");
            columns.ForEach(x => { if (x.ToLower() != "id") { keplerQuery.Append($"{x},"); } });
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append($") VALUES (");
            columns.ForEach(x => { if (x.ToLower() != "id") { keplerQuery.Append($"@{x},"); } });
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append(")");
            return keplerQuery.ToString();
        }
        public string GenerateUpdateQuery()
        {
            var keplerQuery = new StringBuilder($"UPDATE [{tableName}] SET");
            columns.ForEach(x => { if (x.ToLower() != "id") { keplerQuery.Append($"{x} = @{x},"); } });
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append("WHERE Id = @Id");
            return keplerQuery.ToString();
        }
        #endregion
    }
}
