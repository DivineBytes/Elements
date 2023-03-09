using Elements.Designer;
using System.Collections;

namespace Elements.Controls.ControlBox
{
    internal class ControlBoxDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}