namespace KeplerCrud.Service.Data.Interface
{
    public interface ICommonCrud<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(string where,int id);
        Task<List<T>> GetAllAsync(string where1,int id1,string where2,int id2);
        Task<T> GetAsync(string where1,int id1,string where2,int id2);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(string where, int id);
        Task<bool> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
    }
}
