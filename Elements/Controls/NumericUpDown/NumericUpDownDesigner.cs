using Elements.Designer;
using System.Collections;

namespace Elements.Controls.NumericUpDown
{
    internal class NumericUpDownDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}