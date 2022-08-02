using System.Linq.Expressions;

namespace WebApiTask.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T? Add(T entity);
        bool Delete(T entity);
        bool Delete(Guid id);
        T? Update(T entity);
    }

}
