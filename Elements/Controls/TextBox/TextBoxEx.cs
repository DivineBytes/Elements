using Elements.Models;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.TextBox
{
    /// <summary>
    /// The <see cref="TextBoxEx"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TextBox"/>
    [Browsable(false)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("TextChanged")]
    [DefaultProperty("Text")]
    [Description("The TextBox")]
    [ToolboxItem(false)]
    public class TextBoxEx : System.Windows.Forms.TextBox
    {
        private const int WM_KILLFOCUS = 0x0008;
        private const int WM_PAINT = 0x000F;

        private Watermark _watermark;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxEx"/> class.
        /// </summary>
        public TextBoxEx()
        {
            _watermark = new Watermark();
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Watermark Watermark
        {
            get { return _watermark; }

            set
            {
                _watermark = value;

                if (IsHandleCreated)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The m.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (ShouldRenderPlaceHolderText(m))
            {
                Graphics g = CreateGraphics();
                _watermark.Render(g, this);
            }
        }

        /// <summary>
        /// Shoulds the render place holder text.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ShouldRenderPlaceHolderText(in Message m)
        {
            return !string.IsNullOrEmpty(_watermark.Text) &&
            (m.Msg == WM_PAINT || m.Msg == WM_KILLFOCUS) &&
            !GetStyle(ControlStyles.UserPaint) &&
            !Focused && TextLength == 0;
        }
    }
}