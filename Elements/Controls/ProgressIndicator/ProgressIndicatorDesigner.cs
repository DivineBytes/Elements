using Elements.Designer;
using System.Collections;

namespace Elements.Controls.ProgressIndicator
{
    internal class ProgressIndicatorDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}