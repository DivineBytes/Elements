using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Elements.Controls
{
    internal class TextBoxExActionList : DesignerActionList
    {
        private TextBoxEx _control;
        private DesignerActionUIService _designerService;

        public TextBoxExActionList(IComponent component) : base(component)
        {
            _control = (TextBoxEx)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        [Category("Behaviour")]
        [Description("Gets or sets a value indicating whether this is a multiline TextBox control.")]
        [DefaultValue(false)]
        public virtual bool Multiline
        {
            get
            {
                return _control.Multiline;
            }

            set
            {
                _control.Multiline = value;
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

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
            {
                new DesignerActionPropertyItem("Multiline", "MultiLine"),
                new DesignerActionPropertyItem("Text", "Edit Text:")
            };

            return items;
        }
    }
}