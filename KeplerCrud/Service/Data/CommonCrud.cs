using Dapper;
using KeplerCrud.ConnectionBuilder;
using KeplerCrud.Utility;
using System.Data;
using KeplerCrud.Service.Data.Interface;
namespace KeplerCrud.Service.Data
{
    public class CommonCrud<T> : ICommonCrud<T> where T:class
    {
        string tableName;
        List<string> columns;
        private readonly IConnectionBuilder _connectionBuilder;
        public CommonCrud(IConnectionBuilder connectionBuilder)
        {
            _connectionBuilder = connectionBuilder;
            tableName = Kepler22.GetTableName<T>();
            columns = Kepler22.GetDbColumnName<T>();

        }
        #region Public Methods
        public List<T> GetAllAsync()
        {
            string query = $"SELECT * FROM [{tableName}]";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return  con.Query<T>(query).ToList();
        }

        public List<T> GetAllAsync(string where, string value)
        {
            string query  = $"SELECT * FROM [{tableName}] WHERE {where} = {value}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).ToList();
        }

        public List<T> GetAllAsync(string where, string value, string where1, string value1)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} AND {where1} = {value1}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).ToList();
        }

       
        public T GetAsync(string id)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE Id = {id} ";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }

        public T GetAsync(string where, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} ";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }
        public T GetAsync(string where, string value, string where1, string value1)
        {

            string query = $"SELECT * FROM [{tableName}] WHERE {where} = {value} AND {where1} = {value1}";
            using IDbConnection con = _connectionBuilder.GetConnection;
            return con.Query<T>(query).First();
        }

        public bool InsertAsync(T model)
        {
            //this i have to do and before doing this i have to just fix string to string for values because somethimes someone uses string 
            //values to check where 
            throw new NotImplementedException();
        }

        public bool UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
        #endregion
        //Private Methods
        #region Private Methods
        //private string GetScriptGenerate()
        //{
            
        //}
        #endregion
    }
}
