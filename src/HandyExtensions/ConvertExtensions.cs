using System;
using System.ComponentModel;

namespace HandyExtensions
{
    /// <summary>
    /// Class ConvertExtensions.
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Tries to convert the specified value to specified type or default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val">The value.</param>
        /// <param name="newVal">The new value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns><c>true</c> if value exists and is valid, <c>false</c> otherwise.</returns>
        public static bool TryConvert<T>(this string val, out T? newVal, T? defaultValue)
        {
            var valid = val.CanConvert(typeof(T));

            try
            {
                var convertedVal = valid
                    ? TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(val)
                    : defaultValue;

                newVal = convertedVal != null ? (T) convertedVal : default;
            }
            catch (Exception)
            {
                valid = false;
                newVal = defaultValue;
            }

            return valid;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified desired type.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="desiredType">Type of the desired.</param>
        /// <returns><c>true</c> if this instance can convert the specified desired type; otherwise, <c>false</c>.</returns>
        public static bool CanConvert(this string val, Type desiredType)
        {
            var valid = !string.IsNullOrWhiteSpace(val);

            if (!valid)
            {
                return false;
            }


            try
            {
                _ = TypeDescriptor.GetConverter(desiredType).ConvertFromInvariantString(val);
            }
            catch (Exception)
            {
                valid = false;
            }

            return valid;
        }

    }
}
