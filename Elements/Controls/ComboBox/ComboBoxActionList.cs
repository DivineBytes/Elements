using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Elements.Controls.TextBox
{
    internal class ComboBoxActionList : DesignerActionList
    {
        #region Private Fields

        private ComboBox.ComboBox _control;
        private DesignerActionUIService _designerService;

        #endregion Private Fields

        #region Public Constructors

        public ComboBoxActionList(IComponent component) : base(component)
        {
            _control = (ComboBox.ComboBox)component;
            _designerService = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
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

        #endregion Public Properties

        #region Public Methods

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection
            {
                new DesignerActionPropertyItem("Items", "Edit Items..."),
            };

            return items;
        }

        #endregion Public Methods
    }
}