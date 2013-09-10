using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Model.Webshop
{
    /// <summary>
    /// The base model
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        protected BaseModel(Guid id)
        {
            Id = id;
        }
    }
}
