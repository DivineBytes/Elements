using Elements.Base;
using Elements.Components.Gradient;
using Elements.Constants;
using Elements.Controls.Tile;
using Elements.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
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
    [DefaultProperty("Text")]
    [Description("The badge component enables controls to have a badge with text displayed.")]
    [Designer(typeof(BadgeDesigner))]
    [ToolboxBitmap(typeof(Badge), "Badge.bmp")]
    [ToolboxItem(true)]
    public class Badge : ComponentBase
    {
        private Action _clickEvent;
        private Control _control;
        private Tile _tile;

        /// <summary>
        /// Prevents a default instance of the <see cref="Badge"/> class from being created.
        /// </summary>
        private Badge()
        {
            _clickEvent = null;
            _control = null;

            _tile = new Tile
            {
                Size = new Size(25, 20),
                Text = "0"
            };

            _tile.BackColorState.Enabled = Color.FromArgb(120, 183, 230);
            _tile.TextStyle.Enabled = Color.White;

            _tile.Click += Tile_Click;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Badge"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public Badge(IContainer container) : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// Occurs when [click].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event EventHandler Click
        {
            add
            {
                _tile.Click += value;
            }
            remove
            {
                _tile.Click -= value;
            }
        }

        /// <summary>
        /// Occurs when [text changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event EventHandler TextChanged
        {
            add
            {
                _tile.TextChanged += value;
            }
            remove
            {
                _tile.TextChanged -= value;
            }
        }

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("The control to attach this component.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Control Control
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;

                if (_control == null)
                {
                    return;
                }

                if (Visible)
                {
                    Attach();
                }
                else
                {
                    Remove();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Badge"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("Toggles the visibility.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool Visible
        {
            get
            {
                return _tile.Visible;
            }

            set
            {
                _tile.Visible = value;

                if (_control == null)
                {
                    return;
                }

                if (Visible)
                {
                    Attach();
                }
                else
                {
                    Remove();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The font.")]
        public Font Font
        {
            get
            {
                return _tile.Font;
            }

            set
            {
                _tile.Font = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text style.
        /// </summary>
        /// <value>The text style.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The text style.")]
        public TextStyle TextStyle
        {
            get
            {
                return _tile.TextStyle;
            }

            set
            {
                _tile.TextStyle = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The back color state.")]
        public ControlColorState BackColorState
        {
            get
            {
                return _tile.BackColorState;
            }

            set
            {
                _tile.BackColorState = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The location.")]
        public Point Location
        {
            get
            {
                return _tile.Location;
            }

            set
            {
                _tile.Location = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The size.")]
        public Size Size
        {
            get
            {
                return _tile.Size;
            }

            set
            {
                _tile.Size = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The text.")]
        public string Text
        {
            get
            {
                return _tile.Text;
            }

            set
            {
                _tile.Text = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the tile.
        /// </summary>
        /// <value>The tile.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The tile control.")]
        public Tile Tile
        {
            get
            {
                return _tile;
            }

            set
            {
                _tile = value;
                _tile.Invalidate();
            }
        }

        /// <summary>
        /// Sets the click action for the <see cref="Badge"/>.
        /// </summary>
        /// <param name="action">The click action to set.</param>
        public void SetClickAction(Action action)
        {
            if (_tile != null)
            {
                _clickEvent = action;
            }
        }

        /// <summary>
        /// Attach the <see cref="Badge"/> to the control.
        /// </summary>
        private void Attach()
        {
            _control.Controls.Add(_tile);
        }

        /// <summary>
        /// Remove the <see cref="Badge"/> from the control.
        /// </summary>
        private void Remove()
        {
            if (_tile != null)
            {
                _control.Controls.Remove(_tile);
            }
        }

        /// <summary>
        /// Handles the Click event of the Tile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tile_Click(object sender, EventArgs e)
        {
            _clickEvent?.Invoke();
        }
    }
}