using Butzelaar.Webshop.Model.Webshop.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Service.Webshop
{
    interface IMenuService : IWebshopService
    {
        MenuModel GetMenuById(Guid id);
        IEnumerable<MenuModel> GetRootMenus();
        IEnumerable<MenuModel> GetChildrenMenusFromParent(Guid parentId);
    }
}
