using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Tile
{
    internal class TileDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BackColor");
            properties.Remove("ForeColor");

            base.PreFilterProperties(properties);
        }
    }
}