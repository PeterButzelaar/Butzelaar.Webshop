using System;
using System.Collections.Generic;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Webshop
{
    /// <summary>
    /// Interface for the menu repository
    /// </summary>
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        /// <summary>
        /// Gets the root menus.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Menu> GetRootMenus();
        /// <summary>
        /// Gets the children menus from parent.
        /// </summary>
        /// <param name="parentId">The parent unique identifier.</param>
        /// <returns></returns>
        IEnumerable<Menu> GetChildrenMenusFromParent(Guid parentId);
    }
}
