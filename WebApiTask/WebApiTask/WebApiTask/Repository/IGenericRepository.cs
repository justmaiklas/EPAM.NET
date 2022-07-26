namespace WebApiTask.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T? Get(Guid id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

}
