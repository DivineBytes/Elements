using Elements.Utilities.Designer;
using System.Collections;
using System.Windows.Forms.Design;

namespace Elements.Designer
{
    internal class ParentControlDesignerBase : ParentControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            DesignerUtilities.ConfigureFilter(properties);

            base.PreFilterProperties(properties);
        }
    }
}