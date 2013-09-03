using System.Data.Entity;
using Butzelaar.Webshop.Database.Entities.Webshop;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Initializer for the webshop context
    /// </summary>
    public class WebshopContextInitializer : CreateDatabaseIfNotExists<WebshopContext>
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
