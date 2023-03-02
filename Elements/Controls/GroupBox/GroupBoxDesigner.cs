using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Button
{
    internal class GroupBoxDesigner : BaseControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}