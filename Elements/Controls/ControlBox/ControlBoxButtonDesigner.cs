using Elements.Designer;
using System.Collections;

namespace Elements.Controls.ControlBox
{
    internal class ControlBoxButtonDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            //properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }
    }
}