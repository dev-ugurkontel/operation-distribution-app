using Microsoft.EntityFrameworkCore;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Infrastructure.Conctrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OperationDistributionAppContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(OperationDistributionAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _dbSet.UpdateRange(entities);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
