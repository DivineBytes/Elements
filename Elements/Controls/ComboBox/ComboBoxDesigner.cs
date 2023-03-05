using Elements.Controls.TextBox;
using System.Collections;
using System.ComponentModel.Design;

namespace Elements.Controls.ComboBox
{
    internal class ComboBoxDesigner : Designer.ControlDesignerBase
    {
        private DesignerActionListCollection _actionListCollection;

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionListCollection == null)
                {
                    _actionListCollection = new DesignerActionListCollection { new ComboBoxActionList(Component) };
                }

                return _actionListCollection;
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("Text");

            base.PreFilterProperties(properties);
        }
    }
}