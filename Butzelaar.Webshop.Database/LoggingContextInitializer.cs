using System.Data.Entity;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Initializer voor de gebruikersdatabase
    /// </summary>
    public class LoggingContextInitializer : CreateDatabaseIfNotExists<LoggingContext>
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(LoggingContext context)
        {
        }
    }
}