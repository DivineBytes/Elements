using Elements.Designer;
using System.Collections;

namespace Elements.Controls.RadialProgress
{
    internal class RatingDesigner : BaseControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}