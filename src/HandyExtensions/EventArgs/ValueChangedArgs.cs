namespace HandyExtensions.EventArgs
{
    /// <summary>
    /// Class ValueChangedArgs.
    /// </summary>
    /// <typeparam name="TValue">The type of the t value.</typeparam>
    public class ValueChangedArgs<TValue> : EventArgsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChangedArgs{TValue}" /> class.
        /// </summary>
        /// <param name="oldViewContext">The old view context.</param>
        /// <param name="newViewContext">The new view context.</param>
        public ValueChangedArgs(TValue? oldViewContext, TValue newViewContext)
        {
            OldValue = oldViewContext;
            NewValue = newViewContext;
        }

        /// <summary>
        /// Gets the old value.
        /// </summary>
        /// <value>The old value.</value>
        public TValue? OldValue { get; }
        /// <summary>
        /// Creates new value.
        /// </summary>
        /// <value>The new value.</value>
        public TValue NewValue { get; }
    }
}
