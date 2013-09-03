using System.Data.Entity;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Database context for security database
    /// </summary>
    public class SecurityContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContext"/> class.
        /// </summary>
        public SecurityContext()
            : base("Name=Security")
        {

        }
    }
}