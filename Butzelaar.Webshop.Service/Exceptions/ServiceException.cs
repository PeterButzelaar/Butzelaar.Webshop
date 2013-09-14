using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butzelaar.Webshop.Service.Exceptions
{
    /// <summary>
    /// When exception occured in the service layer
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The inner exception.</param>
        public ServiceException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
