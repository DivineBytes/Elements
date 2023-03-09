using Elements.Utilities;
using System.Drawing;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="ColorExtensions"/> class.
    /// </summary>
    public static class ColorExtensions
    {
        #region Public Methods

        /// <summary>
        /// Converts the HTML color code to <see cref="Color"/>.
        /// </summary>
        /// <param name="htmlColor">The HTML color.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color FromHtml(this string htmlColor, int alpha = 255)
        {
            return ColorUtilities.FromHtml(htmlColor, alpha);
        }

        #endregion Public Methods
    }
}