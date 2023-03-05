using Elements.Constants;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="Watermark"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The watermark.")]
    [DesignerCategory(PropertyCategory.Appearance)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class Watermark
    {
        #region Private Fields

        private Color _color;
        private Font _font;
        private string _text;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Watermark"/> class.
        /// </summary>
        public Watermark()
        {
            _color = Color.Gray;
            _font = Control.DefaultFont;
            _text = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Watermark"/> class.
        /// </summary>
        /// <param name="color">The c.</param>
        /// <param name="font">The f.</param>
        /// <param name="text">The t.</param>
        public Watermark(Color color, Font font, string text) : this()
        {
            _color = color;
            _font = font;
            _text = text;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [DefaultValue("")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Draws the Watermark Text in the client area of the <see
        /// cref="System.Windows.Forms.Control"/> using the default font and color.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="horizontalAlignment">The horizontal alignment.</param>
        /// <param name="verticalAlignment">The vertical alignment.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="watermark">The watermark.</param>
        public static void Render(Graphics graphics, Color backColor, Rectangle rectangle, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, RightToLeft rightToLeft, Watermark watermark)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;

            if (rightToLeft == RightToLeft.Yes)
            {
                flags |= TextFormatFlags.RightToLeft;
                switch (horizontalAlignment)
                {
                    case HorizontalAlignment.Center:
                        flags |= TextFormatFlags.HorizontalCenter;
                        rectangle.Offset(0, 1);
                        break;

                    case HorizontalAlignment.Left:
                        flags |= TextFormatFlags.Right;
                        rectangle.Offset(1, 1);
                        break;

                    case HorizontalAlignment.Right:
                        flags |= TextFormatFlags.Left;
                        rectangle.Offset(0, 1);
                        break;
                }
            }
            else
            {
                flags &= ~TextFormatFlags.RightToLeft;
                switch (horizontalAlignment)
                {
                    case HorizontalAlignment.Center:
                        flags |= TextFormatFlags.HorizontalCenter;
                        rectangle.Offset(0, 1);
                        break;

                    case HorizontalAlignment.Left:
                        flags |= TextFormatFlags.Left;
                        rectangle.Offset(1, 1);
                        break;

                    case HorizontalAlignment.Right:
                        flags |= TextFormatFlags.Right;
                        rectangle.Offset(0, 1);
                        break;
                }
            }

            switch (verticalAlignment)
            {
                case VerticalAlignment.Top:
                    flags |= TextFormatFlags.Top;
                    break;

                case VerticalAlignment.Center:
                    flags |= TextFormatFlags.VerticalCenter;
                    break;

                case VerticalAlignment.Bottom:
                    flags |= TextFormatFlags.Bottom;
                    break;
            }

            TextRenderer.DrawText(graphics, watermark.Text, watermark.Font, rectangle, watermark.Color, backColor, flags);
        }

        /// <summary>
        /// Draws the Watermark Text in the client area of the <see
        /// cref="System.Windows.Forms.Control"/> using the default font and color.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="horizontalAlignment">The horizontal alignment.</param>
        /// <param name="verticalAlignment">The vertical alignment.</param>
        /// <param name="rightToLeft">The right to left.</param>
        public void Render(Graphics graphics, Color backColor, Rectangle rectangle, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, RightToLeft rightToLeft)
        {
            Render(graphics, backColor, rectangle, horizontalAlignment, verticalAlignment, rightToLeft, this);
        }

        #endregion Public Methods
    }
}