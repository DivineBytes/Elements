using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Button
{
    internal class ButtonDesigner : ControlDesignerBase
    {
        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("Text");

            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}