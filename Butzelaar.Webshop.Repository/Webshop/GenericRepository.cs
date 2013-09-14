using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Script.Serialization;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Webshop
{
    /// <summary>
    /// Generic repository for the Webshop context
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Base
    {
        #region Properties

        /// <summary>
        /// The _context
        /// </summary>
        protected readonly WebshopContext Context;
        /// <summary>
        /// The _DB set
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        internal protected GenericRepository(WebshopContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            Context = context;
            DbSet = context.Set<TEntity>();
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public TEntity GetById(Guid id)
        {
            if(id == Guid.Empty)
                throw new ArgumentNullException("id");

            Logger.Log(Level.Debug, "Getting entity by id", String.Format("Type: {0}, ID: {1}", typeof(TEntity), id));
            return DbSet.Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");

            DbSet.Add(entity);

            var data = new JavaScriptSerializer().Serialize(entity);
            Logger.Log(Level.Debug, "Added entity to context", String.Format("Type: {0}. Data: {1}", typeof(TEntity), data));
        }

        /// <summary>
        /// Deletes the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public void Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("id");

            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity automatic delete.
        /// </summary>
        /// <param name="entityToDelete">The entity automatic delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null)
                throw new ArgumentNullException("entityToDelete");

            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);

            var data = new JavaScriptSerializer().Serialize(entityToDelete);
            Logger.Log(Level.Debug, "Removed entity to context", String.Format("Type: {0}. Data: {1}", typeof(TEntity), data));
        }

        /// <summary>
        /// Updates the specified entity automatic update.
        /// </summary>
        /// <param name="entityToUpdate">The entity automatic update.</param>
        public void Update(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
                throw new ArgumentNullException("entityToUpdate");

            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;

            var data = new JavaScriptSerializer().Serialize(entityToUpdate);
            Logger.Log(Level.Debug, "Entity updated in context", String.Format("Type: {0}. Data: {1}", typeof(TEntity), data));
        }

        #endregion
    }
}
