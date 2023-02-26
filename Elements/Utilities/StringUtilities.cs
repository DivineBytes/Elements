using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="StringUtilities"/> class.
    /// </summary>
    public static class StringUtilities
    {

        /// <summary>Retrieves the appropriate string format.</summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="lineAlignment">The line Alignment.</param>
        /// <returns>The <see cref="StringFormat" />.</returns>
        public static StringFormat GetOrientedStringFormat(Orientation orientation, StringAlignment alignment, StringAlignment lineAlignment)
        {
            StringFormat orientedStringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            switch (orientation)
            {
                case Orientation.Horizontal:
                    {
                        orientedStringFormat = new StringFormat { Alignment = alignment, LineAlignment = lineAlignment };
                        break;
                    }

                case Orientation.Vertical:
                    {
                        orientedStringFormat = new StringFormat { Alignment = alignment, LineAlignment = lineAlignment, FormatFlags = StringFormatFlags.DirectionVertical };
                        break;
                    }
            }

            return orientedStringFormat;
        }

        /// <summary>
        /// Measures the specified string when draw with the specified font.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to apply to the measured text.</param>
        /// <param name="graphics">The specified graphics input.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        public static Size MeasureText(string text, Font font, Graphics graphics = null)
        {
            Graphics _graphics = graphics ?? new Control().CreateGraphics();
            int _width = Convert.ToInt32(_graphics.MeasureString(text, font).Width);
            int _height = Convert.ToInt32(_graphics.MeasureString(text, font).Height);
            return new Size(_width, _height);
        }

        /// <summary>
        /// Measures the specified string when draw with the specified font.
        /// </summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to apply to the measured text.</param>
        /// <param name="graphics">The specified graphics input.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        public static SizeF MeasureTextF(string text, Font font, Graphics graphics = null)
        {
            Graphics _graphics = graphics ?? new Control().CreateGraphics();
            float _width = _graphics.MeasureString(text, font).Width;
            float _height = _graphics.MeasureString(text, font).Height;
            return new SizeF(_width, _height);
        }
    }
}