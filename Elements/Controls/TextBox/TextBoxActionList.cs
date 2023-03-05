using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Elements.Controls.TextBox
{
    internal class TextBoxActionList : DesignerActionList
    {
        #region Private Fields

        private TextBoxExtended _control;
        private DesignerActionUIService _designerService;

        #endregion Private Fields

        #region Public Constructors

        public TextBoxActionList(IComponent component) : base(component)
        {
            _control = (TextBoxExtended)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        #endregion Public Constructors

        #region Public Properties

        [Category("Behaviour")]
        [Description("Gets or sets a value indicating whether this is a multiline TextBox control.")]
        [DefaultValue(false)]
        public virtual bool MultiLine
        {
            get
            {
                return _control.MultiLine;
            }

            set
            {
                _control.MultiLine = value;
                _control.Invalidate();
            }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(false)]
        public virtual string Text
        {
            get
            {
                return _control.Text;
            }

            set
            {
                _control.Text = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
            {
                new DesignerActionPropertyItem("MultiLine", "MultiLine"),
                new DesignerActionPropertyItem("Text", "Edit Text:")
            };

            return items;
        }

        #endregion Public Methods
    }
}