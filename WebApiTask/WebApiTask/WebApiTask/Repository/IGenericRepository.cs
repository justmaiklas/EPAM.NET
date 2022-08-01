namespace WebApiTask.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T? Get(Guid id);
        IEnumerable<T> GetAll();
        T? Add(T entity);
        bool Delete(T entity);
        bool Delete(Guid id);
        T? Update(T entity);
    }

}
