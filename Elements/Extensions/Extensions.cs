using System.Drawing;
using System.Windows.Forms;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="Extensions"/> class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the alignment.
        /// </summary>
        /// <param name="stringAlignment">The string alignment.</param>
        /// <returns>The <see cref="HorizontalAlignment"/>.</returns>
        public static HorizontalAlignment GetAlignment(StringAlignment stringAlignment)
        {
            HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center;

            switch (stringAlignment)
            {
                case StringAlignment.Near:
                    horizontalAlignment = HorizontalAlignment.Left;
                    break;

                case StringAlignment.Center:
                    horizontalAlignment = HorizontalAlignment.Center;
                    break;

                case StringAlignment.Far:
                    horizontalAlignment = HorizontalAlignment.Right;
                    break;
            }

            return horizontalAlignment;
        }
    }
}