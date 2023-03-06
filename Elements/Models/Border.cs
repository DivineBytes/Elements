using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.TypeConverters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="Border"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The border options.")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class Border : RectangleShape
    {
        #region Public Fields

        /// <summary>
        /// The default <see cref="Border"/>.
        /// </summary>
        public new static readonly Border Default = new Border();

        #endregion Public Fields

        #region Private Fields

        private HoverColorState _colorState;
        private bool _hoverVisible;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        public Border()
        {
            _colorState = new HoverColorState(
            System.Drawing.Color.FromArgb(180, 180, 180),
            System.Drawing.Color.FromArgb(180, 180, 180),
            System.Drawing.Color.FromArgb(120, 183, 230));

            _hoverVisible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        public Border(HoverColorState colorState) : this(colorState, Default.Thickness)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="thickness">The thickness.</param>
        public Border(HoverColorState colorState, int thickness) : this(colorState, thickness, Default.Rounding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="rounding">The rounding.</param>
        public Border(HoverColorState colorState, int thickness, int rounding) : this(colorState, thickness, rounding, Default.Shape)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        public Border(HoverColorState colorState, int thickness, int rounding, TileShape shape) : this(colorState, thickness, rounding, shape, Default.Visible)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public Border(HoverColorState colorState, int thickness, int rounding, TileShape shape, bool visible) : this(colorState, thickness, rounding, shape, visible, Default.HoverVisible)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        /// <param name="hoverVisible">if set to <c>true</c> [hover visible].</param>
        public Border(HoverColorState colorState, int thickness, int rounding, TileShape shape, bool visible, bool hoverVisible) : this()
        {
            _colorState = colorState;
            Thickness = thickness;
            Rounding = rounding;
            Shape = shape;
            Visible = visible;
            _hoverVisible = hoverVisible;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [hover visible changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The visible.")]
        public event VisibleChangedEventHandler HoverVisibleChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the color.
        /// </summary>
        /// <value>The state of the color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new HoverColorState Color
        {
            get
            {
                return _colorState;
            }

            set
            {
                _colorState = value;
                OnColorStateChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hover visible].
        /// </summary>
        /// <value><c>true</c> if [hover visible]; otherwise, <c>false</c>.</value>
        public bool HoverVisible
        {
            get
            {
                return _hoverVisible;
            }

            set
            {
                _hoverVisible = value;
                OnHoverVisibleChanged(this, EventArgs.Empty);
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates a border type path.
        /// </summary>
        /// <param name="border">The border.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public static GraphicsPath CreatePath(Border border, Rectangle rectangle)
        {
            return CreatePath(rectangle, border.Rounding, border.Thickness, border.Shape);
        }

        /// <summary>
        /// Draws a border with the specified shape.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="border">The border.</param>
        /// <param name="rectangle">The rectangle.</param>
        public static void Render(Graphics graphics, Border border, Rectangle rectangle)
        {
            Render(graphics, rectangle, border.Color.Enabled, border.Rounding, border.Thickness, border.Shape);
        }

        /// <summary>
        /// Draws a border around the rectangle, with the specified mouse state.
        /// </summary>
        /// <param name="graphics">Graphics controller.</param>
        /// <param name="border">The border type.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <param name="rectangle">The rectangle.</param>
        public static void Render(Graphics graphics, Border border, MouseStates mouseState, Rectangle rectangle)
        {
            if (!border.Visible)
            {
                return;
            }

            switch (mouseState)
            {
                case MouseStates.Normal:
                    {
                        Render(graphics, rectangle, border.Color.Enabled, border.Rounding, border.Thickness, border.Shape);
                        break;
                    }

                case MouseStates.Hover:
                case MouseStates.Pressed:
                    {
                        Color c;
                        if (border.HoverVisible)
                        {
                            c = border.Color.Hover;
                        }
                        else
                        {
                            c = border.Color.Enabled;
                        }

                        Render(graphics, rectangle, c, border.Rounding, border.Thickness, border.Shape);
                        break;
                    }
            }
        }

        /// <summary>
        /// Draws a border around the custom path, with the specified mouse state.
        /// </summary>
        /// <param name="graphics">Graphics controller.</param>
        /// <param name="border">The border type.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <param name="customPath">The custom Path.</param>
        public static void Render(Graphics graphics, Border border, MouseStates mouseState, GraphicsPath customPath)
        {
            if (!border.Visible)
            {
                return;
            }

            switch (mouseState)
            {
                case MouseStates.Normal:
                    {
                        Render(graphics, customPath, border.Color.Enabled, border.Thickness);
                        break;
                    }

                case MouseStates.Hover:
                case MouseStates.Pressed:
                    {
                        Color c;
                        if (border.HoverVisible)
                        {
                            c = border.Color.Hover;
                        }
                        else
                        {
                            c = border.Color.Enabled;
                        }

                        Render(graphics, customPath, c, border.Thickness);
                        break;
                    }
            }
        }

        /// <summary>
        /// Creates a border type path.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public GraphicsPath CreatePath(Rectangle rectangle)
        {
            return CreatePath(this, rectangle);
        }
        /// <summary>
        /// Draws a border with the specified shape.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void Render(Graphics graphics, Rectangle rectangle)
        {
            Render(graphics, this, rectangle);
        }

        /// <summary>
        /// Draws a border with the specified shape.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="mouseState">State of the mouse.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void Render(Graphics graphics, MouseStates mouseState, Rectangle rectangle)
        {
            Render(graphics, this, mouseState, rectangle);
        }

        /// <summary>
        /// Draws a border with the specified shape.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="mouseState">State of the mouse.</param>
        /// <param name="customPath">The custom path.</param>
        public void Render(Graphics graphics, MouseStates mouseState, GraphicsPath customPath)
        {
            Render(graphics, this, mouseState, customPath);
        }
        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Invokes the hover visible changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnHoverVisibleChanged(object sender, EventArgs e)
        {
            HoverVisibleChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods
    }
}