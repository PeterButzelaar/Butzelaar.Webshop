using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Repository.Webshop;

namespace Butzelaar.Webshop.Service.Webshop
{
    /// <summary>
    /// Webshop service
    /// </summary>
    public class MenuService : IMenuService
    {
        #region Fields

        /// <summary>
        /// The _menu repository
        /// </summary>
        private IMenuRepository _menuRepository;

        /// <summary>
        /// The _context
        /// </summary>
        private readonly WebshopContext _context;

        /// <summary>
        /// Gets the menu repository.
        /// </summary>
        /// <value>
        /// The menu repository.
        /// </value>
        private IMenuRepository MenuRepository
        {
            get { return _menuRepository ?? (_menuRepository = new MenuRepository(_context)); }
        }

        #endregion

        #region Properties

        #endregion

        #region Methods



        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MenuService(WebshopContext context)
        {
            _context = context;
        }

        #endregion
    }
}
