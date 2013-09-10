using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Butzelaar.Webshop.Database.Entities.Logging;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Logging
{
    /// <summary>
    /// Generic repository for the Logging context
    /// </summary>
    public interface ILogRepository
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Log> Get();

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        Log GetById(Guid id);
    }
}
