using System;
using System.Collections.Generic;

namespace Butzelaar.Webshop.Database.Entities
{
    /// <summary>
    /// Menu class
    /// </summary>
    public class Menu : Base
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public virtual Menu Parent { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public ICollection<Menu> Children { get; set; }
    }
}
