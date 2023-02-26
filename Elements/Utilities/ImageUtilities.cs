using System;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="ImageUtilities"/> class.
    /// </summary>
    public static class ImageUtilities
    {
        /// <summary>
        /// Creates a gradient bitmap.
        /// </summary>
        /// <param name="size">The size of the gradient.</param>
        /// <param name="topLeft">The color for top-left.</param>
        /// <param name="topRight">The color for top-right.</param>
        /// <param name="bottomLeft">The color for bottom-left.</param>
        /// <param name="bottomRight">The color for bottom-right.</param>
        /// <returns>The <see cref="Bitmap"/>.</returns>
        public static Image CreateGradient(Size size, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight)
        {
            Bitmap _bitmap = new Bitmap(size.Width, size.Height);

            for (var i = 0; i < _bitmap.Width; i++)
            {
                Color _xColor = ColorUtilities.TransitionColor(int.Parse(Math.Round((i / (double)_bitmap.Width) * 100.0, 0).ToString(CultureInfo.CurrentCulture)), topLeft, topRight);
                for (var j = 0; j < _bitmap.Height; j++)
                {
                    Color _yColor = ColorUtilities.TransitionColor(int.Parse(Math.Round((j / (double)_bitmap.Height) * 100.0, 0).ToString(CultureInfo.CurrentCulture)), bottomLeft, bottomRight);
                    _bitmap.SetPixel(i, j, ColorUtilities.InsertColor(_xColor, _yColor));
                }
            }

            return _bitmap;
        }

        /// <summary>
        /// Create the image from a Base64 value.
        /// </summary>
        /// <param name="value">The Base64 value.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public static Image DrawImageFromBase64(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "Cannot be null or empty.");
            }

            Image _image;
            using (MemoryStream _memoryStream = new MemoryStream(Convert.FromBase64String(value)))
            {
                _image = Image.FromStream(_memoryStream);
            }

            return _image;
        }
    }
}