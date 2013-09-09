using System;
using System.Collections.Generic;

namespace Butzelaar.Webshop.Database.Entities.Webshop
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
        /// Gets or sets the parent unique identifier.
        /// </summary>
        /// <value>
        /// The parent unique identifier.
        /// </value>
        public Guid? ParentId { get; set; }
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
        public virtual ICollection<Menu> Children { get; set; }
    }
}
