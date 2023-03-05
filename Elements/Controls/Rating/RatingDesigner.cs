using Elements.Designer;
using System.Collections;

namespace Elements.Controls.RadialProgress
{
    internal class RatingDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}