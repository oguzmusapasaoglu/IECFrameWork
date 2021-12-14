using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FW.DbManager.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Adds entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Updated entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Gets item / entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Get all entities from db
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        List<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get query for entity
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// Get single entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// Get first or default entity by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Retrieve all rows from table.
        /// Use it for get rows from parameter tables.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Saves changes at context
        /// </summary>
        //void SaveChanges();
    }
}
