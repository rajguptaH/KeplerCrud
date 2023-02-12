
//using System.Collections.Generic;

//namespace KeplerCrud.Repository
//{
//    /// <summary>
//    /// Interface For Kepler Repository Your Can Perform Crud Automaticlly Using Dapper And Sql Server
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    public interface IKeplerRepository<T>
//    {
//        /// <summary>
//        /// Get All Records 
//        /// </summary>
//        /// <param name="columnBase"></param>
//        /// <returns></returns>
//        /// <remarks>If You Give True in columnBase Param You Will Recive Data Based on Columns Attribute You Have Added In Model With KeplerColumn("ColumnName")</remarks>
//        List<T> GetAll(bool columnBase);
//        /// <summary>
//        /// Get All Records Where Column name and value matches
//        /// </summary>
//        /// <param name="conditionsPair"></param>
//        /// <param name="columnBase"></param>
//        /// <returns></returns>
//        List<T> GetAll(List<ConditionPair> conditionsPair, bool columnBase);
//        /// <summary>
//        /// Get Record Where two Column name and value matches
//        /// </summary>
//        /// <param name="conditionsPair"></param>
//        /// <param name="columnBase"></param>
//        /// <returns></returns>
//        T Get(List<ConditionPair> conditionsPair, bool columnBase);
//        /// <summary>
//        /// Insert Record 
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        bool Insert(T model);
//        /// <summary>
//        /// To Update Record
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>
//        bool Update(T model);
//        /// <summary>
//        /// To Delete Record From Db
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        bool HardDelete(int id);
//        /// <summary>
//        /// Soft Delete Record From Db Just Set A Flag As Deleted 
//        /// </summary>
//        /// <param name="Id"></param>
//        /// <returns></returns>
//        bool SoftDelete(int Id);
//    }
//}
