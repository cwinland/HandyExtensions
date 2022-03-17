using Serilog.Events;

namespace HandyExtensions.EventArgs
{
    /// <inheritdoc />
    /// <summary>
    /// Class MessageEventArgs.
    /// Implements the <see cref="T:System.EventArgs" />
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class MessageEventArgs : EventArgsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageEventArgs"/> class.
        /// </summary>
        public MessageEventArgs()
        {}

        /// <inheritdoc />
        public MessageEventArgs(string message, LogEventLevel messageLevel) : base(message) => MessageLevel = messageLevel;
    }
}
