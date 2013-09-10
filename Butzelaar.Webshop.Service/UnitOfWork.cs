using System;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Service.Logging;
using Butzelaar.Webshop.Service.Webshop;

namespace Butzelaar.Webshop.Service
{
    /// <summary>
    /// Unit of work for logging
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Fields
        /// <summary>
        /// The _menu service
        /// </summary>
        private ILoggingService _loggingService;
        /// <summary>
        /// The _context
        /// </summary>
        private LoggingContext _loggingContext;

        /// <summary>
        /// The _webshop service
        /// </summary>
        private IWebshopService _webshopService;

        /// <summary>
        /// The _webshop context
        /// </summary>
        private WebshopContext _webshopContext;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the menu repository.
        /// </summary>
        /// <value>
        /// The menu repository.
        /// </value>
        public ILoggingService LoggingService
        {
            get { return _loggingService ?? (_loggingService = new LoggingService(LoggingContext)); }
        }

        /// <summary>
        /// Gets the logging context.
        /// </summary>
        /// <value>
        /// The logging context.
        /// </value>
        private LoggingContext LoggingContext
        {
            get { return _loggingContext ?? (_loggingContext = new LoggingContext()); }
        }

        /// <summary>
        /// Gets the webshop service.
        /// </summary>
        /// <value>
        /// The webshop service.
        /// </value>
        private IWebshopService WebshopService
        {
            get { return _webshopService ?? (_webshopService = new MenuService(WebshopContext)); }
        }

        /// <summary>
        /// Gets the webshop context.
        /// </summary>
        /// <value>
        /// The webshop context.
        /// </value>
        private WebshopContext WebshopContext
        {
            get { return _webshopContext ?? (_webshopContext = new WebshopContext()); }
        }

        #endregion

        #region Constructor

        #endregion

        #region CRUD

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            if (_loggingContext != null)
                _loggingContext.SaveChanges();
            if (_webshopContext != null)
                _webshopContext.SaveChanges();

        }

        #endregion

        #region Dispose

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_loggingContext != null)
                _loggingContext.Dispose();
            if(_webshopContext != null)
                _webshopContext.Dispose();
        }

        #endregion
    }
}
