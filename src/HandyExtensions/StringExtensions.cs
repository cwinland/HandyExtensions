namespace HandyExtensions
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Ensures the not null.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string EnsureNotNull(this string? text) => string.IsNullOrWhiteSpace(text) ? string.Empty : text;
    }
}
