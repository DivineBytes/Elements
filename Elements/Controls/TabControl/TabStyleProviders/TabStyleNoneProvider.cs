#region Namespaces

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace Elements.Controls
{
    [ToolboxItem(false)]
    public class TabStyleNoneProvider : TabStyleProvider
    {
        public TabStyleNoneProvider(TabControlEx tabControl) : base(tabControl)
        {
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
        }
    }
}