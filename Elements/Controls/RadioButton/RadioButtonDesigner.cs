using Elements.Designer;
using System.Collections;
using System.ComponentModel.Design;

namespace Elements.Controls.RadioButton
{
    internal class RadioButtonDesigner : ControlDesignerBase
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
                    _actionListCollection = new DesignerActionListCollection { new RadioButtonActionList(Component) };
                }

                return _actionListCollection;
            }
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
        }

        #endregion Protected Methods
    }
}