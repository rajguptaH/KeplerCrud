namespace KeplerCrud.Service.Data.Interface
{
    /// <summary>
    /// Interface For CommonCrud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonCrud<T>
    {
       
        /// <summary>
        /// Get All Records 
        /// </summary>
        /// <param name="columnBase"></param>
        /// <returns></returns>
        List<T> GetAll(bool columnBase);
        /// <summary>
        /// Get All Records Where Column name and value matches
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        List<T> GetAll(string where,string value);
        /// <summary>
        /// Get All Records Where two Column name and value matches
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <param name="where1"></param>
        /// <param name="value1"></param>
        /// <returns></returns>
        List<T> GetAll(string where,string value,string where1,string value1);
        /// <summary>
        /// Get Record Where two Column name and value matches
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <param name="where1"></param>
        /// <param name="value1"></param>
        /// <returns></returns>
        T Get(string where,string value,string where1,string value1);
        /// <summary>
        /// Get Record Where Id = value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        T Get(string value);
        /// <summary>
        /// Get Record Where Column name and Value Matches
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        T Get(string where, string value);
        /// <summary>
        /// Insert Record 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Insert(T model);
        /// <summary>
        /// Update Record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);
    }
}
