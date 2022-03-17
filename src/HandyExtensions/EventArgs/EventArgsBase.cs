using HandyExtensions.EventArgs.Interfaces;
using Serilog.Events;

namespace HandyExtensions.EventArgs
{
    /// <summary>
    /// Class EventArgsBase.
    /// Implements the <see cref="System.EventArgs" />
    /// Implements the <see cref="HandyExtensions.EventArgs.Interfaces.IEventArgs" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    /// <seealso cref="HandyExtensions.EventArgs.Interfaces.IEventArgs" />
    public abstract class EventArgsBase : System.EventArgs, IEventArgs
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets the message level.
        /// </summary>
        /// <value>The message level.</value>
        public LogEventLevel MessageLevel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgsBase"/> class.
        /// </summary>
        protected EventArgsBase()
        {
            Message = string.Empty;
            MessageLevel = LogEventLevel.Information;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:HandyExtensions.EventArgs.EventArgsBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected EventArgsBase(string message) => Message = message;
    }
}
