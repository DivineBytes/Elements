using System.Drawing;
using System.Windows.Forms;

namespace Elements.Components.ToolTip
{
    /// <summary>
    /// The <see cref="TipInfo"/> class.
    /// </summary>
    public class TipInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipInfo"/> class.
        /// </summary>
        public TipInfo()
        {
            Caption = string.Empty;
            Control = null;
            Icon = ToolTipIcon.None;
            Image = null;
            Position = new Point();
            Text = string.Empty;
            Type = ToolTipType.Default;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> title to display when the pointer is on the control.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> control.
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// Gets or sets a value that defines the type of icon to be displayed along side <see
        /// cref="ToolTip"/> Text.
        /// </summary>
        public ToolTipIcon Icon { get; set; }

        /// <summary>
        /// Gets or sets a value that defines the type of image to be displayed along side <see
        /// cref="ToolTip"/> Text.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> position.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> size.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> text content to display when the pointer is on
        /// the control.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value that defines the type to be displayed.
        /// </summary>
        public ToolTipType Type { get; set; }

        #endregion Public Properties
    }
}