using Elements.Constants;
using System;
using System.Drawing;
using System.IO;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="ImageExtensions"/> class.
    /// </summary>
    /// <remarks>Manages the extensibility of the elements.</remarks>
    public static class ImageExtensions
    {
        /// <summary>
        /// Creates a Base64 string value from the <see cref="Image"/>.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ToBase64(this Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image), ArgumentDescription.CannotBeNull);
            }

            using (MemoryStream base64 = new MemoryStream())
            {
                image.Save(base64, image.RawFormat);
                image.Dispose();
                return Convert.ToBase64String(base64.ToArray());
            }
        }
    }
}