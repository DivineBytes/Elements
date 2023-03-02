using Elements.Enumerators;
using Elements.Models;
using System.Drawing;

namespace Elements.Renders
{
    /// <summary>
    /// The <see cref="TextRender"/> class.
    /// </summary>
    public static class TextRender
    {
        /// <summary>
        /// Render the text in the specified location.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="color">The fore color.</param>
        /// <param name="location">The location.</param>
        public static void Render(Graphics graphics, Rectangle clientRectangle, string text, Font font, Color color, Point location)
        {
            graphics.DrawString(text, font, new SolidBrush(color), new Rectangle(location, clientRectangle.Size));
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
        /// <param name="textStyle">The text Style.</param>
        public static void Render(Graphics graphics, Rectangle clientRectangle, string text, Font font, bool enabled, TextStyle textStyle)
        {
            Color _textColor = enabled ? textStyle.Enabled : textStyle.Disabled;
            Render(graphics, clientRectangle, text, font, _textColor, textStyle.StringFormat);
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
    }
}