using Dapper;
using KeplerCrud.KeplerBuilder;
using KeplerCrud.Utility;
using System.Data;
using KeplerCrud.Service.Data.Interface;
using System.Text;

namespace KeplerCrud.Service.Data
{
    public class CommonCrud<T> : ICommonCrud<T> where T:class
    {
        string tableName;
        List<string> columns;
        private readonly IKeplerBuilder _connectionBuilder;
        public CommonCrud(IKeplerBuilder connectionBuilder)
        {
            _connectionBuilder = connectionBuilder;
            tableName = Kepler22.GetTableName<T>();
            columns = Kepler22.GetDbColumnName<T>();

        }
        #region Public Methods
        public List<T> GetAll(bool columnBase)
        {
            using IDbConnection con = _connectionBuilder.GetConnection;
            string query;
            if (columnBase)
            {
                var keplerQuery = new StringBuilder($"SELECT ");
                columns.ForEach(x => keplerQuery.Append($"TN.{x},"));
                keplerQuery.Remove(keplerQuery.Length - 1, 1);
                keplerQuery.Append($"FROM [{tableName}] TN");
                query = keplerQuery.ToString();
            }
            else
            {
                query = $"SELECT * FROM [{tableName}]";
            }
            return  con.Query<T>(query).ToList();
        }

        public List<T> GetAll(string where, string value,bool columnBase)
        {
            string query  = $"SELECT * FROM [{tableName}] WHERE {where} = {value}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            if (columnBase)
            {
                var keplerQuery = new StringBuilder($"SELECT ");
                columns.ForEach(x => keplerQuery.Append($"TN.{x},"));
                keplerQuery.Remove(keplerQuery.Length - 1, 1);
                keplerQuery.Append($"FROM [{tableName}] TN WHERE {where} = {value}");
                query = keplerQuery.ToString();
            }
            return con.Query<T>(query).ToList();
        }

        public List<T> GetAll(string where, string value, string where1, string value1)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} AND {where1} = {value1}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).ToList();
        }

       
        public T Get(string id)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE Id = {id} ";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }

        public T Get(string where, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} ";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }
        public T Get(string where, string value, string where1, string value1)
        {

            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} AND {where1} = {value1}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }

        public bool Insert(T model)
        {
            //this i have to do and before doing this i have to just fix string to string for values because somethimes someone uses string 
            //values to check where 
            throw new NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new NotImplementedException();
        }
        #endregion
        //Private Methods
        #region Private Methods
        //private string GenerateColumns()
        //{
         
        //}
        #endregion
    }
}
