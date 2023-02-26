using System.Collections;
using System.ComponentModel.Design;

namespace Elements.Designer
{
    internal class BaseComponentDesigner : ComponentDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
        }
    }
}