using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Logging;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Logging
{
    public class LoggingRepository : ILoggingRepository
    {
        #region Fields

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed;

        #endregion

        #region Properties

        /// <summary>
        /// The _context
        /// </summary>
        protected readonly LoggingContext Context;
        /// <summary>
        /// The _DB set
        /// </summary>
        protected readonly DbSet<Log> DbSet;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        internal LoggingRepository(LoggingContext context)
        {
            Context = context;
            DbSet = context.Set<Log>();
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Log> Get()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public Log GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
