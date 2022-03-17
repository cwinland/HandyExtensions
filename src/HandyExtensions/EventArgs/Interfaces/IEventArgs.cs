using Serilog.Events;

namespace HandyExtensions.EventArgs.Interfaces
{
    /// <summary>
    /// Interface IEventArgs
    /// </summary>
    public interface IEventArgs
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; }

        /// <summary>
        /// Gets the message level.
        /// </summary>
        /// <value>The message level.</value>
        public LogEventLevel MessageLevel { get; }
    }
}
