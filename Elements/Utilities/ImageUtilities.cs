using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

            for (int i = 0; i < _bitmap.Width; i++)
            {
                Color _xColor = ColorUtilities.TransitionColor(int.Parse(Math.Round((i / (double)_bitmap.Width) * 100.0, 0).ToString(CultureInfo.CurrentCulture)), topLeft, topRight);
                for (int j = 0; j < _bitmap.Height; j++)
                {
                    Color _yColor = ColorUtilities.TransitionColor(int.Parse(Math.Round((j / (double)_bitmap.Height) * 100.0, 0).ToString(CultureInfo.CurrentCulture)), bottomLeft, bottomRight);
                    _bitmap.SetPixel(i, j, ColorUtilities.InsertColor(_xColor, _yColor));
                }
            }

            return _bitmap;
        }

        /// <summary>Filters the <see cref="Bitmap" /> using GrayScale.</summary>
        /// <param name="bitmap">The bitmap image.</param>
        /// <returns>The <see cref="Bitmap" />.</returns>
        public static Bitmap FilterGrayScale(this Bitmap bitmap)
        {
            // Constants
            const double RED_THRESHOLD = 0.3;
            const double GREEN_THRESHOLD = 0.59;
            const double BLUE_THRESHOLD = 0.11;

            // Create new gray-scaled bitmap image to work with using the original pixel size
            using (Bitmap filteredGrayScaleImage = new Bitmap(bitmap.Width, bitmap.Height))
            {
                // Loop thru the Y coordinates
                for (int y = 0; y < filteredGrayScaleImage.Height; y++)
                {
                    // Loop thru the X coordinates
                    for (int x = 0; x < filteredGrayScaleImage.Width; x++)
                    {
                        // Retrieve the color from the input bitmap pixels
                        Color pixelColor = bitmap.GetPixel(x, y);

                        // Calculate gray-scale value of the selected pixel
                        int pixelColorGrayScaleValue = (int)((pixelColor.R * RED_THRESHOLD) + (pixelColor.G * GREEN_THRESHOLD) + (pixelColor.B * BLUE_THRESHOLD));

                        // Update the color of the specified pixel in the bitmap
                        filteredGrayScaleImage.SetPixel(x, y, Color.FromArgb(pixelColorGrayScaleValue, pixelColorGrayScaleValue, pixelColorGrayScaleValue));
                    }
                }

                return filteredGrayScaleImage;
            }
        }

        /// <summary>
        /// Converts the <c>Base64</c><see cref="string"/> to an <see cref="Image"/>.
        /// </summary>
        /// <param name="base64">The Base64 text value.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        public static Image ToImage(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                throw new ArgumentNullException(nameof(base64), "Cannot be null or empty.");
            }

            using (MemoryStream _image = new MemoryStream(Convert.FromBase64String(base64)))
            {
                return Image.FromStream(_image);
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image), "Cannot be null.");
            }

            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}