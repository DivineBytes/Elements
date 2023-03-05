using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elements.Controls.TabControl.TabStyleProviders
{
    /// <summary>
    /// The <see cref="TabStyleAngledProvider"/> class.
    /// </summary>
    /// <seealso cref="Elements.Controls.TabControl.TabStyleProvider"/>
    [ToolboxItem(false)]
    public class TabStyleAngledProvider : TabStyleProvider
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleAngledProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleAngledProvider(TabControl tabControl) : base(tabControl)
        {
            _ImageAlign = ContentAlignment.MiddleRight;
            _Overlap = 7;
            _Radius = 10;

            // Must set after the _Radius as this is used in the calculations of the actual padding
            Padding = new Point(10, 3);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Adds the tab border.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tabBounds">The tab bounds.</param>
        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
            switch (_TabControl.Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.X, tabBounds.Bottom, tabBounds.X + _Radius - 2, tabBounds.Y + 2);
                    path.AddLine(tabBounds.X + _Radius, tabBounds.Y, tabBounds.Right - _Radius, tabBounds.Y);
                    path.AddLine(tabBounds.Right - _Radius + 2, tabBounds.Y + 2, tabBounds.Right, tabBounds.Bottom);
                    break;

                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.Right, tabBounds.Y, tabBounds.Right - _Radius + 2, tabBounds.Bottom - 2);
                    path.AddLine(tabBounds.Right - _Radius, tabBounds.Bottom, tabBounds.X + _Radius, tabBounds.Bottom);
                    path.AddLine(tabBounds.X + _Radius - 2, tabBounds.Bottom - 2, tabBounds.X, tabBounds.Y);
                    break;

                case TabAlignment.Left:
                    path.AddLine(tabBounds.Right, tabBounds.Bottom, tabBounds.X + 2, tabBounds.Bottom - _Radius + 2);
                    path.AddLine(tabBounds.X, tabBounds.Bottom - _Radius, tabBounds.X, tabBounds.Y + _Radius);
                    path.AddLine(tabBounds.X + 2, tabBounds.Y + _Radius - 2, tabBounds.Right, tabBounds.Y);
                    break;

                case TabAlignment.Right:
                    path.AddLine(tabBounds.X, tabBounds.Y, tabBounds.Right - 2, tabBounds.Y + _Radius - 2);
                    path.AddLine(tabBounds.Right, tabBounds.Y + _Radius, tabBounds.Right, tabBounds.Bottom - _Radius);
                    path.AddLine(tabBounds.Right - 2, tabBounds.Bottom - _Radius + 2, tabBounds.X, tabBounds.Bottom);
                    break;
            }
        }

        #endregion Public Methods
    }
}