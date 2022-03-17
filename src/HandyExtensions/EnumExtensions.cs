using System;
using System.ComponentModel;
using System.Linq;

namespace HandyExtensions
{
    /// <summary>
    /// Provide extensions for enum related structs.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the description attribute from the enum value. Returns the enum name if the description does not exist.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription<T>(this T e) where T : Enum, IConvertible =>
            e.GetType().GetField(e.ToString())?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is DescriptionAttribute descriptionAttribute
                ? descriptionAttribute.Description
                : e.ToString();

        /// <summary>
        /// Find the enum for the given description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        public static T GetEnum<T>(this string value) where T: struct, Enum, IConvertible
        {
            try
            {
                return Enum.GetValues<T>().ToList().First(x => x.GetDescription().Equals(value, StringComparison.CurrentCultureIgnoreCase));
            }
            catch
            {
                return Enum.Parse<T>(value);
            }
        }
    }

}
