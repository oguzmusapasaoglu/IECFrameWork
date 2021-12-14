using FW.DbManager;
using FW.DbManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IECFW.DbManager
{
    public abstract class BasePostgreRepository<T> : IRepository<T> where T : class
    {
        private readonly PostgreContex _context;

        private DbSet<T> _dbSet => _context.Set<T>();

        private IQueryable<T> Entities => _dbSet;

        public BasePostgreRepository(PostgreContex context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            //_dbSet.Add(entity);

            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Attach(entity);

            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entry = _dbSet.Find(id);
            _dbSet.Remove(entry);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            var entry = _dbSet.Find(id);
            _context.Entry(entry).State = EntityState.Unchanged;

            return entry;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where<T>(predicate).FirstOrDefault();
        }

        public void AddRange(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.AddRange(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
