using Elements.Utilities.Designer;
using System.Collections;
using System.Windows.Forms.Design;

namespace Elements.Designer
{
    internal class ControlDesignerBase : ControlDesigner
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