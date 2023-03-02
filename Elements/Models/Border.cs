using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.TypeConverters;
using Elements.Utilities;
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
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class Border
    {
        private HoverColorState _colorState;
        private int _rounding;
        private TileShape _shape;
        private int _thickness;
        private bool _visible;
        private bool _hoverVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        public Border()
        {
            _colorState = new HoverColorState(
            Color.FromArgb(180, 180, 180),
            Color.FromArgb(208, 208, 208),
            Color.FromArgb(120, 183, 230));

            _thickness = 1;
            _rounding = 6;
            _shape = TileShape.Rectangle;
            _visible = true;
            _hoverVisible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public Border(HoverColorState colorState, int rounding, TileShape shape, int thickness, bool visible) : this()
        {
            _colorState = colorState;
            _thickness = thickness;
            _rounding = rounding;
            _shape = shape;
            _visible = visible;
        }

        /// <summary>
        /// Gets the distance from the rounded border.
        /// </summary>
        [Browsable(false)]
        public int BorderCurve
        {
            get
            {
                return (_rounding / 2) + _thickness + 1;
            }
        }

        /// <summary>
        /// Gets or sets the state of the color.
        /// </summary>
        /// <value>The state of the color.</value>
        public HoverColorState ColorState
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
        /// <value>
        ///   <c>true</c> if [hover visible]; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        public int Thickness
        {
            get
            {
                return _thickness;
            }

            set
            {
                _thickness = value;
                OnThicknessChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the rounding.
        /// </summary>
        /// <value>The rounding.</value>
        public int Rounding
        {
            get
            {
                return _rounding;
            }

            set
            {
                _rounding = value;
                OnRoundingChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public TileShape Shape
        {
            get
            {
                return _shape;
            }

            set
            {
                _shape = value;
                OnShapeChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Border"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
                OnVisibleChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Occurs when [color state changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The color state.")]
        public event ColorChangedEventHandler ColorStateChanged;

        /// <summary>
        /// Occurs when [hover visible changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The visible.")]
        public event VisibleChangedEventHandler HoverVisibleChanged;

        /// <summary>
        /// Occurs when [rounding changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The rounding.")]
        public event RoundingChangedEventHandler RoundingChanged;

        /// <summary>
        /// Occurs when [shape changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The shape.")]
        public event ShapeChangedEventHandler ShapeChanged;

        /// <summary>
        /// Occurs when [thickness changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The thickness.")]
        public event ThicknessChangedEventHandler ThicknessChanged;

        /// <summary>
        /// Occurs when [visible changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("The visible.")]
        public event VisibleChangedEventHandler VisibleChanged;

        /// <summary>
        /// Invokes the color state changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnColorStateChanged(object sender, EventArgs e)
        {
            ColorStateChanged?.Invoke(sender, e);
        }

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

        /// <summary>
        /// Invokes the rounding changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnRoundingChanged(object sender, EventArgs e)
        {
            RoundingChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes the shape changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnShapeChanged(object sender, EventArgs e)
        {
            ShapeChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes the thickness changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnThicknessChanged(object sender, EventArgs e)
        {
            ThicknessChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes the visible changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnVisibleChanged(object sender, EventArgs e)
        {
            VisibleChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Creates a border type path.
        /// </summary>
        /// <param name="border">The border.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public static GraphicsPath CreatePath(Border border, Rectangle rectangle)
        {
            return CreatePath(border.Rounding, border.Thickness, border.Shape, rectangle);
        }

        /// <summary>
        /// Creates a border type path.
        /// </summary>
        /// <param name="rounding">The rounding.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="type">The shape.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public static GraphicsPath CreatePath(int rounding, int thickness, TileShape type, Rectangle rectangle)
        {
            Rectangle _borderRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - thickness, rectangle.Height - thickness);
            GraphicsPath _borderShape = new GraphicsPath();

            switch (type)
            {
                case TileShape.Rectangle:
                    {
                        _borderShape.AddRectangle(_borderRectangle);
                        break;
                    }

                case TileShape.Rounded:
                    {
                        _borderShape.AddArc(rectangle.X, rectangle.Y, rounding, rounding, 180.0F, 90.0F);
                        _borderShape.AddArc(rectangle.Right - rounding, rectangle.Y, rounding, rounding, 270.0F, 90.0F);
                        _borderShape.AddArc(rectangle.Right - rounding, rectangle.Bottom - rounding, rounding, rounding, 0.0F, 90.0F);
                        _borderShape.AddArc(rectangle.X, rectangle.Bottom - rounding, rounding, rounding, 90.0F, 90.0F);
                        break;
                    }
            }

            _borderShape.CloseAllFigures();
            return _borderShape;
        }

        /// <summary>
        /// Draws a border around the rectangle, with the specified thickness.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="color">The color.</param>
        /// <param name="thickness">The thickness.</param>
        public static void Render(Graphics graphics, Rectangle rectangle, Color color, float thickness)
        {
            GraphicsPath _borderGraphicsPath = new GraphicsPath();
            _borderGraphicsPath.AddRectangle(rectangle);
            Pen _borderPen = new Pen(color, thickness);
            graphics.DrawPath(_borderPen, _borderGraphicsPath);
        }

        /// <summary>
        /// Draws a border around the custom graphics path, with the specified thickness.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="customPath">The custom Path.</param>
        /// <param name="color">The color.</param>
        /// <param name="thickness">The thickness.</param>
        public static void Render(Graphics graphics, GraphicsPath customPath, Color color, float thickness)
        {
            Pen _borderPen = new Pen(color, thickness);
            graphics.DrawPath(_borderPen, customPath);
        }

        /// <summary>
        /// Draws a border around the rounded rectangle, with the specified rounding and thickness.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The amount of rounding.</param>
        /// <param name="thickness">The thickness.</param>
        public static void Render(Graphics graphics, Rectangle rectangle, Color color, int rounding, float thickness)
        {
            GraphicsPath _borderGraphicsPath = GraphicsUtilities.DrawRoundedRectangle(rectangle, rounding);
            Pen _borderPen = new Pen(color, thickness);
            graphics.DrawPath(_borderPen, _borderGraphicsPath);
        }

        /// <summary>
        /// Draws a border with the specified shape settings.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="shape">The shape.</param>
        public static void Render(Graphics graphics, Rectangle rectangle, Color color, int rounding, float thickness, TileShape shape)
        {
            switch (shape)
            {
                case TileShape.Rectangle:
                    {
                        Render(graphics, rectangle, color, thickness);
                        break;
                    }

                case TileShape.Rounded:
                    {
                        Render(graphics, rectangle, color, rounding, thickness);
                        break;
                    }
            }
        }

        /// <summary>
        /// Draws a border with the specified shape.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="border">The border.</param>
        /// <param name="rectangle">The rectangle.</param>
        public static void Render(Graphics graphics, Border border, Rectangle rectangle)
        {
            Render(graphics, rectangle, border.ColorState.Enabled, border.Rounding, border.Thickness, border.Shape);
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
                        Render(graphics, rectangle, border.ColorState.Enabled, border.Rounding, border.Thickness, border.Shape);
                        break;
                    }

                case MouseStates.Hover:
                case MouseStates.Pressed:
                    {
                        Color c;
                        if (border.HoverVisible)
                        {
                            c = border.ColorState.Hover;
                        }
                        else
                        {
                            c = border.ColorState.Enabled;
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
                        Render(graphics, customPath, border.ColorState.Enabled, border.Thickness);
                        break;
                    }

                case MouseStates.Hover:
                case MouseStates.Pressed:
                    {
                        Color c;
                        if (border.HoverVisible)
                        {
                            c = border.ColorState.Hover;
                        }
                        else
                        {
                            c = border.ColorState.Enabled;
                        }

                        Render(graphics, customPath, c, border.Thickness);
                        break;
                    }
            }
        }
    }
}