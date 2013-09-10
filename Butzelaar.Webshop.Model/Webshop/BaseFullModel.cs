using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Model.Webshop
{
    /// <summary>
    /// The base full model
    /// </summary>
    public abstract class BaseFullModel : BaseModel
    {
        /// <summary>
        /// Gets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; private set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; private set; }
        /// <summary>
        /// Gets the change date.
        /// </summary>
        /// <value>
        /// The change date.
        /// </value>
        public DateTime ModifiedDate { get; private set; }
        /// <summary>
        /// Gets or sets the changed by.
        /// </summary>
        /// <value>
        /// The changed by.
        /// </value>
        public string ModifiedBy { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFullModel"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="createDate">The create date.</param>
        /// <param name="createdBy">The created by.</param>
        /// <param name="modifiedDate">The modified date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        protected BaseFullModel(Guid id, DateTime createDate, string createdBy, DateTime modifiedDate, string modifiedBy)
            : base(id)
        {
            CreateDate = createDate;
            CreatedBy = createdBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}
