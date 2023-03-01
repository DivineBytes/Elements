using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Tile
{
    internal class TileDesigner : BaseControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BackColor");
            properties.Remove("ForeColor");

            base.PreFilterProperties(properties);
        }
    }
}