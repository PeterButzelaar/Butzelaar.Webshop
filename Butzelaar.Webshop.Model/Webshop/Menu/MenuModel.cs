﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Model.Webshop.Menu
{
    /// <summary>
    /// The menu model
    /// </summary>
    public class MenuModel : BaseFullModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuModel"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="createDate">The create date.</param>
        /// <param name="createdBy">The created by.</param>
        /// <param name="modifiedDate">The modified date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        public MenuModel(Guid id, DateTime createDate, string createdBy, DateTime modifiedDate, string modifiedBy) : base(id, createDate, createdBy, modifiedDate, modifiedBy)
        {
        }
    }
}
