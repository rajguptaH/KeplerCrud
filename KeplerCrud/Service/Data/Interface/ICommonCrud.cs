namespace KeplerCrud.Service.Data.Interface
{
    public interface ICommonCrud<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<T> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        List<T> GetAllAsync(string where,string value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <param name="where1"></param>
        /// <param name="value1"></param>
        /// <returns></returns>
        List<T> GetAllAsync(string where,string value,string where1,string value1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <param name="where1"></param>
        /// <param name="value1"></param>
        /// <returns></returns>
        T GetAsync(string where,string value,string where1,string value1);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        T GetAsync(string value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        T GetAsync(string where, string value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InsertAsync(T model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateAsync(T model);
    }
}
