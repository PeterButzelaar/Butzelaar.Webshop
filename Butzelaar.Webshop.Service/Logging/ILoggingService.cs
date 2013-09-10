using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butzelaar.Webshop.Model.Logging;

namespace Butzelaar.Webshop.Service.Logging
{
    /// <summary>
    /// ILoggingService interface
    /// </summary>
    public interface ILoggingService : IDisposable
    {
        /// <summary>
        /// Gets the log by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        LogModel GetLogById(Guid id);
        /// <summary>
        /// Gets the logs ordered by date descending.
        /// </summary>
        /// <returns></returns>
        IEnumerable<LogModel> GetLogsOrderedByDateDescending();
    }
}
