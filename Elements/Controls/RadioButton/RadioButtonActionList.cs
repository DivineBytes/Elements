using System.ComponentModel;
using System.ComponentModel.Design;

namespace Elements.Controls.RadioButton
{
    internal class RadioButtonActionList : DesignerActionList
    {
        #region Private Fields

        private Elements.Controls.RadioButton.RadioButton _control;
        private DesignerActionUIService _designerService;

        #endregion Private Fields

        #region Public Constructors

        public RadioButtonActionList(IComponent component) : base(component)
        {
            _control = (Elements.Controls.RadioButton.RadioButton)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        #endregion Public Constructors

        #region Public Properties

        [DefaultValue(false)]
        [Category(Constants.PropertyCategory.Behavior)]
        [Description("Gets or sets a value indicating whether this control is checked.")]
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