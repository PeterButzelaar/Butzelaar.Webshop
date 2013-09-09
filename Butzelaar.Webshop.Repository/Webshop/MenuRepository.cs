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
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MenuRepository(WebshopContext context) : base(context)
        {
        }
    }
}
