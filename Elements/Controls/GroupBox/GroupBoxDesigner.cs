using Elements.Designer;
using System.Collections;
using System.Windows.Forms.Design;

namespace Elements.Controls.GroupBox
{
    internal class GroupBoxDesigner : ParentControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}