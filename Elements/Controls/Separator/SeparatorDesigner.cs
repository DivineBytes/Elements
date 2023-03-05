using Elements.Designer;
using System.Collections;

namespace Elements.Controls.Separator
{
    internal class SeparatorDesigner : ControlDesignerBase
    {
        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("ForeColor");
            properties.Remove("Text");

            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}