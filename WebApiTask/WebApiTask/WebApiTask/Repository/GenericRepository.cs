using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace WebApiTask.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        protected readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = Get(predicate);
            var queryable = includes.Aggregate(query, (current, include) => current.Include(include));
            return queryable;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = GetAll();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T? Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return _context.Set<T>().Find(entity) is null;
        }

        public bool Delete(Guid id)
        {
            //_context.Set<T>().Remove(Get(id) ?? throw new InvalidOperationException());
            _context.SaveChanges();
            
            return _context.Set<T>().Find(id) is null;
        }
        

        public T? Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
