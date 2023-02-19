using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls
{
    /// <summary>
    /// The <see cref="TextBoxEx"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TextBox"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("TextChanged")]
    [DefaultProperty("Text")]
    [Description("The TextBox")]
    [Designer(typeof(TextBoxExDesigner))]
    [ToolboxBitmap(typeof(TextBoxEx), "TextBoxEx.bmp")]
    [ToolboxItem(true)]
    public class TextBoxEx : TextBox
    {
        private const int WM_KILLFOCUS = 0x0008;
        private const int WM_PAINT = 0x000F;

        private string watermarkText;

        public TextBoxEx()
        {
            WatermarkColor = Color.Gray;
            WatermarkFont = DefaultFont;
        }

        public Color WatermarkColor { get; set; }

        public Font WatermarkFont { get; set; }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (ShouldRenderPlaceHolderText(m))
            {
                Graphics g = CreateGraphics();
                DrawWatermarkText(g);
            }
        }

        /// <summary>
        /// Gets or sets the text that is displayed when the control has no text and does not have
        /// the focus.
        /// </summary>
        /// <value>
        /// The text that is displayed when the control has no text and does not have the focus.
        /// </value>
        [Localizable(true)]
        [DefaultValue("")]
        public virtual string WatermarkText
        {
            get
            {
                return watermarkText;
            }

            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }

                if (watermarkText != value)
                {
                    watermarkText = value;
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Draws the Watermark Text in the client area of the <see cref="TextBox"/> using the
        /// default font and color.
        /// </summary>
        private void DrawWatermarkText(Graphics graphics)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
            Rectangle rectangle = ClientRectangle;

            if (RightToLeft == RightToLeft.Yes)
            {
                flags |= TextFormatFlags.RightToLeft;
                switch (TextAlign)
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
                switch (TextAlign)
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

            TextRenderer.DrawText(graphics, WatermarkText, WatermarkFont, rectangle, WatermarkColor, BackColor, flags);
        }

        private bool ShouldRenderPlaceHolderText(in Message m)
        {
            return !string.IsNullOrEmpty(WatermarkText) &&
            (m.Msg == WM_PAINT || m.Msg == WM_KILLFOCUS) &&
            !GetStyle(ControlStyles.UserPaint) &&
            !Focused && TextLength == 0;
        }
    }
}