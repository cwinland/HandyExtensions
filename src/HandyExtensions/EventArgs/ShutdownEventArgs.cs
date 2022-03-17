namespace HandyExtensions.EventArgs
{
    /// <inheritdoc />
    /// <summary>
    /// Used for shutdown process when determining minimize vs close.
    /// </summary>
    public class ShutdownEventArgs : EventArgsBase
    {
        /// <summary>
        /// Shuts down this instance.
        /// </summary>
        public bool shutdown;
        /// <summary>
        /// The cancel
        /// </summary>
        public bool cancel;
    }
}
