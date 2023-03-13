using Elements.Base;
using Elements.Constants;
using Elements.Enumerators;
using Elements.Renders;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elements.Controls.Expander
{
    /// <summary>
    /// The <see cref="Expander"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    public class Expander : ControlBase
    {
        #region Private Fields

        private Color _color;
        private int _contractedHeight;
        private Control _control;
        private bool _expanded;
        private Size _original;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight) : this(control, contractedHeight, DefaultColor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="location">The location.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Point location) : this(control, contractedHeight, DefaultColor, false, location, DefaultSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="color">The color.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Color color) : this(control, contractedHeight, color, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="color">The color.</param>
        /// <param name="expanded">if set to <c>true</c> [expanded].</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Color color, bool expanded) : this(control, contractedHeight, color, expanded, Size.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="color">The color.</param>
        /// <param name="size">The size.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Color color, Size size) : this(control, contractedHeight, color, false, size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="color">The color.</param>
        /// <param name="expanded">if set to <c>true</c> [expanded].</param>
        /// <param name="size">The size.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Color color, bool expanded, Size size) : this(control, contractedHeight, color, expanded, Point.Empty, size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expander"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="contractedHeight">Height of the contracted.</param>
        /// <param name="color">The color.</param>
        /// <param name="expanded">if set to <c>true</c> [expanded].</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Expander(Control control, int contractedHeight, Color color, bool expanded, Point location, Size size) : this()
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), ArgumentDescription.CannotBeNull);
            }

            if (size == Size.Empty)
            {
                throw new ArgumentNullException(nameof(size), ArgumentDescription.CannotBeEmpty);
            }

            _control = control;
            _color = color;
            _contractedHeight = contractedHeight;
            _expanded = expanded;

            Location = location;
            Size = size;

            _original = control.Size;

            _control.Controls.Add(this);
        }

        #endregion Public Constructors

        #region Public Fields

        /// <summary>
        /// The Default Color.
        /// </summary>
        public static readonly Color DefaultColor = Color.FromArgb(119, 119, 118);

        /// <summary>
        /// The Default Size.
        /// </summary>
        public static readonly new Size DefaultSize = new Size(10, 8);

        #endregion Public Fields

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="Expander"/> class from being created.
        /// </summary>
        private Expander()
        {
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(10, 8);

            _color = DefaultColor;
            _contractedHeight = 0;

            _original = Size.Empty;
            _expanded = false;
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Color), "Black")]
        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the height of the contracted.
        /// </summary>
        /// <value>The height of the contracted.</value>
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(int), "0")]
        public int ContractedHeight
        {
            get
            {
                return _contractedHeight;
            }

            set
            {
                _contractedHeight = value;
            }
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value>The control.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Control)]
        public Control Control
        {
            get
            {
                return _control;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Expander"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(bool), "true")]
        public bool Expanded
        {
            get
            {
                return _expanded;
            }

            set
            {
                _expanded = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the original.
        /// </summary>
        /// <value>The original.</value>
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(typeof(Size), "0, 0")]
        public Size Original
        {
            get
            {
                return _original;
            }

            set
            {
                _original = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Render the expander button.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="color">The button color.</param>
        /// <param name="size">The size.</param>
        /// <param name="state">The expanded toggle.</param>
        public static void Render(Graphics graphics, Color color, Size size, bool state)
        {
            ControlRender.RenderTriangle(graphics, color, size, state ? Vertical.Up : Vertical.Down);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            int _height;

            if (_expanded)
            {
                _height = _contractedHeight;
                _expanded = false;
            }
            else
            {
                _height = _original.Height;
                _expanded = true;
            }

            Parent.Size = new Size(_original.Width, _height);
            Parent.Invalidate();

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Render(e.Graphics, Color, Size, Expanded);
        }

        #endregion Protected Methods
    }
}