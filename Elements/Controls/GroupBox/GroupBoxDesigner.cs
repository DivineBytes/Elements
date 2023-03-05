using Elements.Designer;
using System.Collections;

namespace Elements.Controls.GroupBox
{
    internal class GroupBoxDesigner : ParentControlDesignerBase
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