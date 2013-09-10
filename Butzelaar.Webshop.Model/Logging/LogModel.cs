using System;
using System.ComponentModel.DataAnnotations;
using Butzelaar.Webshop.Common.DataAnnotations;
using Butzelaar.Webshop.Common.Resources;

namespace Butzelaar.Webshop.Model.Logging
{
    /// <summary>
    /// Log model
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogModel" /> class.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <param name="date">The date.</param>
        /// <param name="thread">The thread.</param>
        /// <param name="level">The level.</param>
        /// <param name="host">The host.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stacktrace">The stacktrace.</param>
        public LogModel(Guid id,
            DateTime date,
            string thread,
            string level,
            string host,
            string logger,
            string message, 
            string details,
            string exception,
            string stacktrace)
        {
            Id = id;
            Date = date;
            Thread = thread;
            Level = level;
            Host = host;
            Logger = logger;
            Message = message;
            Details = details;
            Exception = exception;
            StackTrace = stacktrace;
        }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public Guid Id { get; private set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [LocalizedDisplayName("Date", NameResourceType = typeof(ModelResource))]
        public DateTime Date { get; private set; }
        /// <summary>
        /// Gets or sets the thread.
        /// </summary>
        /// <value>
        /// The thread.
        /// </value>
        public string Thread { get; private set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public string Level { get; private set; }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; private set; }
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public string Logger { get; private set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; private set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details { get; private set; }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public string Exception { get; private set; }
        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>
        /// The stack trace.
        /// </value>
        public string StackTrace { get; private set; }
    }
}
