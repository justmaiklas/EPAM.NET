using Microsoft.EntityFrameworkCore;

namespace WebApiTask.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        private readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public T? Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
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
            _context.Set<T>().Remove(Get(id) ?? throw new InvalidOperationException());
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
