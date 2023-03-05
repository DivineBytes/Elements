using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Button
{
    internal class ButtonDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}