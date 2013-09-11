using System;
using System.Collections.Generic;
using System.Linq;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Model.Logging;
using Butzelaar.Webshop.Repository.Logging;

namespace Butzelaar.Webshop.Service.Logging
{
    /// <summary>
    /// LoggingService class
    /// </summary>
    public class LoggingService : ILoggingService
    {
        #region Fields

        private readonly LoggingContext _context;

        /// <summary>
        /// The _logging repository
        /// </summary>
        private ILogRepository _loggingRepository;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the logging repository.
        /// </summary>
        /// <value>
        /// The logging repository.
        /// </value>
        private ILogRepository LoggingRepository
        {
            get { return _loggingRepository ?? (_loggingRepository = new LogRepository(_context)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingService"/> class.
        /// </summary>
        public LoggingService(LoggingContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the log by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public LogModel GetLogById(Guid id)
        {
            var entity = LoggingRepository.GetById(id);
            return new LogModel(entity.Id,
                    entity.Date,
                    entity.Details,
                    entity.Exception,
                    entity.Host,
                    entity.Level,
                    entity.Logger,
                    entity.Message,
                    entity.Message,
                    entity.Thread
                );
        }

        /// <summary>
        /// Gets the logs.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<LogModel> GetLogsOrderedByDateDescending()
        {
            var entities = LoggingRepository.GetList().OrderByDescending(l => l.Date);
            return entities.Select(entity => new LogModel(entity.Id,
                    entity.Date,
                    entity.Details,
                    entity.Exception,
                    entity.Host,
                    entity.Level,
                    entity.Logger,
                    entity.Message,
                    entity.Message,
                    entity.Thread)).ToList();
        }

        #endregion
    }
}
