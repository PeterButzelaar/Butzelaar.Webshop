﻿using System;

namespace Butzelaar.Webshop.Database.Entities
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets the change date.
        /// </summary>
        /// <value>
        /// The change date.
        /// </value>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets the changed by.
        /// </summary>
        /// <value>
        /// The changed by.
        /// </value>
        public string ModifiedBy { get; set; }
    }
}