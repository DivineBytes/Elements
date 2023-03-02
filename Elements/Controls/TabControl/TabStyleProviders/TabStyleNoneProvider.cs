#region Namespaces

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace Elements.Controls.TabControl.TabStyleProviders
{
    [ToolboxItem(false)]
    public class TabStyleNoneProvider : TabStyleProvider
    {
        public TabStyleNoneProvider(TabControl tabControl) : base(tabControl)
        {
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
        }
    }
}