using System;
using Butzelaar.Webshop.Database;

namespace Butzelaar.Webshop.Repository.Webshop
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// The _menu repository
        /// </summary>
        private MenuRepository _menuRepository;
        /// <summary>
        /// The _context
        /// </summary>
        private readonly WebshopContext _context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the menu repository.
        /// </summary>
        /// <value>
        /// The menu repository.
        /// </value>
        public MenuRepository MenuRepository
        {
            get { return _menuRepository ?? (_menuRepository = new MenuRepository(_context)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public UnitOfWork(string username)
        {
            _context = new WebshopContext(username);
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
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
                    _context.Dispose();
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
