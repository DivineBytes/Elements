using Elements.Designer;
using System.Collections;
using System.ComponentModel.Design;

namespace Elements.Controls.TextBox
{
    internal class TextBoxDesigner : ControlDesignerBase
    {
        #region Private Fields

        private DesignerActionListCollection _actionListCollection;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionListCollection == null)
                {
                    _actionListCollection = new DesignerActionListCollection { new TextBoxActionList(Component) };
                }

                return _actionListCollection;
            }
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            //properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}