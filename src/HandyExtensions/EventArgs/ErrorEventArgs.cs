using Serilog.Events;
using System;
using System.Collections.Generic;

namespace HandyExtensions.EventArgs
{
    /// <inheritdoc />
    /// <summary>
    /// Class ErrorEventArgs.
    /// Implements the <see cref="T:System.EventArgs" />
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class ErrorEventArgs : EventArgsBase
    {
        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception? Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
        /// </summary>
        public ErrorEventArgs()
        {}

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FamilyTree.Models.ErrorEventArgs" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ErrorEventArgs(string message) : base(message)
        {
            Message = message;
            MessageLevel = LogEventLevel.Error;
            Exception = null;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FamilyTree.Models.ErrorEventArgs" /> class.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public ErrorEventArgs(IEnumerable<string> messages) : this(string.Join(Environment.NewLine, messages))
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FamilyTree.Models.ErrorEventArgs" /> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public ErrorEventArgs(Exception ex) : this(ex.Message) => Exception = ex;

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetErrorMessage() => Exception?.Message ?? Message;
    }
}
