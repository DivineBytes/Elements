using System.ComponentModel;
using System.ComponentModel.Design;

namespace Elements.Controls.CheckBox
{
    internal class CheckBoxActionList : DesignerActionList
    {
        #region Private Fields

        private CheckBox _control;
        private DesignerActionUIService _designerService;

        #endregion Private Fields

        #region Public Constructors

        public CheckBoxActionList(IComponent component) : base(component)
        {
            _control = (CheckBox)component;
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