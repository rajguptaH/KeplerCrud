using Dapper;
using KeplerCrud.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KeplerCrud.Repository
{
    public static class KeplerRepository
    {
        private static string tableName { get; set; }
        private static string pKey { get; set; }
        private static List<string> columns { get; set; }
        static KeplerRepository()
        {
            tableName = string.Empty;
            pKey = string.Empty;
            columns = new List<string>();
        }
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="conditions"></param>
        /// <param name="columnBase"></param>
        /// <returns></returns>
        public static List<T> GetAll<T>(this IDbConnection con, List<ConditionPair> conditions, bool columnBase)
        {
            InitlizeModel<T>();
            try
            {
                string query;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()}");
                    keplerQuery.Append($" FROM [{tableName}] TN");
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
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="columnBase"></param>
        /// <returns></returns>
        public static List<T> GetAll<T>(this IDbConnection con, bool columnBase)
        {
            InitlizeModel<T>();
            try
            {
                string query;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()} ");
                    keplerQuery.Append($" FROM [{tableName}] TN WHERE TN.IsDeleted = 0");
                    query = keplerQuery.ToString();
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}] WHERE IsDeleted = 0";
                }

                return con.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="conditions"></param>
        /// <param name="columnBase"></param>
        /// <returns></returns>
        public static T Get<T>(this IDbConnection con, List<ConditionPair> conditions, bool columnBase )
        {
            InitlizeModel<T>();
            try
            {
                string query;
                if (columnBase)
                {
                    var keplerQuery = new StringBuilder($"SELECT {GenerateColumns()}");
                    keplerQuery.Append($" FROM [{tableName}] TN {GenerateConditons(conditions)}");
                    query = keplerQuery.ToString();
                }
                else
                {
                    query = $"SELECT * FROM [{tableName}] TN {GenerateConditons(conditions)}";
                }

                return con.Query<T>(query).First();
            }
            catch (Exception e)
            {
                return default(T);
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Insert<T>(this IDbConnection con, T model)
        {
            InitlizeModel<T>();
            try
            {
                var query = GenerateInsertQuery();

                con.Execute(query, model);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update<T>(this IDbConnection con, T model)
        {
            InitlizeModel<T>();
            try
            {
                var query = GenerateUpdateQuery();

                con.Execute(query, model);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool HardDelete<T>(this IDbConnection con, int id)
        {
            tableName = Kepler22.GetTableName<T>();
            pKey = Kepler22.GetPKey<T>();
            try
            {
                var query = $"DELETE FROM [{tableName}] WHERE {pKey} = {id}; ";

                con.Execute(query);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="con"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool SoftDelete<T>(this IDbConnection con, int Id)
        {
            tableName = Kepler22.GetTableName<T>();
            pKey = Kepler22.GetPKey<T>();
            try
            {
                var query = $"UPDATE [{tableName}] SET IsDeleted = 1 WHERE {pKey} = {Id} ";

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
        private static string GenerateColumns()
        {
            string pkeyColName = string.Empty;
            if (pKey != null)
            {
                pkeyColName = $"TN.{pKey},";
            }
            var keplerQuery = new StringBuilder(pkeyColName);
            columns.ForEach(x => keplerQuery.Append($"TN.{x},"));
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            return keplerQuery.ToString();
        }
        private static string GenerateConditons(List<ConditionPair> conditions)
        {
            var keplerQurey = new StringBuilder($"WHERE TN.IsDeleted = 0 AND ");
            if (conditions.Count() > 0)
            {
                conditions.ForEach(x => keplerQurey.Append($"TN.{x.Where} = '{x.Value}' AND"));

                keplerQurey.Remove(keplerQurey.Length - 3, 3);
            }
            else
            {
                keplerQurey.Remove(keplerQurey.Length - 4, 4);
            }
            return keplerQurey.ToString();
        }
        private static string GenerateInsertQuery()
        {
            var keplerQuery = new StringBuilder($"INSERT INTO [{tableName}] (");
            columns.ForEach(x =>  keplerQuery.Append($"{x},"));
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append($") VALUES (");
            columns.ForEach(x =>  keplerQuery.Append($"@{x},"));
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append(")");
            return keplerQuery.ToString();
        }
        private static string GenerateUpdateQuery()
        {
            var keplerQuery = new StringBuilder($"UPDATE [{tableName}] SET ");
            columns.ForEach(x =>  keplerQuery.Append($"{x} = @{x},"));
            keplerQuery.Remove(keplerQuery.Length - 1, 1);
            keplerQuery.Append($" WHERE {pKey} = @{pKey}");
            return keplerQuery.ToString();
        }
        private static void InitlizeModel<T>()
        {
            
            tableName = Kepler22.GetTableName<T>();
            columns = Kepler22.GetDbColumnName<T>();
            pKey = Kepler22.GetPKey<T>();
        }
        #endregion
    }
}
