using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butzelaar.Webshop.Database;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Repository.Webshop
{
    /// <summary>
    /// The Menu respository
    /// </summary>
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MenuRepository(WebshopContext context) : base(context)
        {
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Gets the root menus.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Menu> GetRootMenus()
        {
            return DbSet.Where(m => m.ParentId == null).ToList();
        }

        /// <summary>
        /// Gets the children menus from parent.
        /// </summary>
        /// <param name="parentId">The parent unique identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Menu> GetChildrenMenusFromParent(Guid parentId)
        {
            if(parentId == Guid.Empty)
                throw new ArgumentNullException("parentId");

            return DbSet.Where(m => m.ParentId == parentId).ToList();
        }

        #endregion
    }
}
