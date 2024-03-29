using System.Linq.Expressions;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> filter, string includes)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            var splittedInclude = includes.Split(',');
            foreach (var item in splittedInclude)
            {
                query = query.Include(item);
            }

            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public IEnumerable<T> GetAll(string includes)
        {
            IQueryable<T> query = dbSet;

            var splittedInclude = includes.Split(',');
            
            foreach (var item in splittedInclude)
            {
                query = query.Include(item);
            }

            return query;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}