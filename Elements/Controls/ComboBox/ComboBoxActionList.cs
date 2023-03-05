using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text.RegularExpressions;

namespace Elements.Controls.TextBox
{
    internal class ComboBoxActionList : DesignerActionList
    {
        private ComboBox.ComboBox _control;
        private DesignerActionUIService _designerService;

        public ComboBoxActionList(IComponent component) : base(component)
        {
            _control = (ComboBox.ComboBox)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [Description("Gets or sets the text.")]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(false)]
        public virtual System.Windows.Forms.ComboBox.ObjectCollection Items
        {
            get
            {
                return _control.Items;
            }

            set
            {
                foreach (object item in value)
                {
                    _control.Items.Add(item);
                }
            }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
            {
                new DesignerActionPropertyItem("Items", "Edit Items..."),
            };

            return items;
        }
    }
}