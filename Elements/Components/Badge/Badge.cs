using Elements.Base;
using Elements.Components.Gradient;
using Elements.Constants;
using Elements.Controls.Tile;
using Elements.Models;
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
    /// <seealso cref="ComponentBase"/>
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
        #region Private Fields

        private Action _clickEvent;
        private Control _control;
        private Tile _tile;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Badge"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public Badge(IContainer container) : this()
        {
            container.Add(this);
        }

        #endregion Public Constructors

        #region Private Constructors

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

        #endregion Private Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [click].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
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
        [Description(EventDescription.PropertyChanged)]
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

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
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
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Control)]
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
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Font)]
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
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Location)]
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
        [Description(PropertyDescription.Size)]
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
        [Description(PropertyDescription.Text)]
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
        /// Gets or sets the text style.
        /// </summary>
        /// <value>The text style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
        /// Gets or sets the tile.
        /// </summary>
        /// <value>The tile.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
        /// Gets or sets a value indicating whether this <see cref="Badge"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Visible)]
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

        #endregion Public Properties

        #region Public Methods

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

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}