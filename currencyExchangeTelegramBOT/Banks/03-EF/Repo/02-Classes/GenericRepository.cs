using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            using (_context)
            {
                _dbSet.Add(item);
                _context.SaveChanges();
            }
        }

        public void Delete(TEntity item)
        {
            using (_context)
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<TEntity> GetAll() => 
            _dbSet.AsNoTracking().ToList();


        public void Update(TEntity item)
        {
            using (_context)
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
