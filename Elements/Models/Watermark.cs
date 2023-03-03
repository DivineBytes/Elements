using Elements.Constants;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

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
        private const int WM_KILLFOCUS = 0x0008;
        private const int WM_PAINT = 0x000F;

        private Color _color;
        private Font _font;
        private string _text;

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

        /// <summary>
        /// Draws the Watermark Text in the client area of the <see
        /// cref="System.Windows.Forms.TextBox"/> using the default font and color.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="control">The control.</param>
        public void Render(Graphics graphics, TextBox control)
        {
            Render(graphics, control, this);
        }

        /// <summary>
        /// Draws the Watermark Text in the client area of the <see
        /// cref="System.Windows.Forms.TextBox"/> using the default font and color.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="control">The control.</param>
        /// <param name="watermark">The watermark.</param>
        public static void Render(Graphics graphics, TextBox control, Watermark watermark)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
            Rectangle rectangle = control.ClientRectangle;

            if (control.RightToLeft == RightToLeft.Yes)
            {
                flags |= TextFormatFlags.RightToLeft;
                switch (control.TextAlign)
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
                switch (control.TextAlign)
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

            TextRenderer.DrawText(graphics, watermark.Text, watermark.Font, rectangle, watermark.Color, control.BackColor, flags);
        }
    }
}