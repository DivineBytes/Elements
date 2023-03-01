using Elements.Base;
using Elements.Components.Gradient;
using Elements.Controls.Tile;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Components.Badge
{
    /// <summary>
    /// The <see cref="Badge"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ComponentBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Control")]
    [Description("The badge component enables controls to have a badge with text displayed.")]
    [Designer(typeof(BadgeDesigner))]
    [ToolboxBitmap(typeof(Badge), "Badge.bmp")]
    [ToolboxItem(true)]
    public class Badge : ComponentBase
    {
        private Action<Control> _clickEvent;
        private Control _control;
        private Tile _tile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Badge"/> class.
        /// </summary>
        public Badge()
        {
            _tile = new Tile();
        }


        /// <summary>Initializes a new instance of the <see cref="Badge" /> class.</summary>
        /// <param name="container">The container.</param>
        public Badge(IContainer container) : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// Gets or sets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public Tile Tile
        {
            get
            {
                return _tile;
            }

            set
            {
                _tile = value;
            }
        }
    }
}