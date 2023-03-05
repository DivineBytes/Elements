using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Label
{
    internal class LabelDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }
    }
}