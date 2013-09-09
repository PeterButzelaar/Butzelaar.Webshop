using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Webshop
{
    /// <summary>
    /// Generic repository for the Webshop context
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : Base
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        TEntity GetById(Guid id);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);
        /// <summary>
        /// Deletes the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        void Delete(Guid id);
        /// <summary>
        /// Deletes the specified entity automatic delete.
        /// </summary>
        /// <param name="entityToDelete">The entity automatic delete.</param>
        void Delete(TEntity entityToDelete);
        /// <summary>
        /// Updates the specified entity automatic update.
        /// </summary>
        /// <param name="entityToUpdate">The entity automatic update.</param>
        void Update(TEntity entityToUpdate);
    }
}
