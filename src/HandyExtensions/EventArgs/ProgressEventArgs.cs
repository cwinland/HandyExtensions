namespace HandyExtensions.EventArgs
{
    /// <inheritdoc />
    /// <summary>
    /// Class ProgressEventArgs.
    /// Implements the <see cref="T:System.EventArgs" />
    /// </summary>
    /// <seealso cref="T:System.EventArgs" />
    public class ProgressEventArgs : EventArgsBase
    {
        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <value>The activity.</value>
        public string Activity { get; }

        /// <summary>
        /// Gets the percent complete.
        /// </summary>
        /// <value>The percent complete.</value>
        public int PercentComplete { get; }

        /// <summary>
        /// Gets the seconds remaining.
        /// </summary>
        /// <value>The seconds remaining.</value>
        public int SecondsRemaining { get; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>The status description.</value>
        public string StatusDescription { get; }
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FamilyTree.Models.ProgressEventArgs" /> class.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="percentComplete">The percent complete.</param>
        /// <param name="secondsRemaining">The seconds remaining.</param>
        /// <param name="statusDescription">The status description.</param>
        public ProgressEventArgs(string? activity, int percentComplete, int secondsRemaining, string? statusDescription)
        {
            Activity = activity.EnsureNotNull();
            PercentComplete = percentComplete;
            SecondsRemaining = secondsRemaining;
            StatusDescription = statusDescription.EnsureNotNull();
        }
    }
}
