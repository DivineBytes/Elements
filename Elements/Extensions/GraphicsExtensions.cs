using System.Drawing;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="GraphicsExtensions"/> class.
    /// </summary>
    /// <remarks>Manages the extensibility of the elements.</remarks>
    public static class GraphicsExtensions
    {
        /// <summary>
        /// Returns the center <see cref="Point"/> of the <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="rectangle">This rectangle.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Top + (rectangle.Height / 2));
        }
    }
}