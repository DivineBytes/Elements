using Elements.Constants;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Elements.Controls.RadioButton
{
    internal class RadioButtonActionList : DesignerActionList
    {
        #region Private Fields

        private RadioButton _control;
        private DesignerActionUIService _designerService;

        #endregion Private Fields

        #region Public Constructors

        public RadioButtonActionList(IComponent component) : base(component)
        {
            _control = (RadioButton)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        #endregion Public Constructors

        #region Public Properties

        [Category(Constants.PropertyCategory.Behavior)]
        [DefaultValue(false)]
        [Description(PropertyDescription.Checked)]
        public virtual bool Checked
        {
            get
            {
                return _control.Checked;
            }

            set
            {
                _control.Checked = value;
                _control.Invalidate();
            }
        }

        #endregion Public Properties

        #region Public Methods

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
            {
                new DesignerActionPropertyItem("Checked", "Checked"),
            };

            return items;
        }

        #endregion Public Methods
    }
}