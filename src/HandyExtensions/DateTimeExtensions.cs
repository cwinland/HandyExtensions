using System;
using TimeZoneNames;

namespace HandyExtensions
{
    /// <summary>
    /// Class DateTimeExtensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the timezone abbreviation.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns>System.String.</returns>
        public static string GetTimezoneAbbreviation(this DateTime dt, string languageCode = "en-US") =>
            (TimeZoneInfo.Local.IsDaylightSavingTime(dt)
                ? TZNames.GetAbbreviationsForTimeZone(TimeZoneInfo.Local.StandardName, languageCode)?.Daylight
                : TZNames.GetAbbreviationsForTimeZone(TimeZoneInfo.Local.StandardName, languageCode)?.Standard).EnsureNotNull();
    }
}
