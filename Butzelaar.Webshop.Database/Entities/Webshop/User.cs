using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Database.Entities.Webshop
{
    /// <summary>
    /// User class
    /// </summary>
    public class User : Base
    {
        /// <summary>
        /// Gets or sets the user profile id.
        /// </summary>
        /// <value>
        /// The user profile id.
        /// </value>
        public int UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

    }
}
