using System.Diagnostics;

namespace HandyExtensions
{
    /// <summary>
    /// Class ProcessExtensions.
    /// </summary>
    public static class ProcessExtensions
    {
        /// <summary>
        /// Processes the has exit code.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <returns><c>true</c> if the process has an exit code, <c>false</c> otherwise.</returns>
        public static bool ProcessHasExitCode(Process? process)
        {
            try
            {
                _ = process?.ExitCode; // test for error
                return process != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Processes the has start information.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <returns><c>true</c> if the process has <see cref="ProcessStartInfo"/>, <c>false</c> otherwise.</returns>
        public static bool ProcessHasStartInfo(Process? process)
        {
            try
            {
                return process?.StartInfo != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
