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
    /// <summary>
    /// The log repository
    /// </summary>
    public class LogRepository : ILogRepository
    {
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
        /// Initializes a new instance of the <see cref="LogRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LogRepository(LoggingContext context)
        {
            if(context == null)
                throw new ArgumentNullException("context");

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
        public IEnumerable<Log> GetList()
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
            if(id == Guid.Empty)
                throw new ArgumentNullException("id");

            return DbSet.Find(id);
        }

        #endregion
    }
}
