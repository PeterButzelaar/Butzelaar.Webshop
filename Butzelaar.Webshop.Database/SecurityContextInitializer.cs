using System.Data.Entity;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Initializer voor de gebruikersdatabase
    /// </summary>
    public class SecurityContextInitializer : CreateDatabaseIfNotExists<SecurityContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(SecurityContext context)
        {
        }
    }
}