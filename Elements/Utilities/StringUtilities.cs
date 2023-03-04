using Elements.Enumerators;
using Elements.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="StringUtilities"/> class.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Retrieves the appropriate string format.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="lineAlignment">The line Alignment.</param>
        /// <returns>The <see cref="StringFormat"/>.</returns>
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

        /// <summary>Measures the specified string when draw with the specified font.</summary>
        /// <param name="text">The text to measure.</param>
        /// <param name="font">The font to apply to the measured text.</param>
        /// <returns>The <see cref="Size" />.</returns>
        public static Size MeasureText(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
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

        /// <summary>
        /// Adds the spaces to sentence.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                {
                    newText.Append(' ');
                }

                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        /// <summary>Removes the line breaks and new lines from the text.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string RemoveLineBreaks(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return text.Replace(Environment.NewLine, " ");
        }

        /// <summary>
        /// Render the text using the string format.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="color">The fore color.</param>
        /// <param name="stringFormat">The string Format.</param>
        public static void Render(Graphics graphics, Rectangle clientRectangle, string text, Font font, Color color, StringFormat stringFormat)
        {
            graphics.DrawString(text, font, new SolidBrush(color), clientRectangle, stringFormat);
        }

        /// <summary>
        /// Render the text using the text style.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="mouseState">The mouse State.</param>
        /// <param name="textStyle">The text Style.</param>
        public static void Render(Graphics graphics, Rectangle clientRectangle, string text, Font font, bool enabled, MouseStates mouseState, TextStyle textStyle)
        {
            Color _textColor = TextStyle.GetColorState(enabled, mouseState, textStyle);
            Render(graphics, clientRectangle, text, font, _textColor, textStyle.StringFormat);
        }

        /// <summary>The amount of lines in the <see cref="string" />.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="int" />.</returns>
        public static int LineCount(this string text)
        {
            // int numLinesMethod = text.Length - text.Replace(Environment.NewLine, string.Empty).Length;
            int numLines = text.Split('\n').Length;
            return numLines;
        }

        /// <summary>Returns the text as a <see cref="string" /><see cref="Array" />.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string[] Lines(string text)
        {
            return text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        /// <summary>Removes the white spaces.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string RemoveWhiteSpaces(string text)
        {
            return new string(text.Where(_char => !char.IsWhiteSpace(_char)).ToArray());
        }

        /// <summary>Reverse the <see cref="string" />.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Reverse(string text)
        {
            char[] _chars = text.ToCharArray();
            Array.Reverse(_chars);
            return new string(_chars);
        }
    }
}