using System.IO;
using System.IO.Abstractions;

namespace HandyExtensions
{
    /// <summary>
    /// Class FileSystemExtensions.
    /// </summary>
    public static class FileSystemExtensions
    {
        /// <summary>
        /// Gets the <see cref="T:System.Byte[]" /> from the given file path.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="filePath">Full path to the file to read.</param>
        /// <returns><see cref="T:System.Byte[]" /></returns>
        public static byte[] GetFileBytes(this IFileSystem fileSystem, string filePath)
        {
            using (var stream = fileSystem.FileStream?.Create(filePath, FileMode.Open))
            {
                var ms = new MemoryStream();
                stream?.CopyTo(ms);

                return ms.ToArray();
            }
        }

        /// <summary>
        /// Writes byte array data to the specified file path.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="filePath">The file path.</param>
        /// <param name="data">The data.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        /// <exception cref="System.IO.IOException"></exception>
        public static void WriteBytes(this IFileSystem fileSystem, string filePath, byte[] data, bool overwrite = false)
        {
            if (!overwrite && (fileSystem.File?.Exists(filePath) ?? false))
            {
                throw new IOException($"{filePath} already exists.");
            }

            using (var file = fileSystem.File?.Create(filePath))
            {
                file?.Write(data);
            }
        }
    }
}
