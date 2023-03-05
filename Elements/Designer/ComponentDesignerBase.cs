using Elements.Utilities.Designer;
using System.Collections;
using System.ComponentModel.Design;

namespace Elements.Designer
{
    internal class ComponentDesignerBase : ComponentDesigner
    {
        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            DesignerUtilities.ConfigureFilter(properties);

            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}