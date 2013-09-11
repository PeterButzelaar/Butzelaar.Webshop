using System;
using System.Collections.Generic;
using System.Linq;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Model.Webshop.Menu;
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

        /// <summary>
        /// Gets the menu by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public MenuModel GetMenuById(Guid id)
        {
            var entity = _menuRepository.GetById(id);
            return new MenuModel(entity.Id, entity.CreateDate, entity.CreatedBy, entity.ModifiedDate, entity.ModifiedBy)
                {
                    Name = entity.Name,
                    ParentId = entity.ParentId
                };
        }

        /// <summary>
        /// Gets the root menus.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<MenuModel> GetRootMenus()
        {
            var entities = _menuRepository.GetRootMenus();
            return entities.Select(entity => new MenuModel(entity.Id, entity.CreateDate, entity.CreatedBy, entity.ModifiedDate, entity.ModifiedBy)
                        {
                            Name = entity.Name,
                            ParentId = entity.ParentId
                        });
        }

        /// <summary>
        /// Gets the children menus from parent.
        /// </summary>
        /// <param name="parentId">The parent unique identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<MenuModel> GetChildrenMenusFromParent(Guid parentId)
        {
            var entities = _menuRepository.GetChildrenMenusFromParent(parentId);
            return entities.Select(entity => new MenuModel(entity.Id, entity.CreateDate, entity.CreatedBy, entity.ModifiedDate, entity.ModifiedBy)
                        {
                            Name = entity.Name,
                            ParentId = entity.ParentId
                        });
        }

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
