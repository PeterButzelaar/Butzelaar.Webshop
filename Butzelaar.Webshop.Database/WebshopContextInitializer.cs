using Butzelaar.Webshop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Initializer for the webshop context
    /// </summary>
    public class WebshopContextInitializer : DropCreateDatabaseIfModelChanges<WebshopContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(WebshopContext context)
        {
            var rootMenu = new Menu
                {
                    Name = "Admin"
                };
            context.Menus.Add(rootMenu);

            context.SaveChanges();
        }
    }
}
