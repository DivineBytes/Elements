using Elements.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="ColorUtilities"/> class.
    /// </summary>
    public static class ColorUtilities
    {
        #region Public Methods

        /// <summary>
        /// Get the color from position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color ColorFromPosition(Point position)
        {
            Bitmap _pixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

            using (Graphics _graphicsDestination = Graphics.FromImage(_pixel))
            {
                using (Graphics _graphicsSource = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr handleContextSource = _graphicsSource.GetHdc();
                    IntPtr handleContextDestination = _graphicsDestination.GetHdc();
                    int _retrievedResult = GDI32.BitBlt(handleContextDestination, 0, 0, 1, 1, handleContextSource, position.X, position.Y, (int)CopyPixelOperation.SourceCopy);
                    _graphicsDestination.ReleaseHdc();
                    _graphicsSource.ReleaseHdc();
                }
            }

            return _pixel.GetPixel(0, 0);
        }

        /// <summary>
        /// Get the color underneath the cursor.
        /// </summary>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color CursorPointerColor()
        {
            Point cursor = new Point();
            User32.GetCursorPos(ref cursor);
            return ColorFromPosition(cursor);
        }

        /// <summary>
        /// Converts the HTML <see cref="string"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="htmlColor">The html color.</param>
        /// <param name="alpha">The alpha value.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color FromHtml(string htmlColor, int alpha = 255)
        {
            if (string.IsNullOrEmpty(htmlColor))
            {
                throw new ArgumentNullException(nameof(htmlColor), "Cannot be null or empty.");
            }

            if (htmlColor[0] != '#')
            {
                htmlColor = "#" + htmlColor;
            }

            if (htmlColor == "#00FFFFFF")
            {
                return Color.Transparent;
            }
            else
            {
                return Color.FromArgb(alpha > 255 ? 255 : alpha, ColorTranslator.FromHtml(htmlColor));
            }
        }

        /// <summary>
        /// Insert the color on to another color.
        /// </summary>
        /// <param name="baseColor">The base color.</param>
        /// <param name="insertColor">The insertColor.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color InsertColor(Color baseColor, Color insertColor)
        {
            return Color.FromArgb((baseColor.R + insertColor.R) / 2, (baseColor.G + insertColor.G) / 2, (baseColor.B + insertColor.B) / 2);
        }

        /// <summary>
        /// Converts the <see cref="Color"/> to a HTML <see cref="string"/>.
        /// </summary>
        /// <param name="color">The color to convert to HTML.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static string ToHtml(this Color color)
        {
            if (color == Color.Empty)
            {
                return "#000000";
            }

            return ColorTranslator.ToHtml(color);
        }

        /// <summary>
        /// Retrieves the transition color between two other colors.
        /// </summary>
        /// <param name="value">The progress value in the transition.</param>
        /// <param name="beginColor">The beginning color.</param>
        /// <param name="endColor">The ending color.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color TransitionColor(int value, Color beginColor, Color endColor)
        {
            try
            {
                try
                {
                    int _red = int.Parse(Math.Round(beginColor.R + ((endColor.R - beginColor.R) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    int _green = int.Parse(Math.Round(beginColor.G + ((endColor.G - beginColor.G) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    int _blue = int.Parse(Math.Round(beginColor.B + ((endColor.B - beginColor.B) * value * 0.01), 0).ToString(CultureInfo.CurrentCulture));
                    return Color.FromArgb(byte.MaxValue, _red, _green, _blue);
                }
                catch (Exception)
                {
                    return beginColor;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion Public Methods
    }
}