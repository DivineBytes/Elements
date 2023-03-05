using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Label
{
    internal class LabelDesigner : ControlDesignerBase
    {
        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}