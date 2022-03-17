using System;
using System.Runtime.InteropServices;
using System.Security;

namespace HandyExtensions
{
    /// <summary>
    ///     Secure String extension methods.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class SecureStringExtensions
    {
        /// <summary>
        ///     Copy a secure string instance to a different secure string instance.
        /// </summary>
        /// <param name="sSecureString">The source secure string.</param>
        /// <param name="dSecureString">The destination secure string.</param>
        public static void Overwrite(this SecureString sSecureString, SecureString dSecureString)
        {
            dSecureString.Clear();

            foreach (var chr in ToInsecureString(sSecureString))
            {
                dSecureString.AppendChar(chr);
            }
        }

        /// <summary>
        ///     Converts a secure string to a string.
        /// </summary>
        /// <param name="secureString">The secure string.</param>
        /// <returns>System.String.</returns>
        public static string ToInsecureString(this SecureString? secureString)
        {
            var pointerToUnmanagedBinaryString = IntPtr.Zero;

            if (secureString == null || secureString.Length == 0)
            {
                return string.Empty;
            }

            try
            {
                pointerToUnmanagedBinaryString = Marshal.SecureStringToBSTR(secureString);
                var managedString = Marshal.PtrToStringBSTR(pointerToUnmanagedBinaryString);
                return managedString;
            }
            finally
            {
                if (pointerToUnmanagedBinaryString.Equals(IntPtr.Zero))
                {
                    Marshal.ZeroFreeBSTR(pointerToUnmanagedBinaryString);
                }
            }
        }

        /// <summary>
        ///     Converts a string to a secure string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>SecureString.</returns>
        public static SecureString ToSecureString(this string str)
        {
            var secureString = new SecureString();

            if (!string.IsNullOrWhiteSpace(str))
            {
                foreach (var c in str)
                {
                    secureString.AppendChar(c);
                }
            }

            return secureString;
        }
    }
}
