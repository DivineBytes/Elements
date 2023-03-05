using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Elements.Controls.TabControl.TabStyleProviders
{
    /// <summary>
    /// The <see cref="TabStyleNoneProvider"/> class.
    /// </summary>
    /// <seealso cref="Elements.Controls.TabControl.TabStyleProvider"/>
    [ToolboxItem(false)]
    public class TabStyleNoneProvider : TabStyleProvider
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleNoneProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleNoneProvider(TabControl tabControl) : base(tabControl)
        {
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
        }

        #endregion Public Methods
    }
}