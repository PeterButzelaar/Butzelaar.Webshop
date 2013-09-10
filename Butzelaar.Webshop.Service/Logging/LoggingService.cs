using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed;
        /// <summary>
        /// The _unit of work
        /// </summary>
        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingService"/> class.
        /// </summary>
        public LoggingService()
        {
            _unitOfWork = new UnitOfWork();
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
                    _unitOfWork.Dispose();
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

        #region Methods

        /// <summary>
        /// Gets the log by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public LogModel GetLogById(Guid id)
        {
            var entity = _unitOfWork.LoggingRepository.GetById(id);
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
            var entities = _unitOfWork.LoggingRepository.Get().OrderByDescending(l => l.Date);
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
