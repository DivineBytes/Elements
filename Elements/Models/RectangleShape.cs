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
    /// The <see cref="RectangleShape"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The rectangle shape.")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class RectangleShape
    {
        #region Public Fields

        /// <summary>
        /// The default <see cref="RectangleShape"/>.
        /// </summary>
        public static readonly RectangleShape Default = new RectangleShape();

        #endregion Public Fields

        #region Private Fields

        private Color _color;
        private int _rounding;
        private TileShape _shape;
        private int _thickness;
        private bool _visible;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        public RectangleShape()
        {
            _color = Color.FromArgb(180, 180, 180);
            _thickness = 1;
            _rounding = 6;
            _shape = TileShape.Rounded;
            _visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public RectangleShape(Color color) : this(color, Default.Rounding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The rounding.</param>
        public RectangleShape(Color color, int rounding) : this(color, rounding, Default.Shape)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        public RectangleShape(Color color, int rounding, TileShape shape) : this(color, rounding, shape, Default.Thickness)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="thickness">The thickness.</param>
        public RectangleShape(Color color, int rounding, TileShape shape, int thickness) : this(color, rounding, shape, thickness, Default.Visible)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleShape"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public RectangleShape(Color color, int rounding, TileShape shape, int thickness, bool visible) : this()
        {
            _color = color;
            _rounding = rounding;
            _shape = shape;
            _thickness = thickness;
            _visible = visible;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [color state changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.ColorChanged)]
        public event ColorChangedEventHandler ColorStateChanged;

        /// <summary>
        /// Occurs when [rounding changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event RoundingChangedEventHandler RoundingChanged;

        /// <summary>
        /// Occurs when [shape changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ShapeChangedEventHandler ShapeChanged;

        /// <summary>
        /// Occurs when [thickness changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ThicknessChangedEventHandler ThicknessChanged;

        /// <summary>
        /// Occurs when [visible changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event VisibleChangedEventHandler VisibleChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets the distance from the rounded border.
        /// </summary>
        [Browsable(false)]
        public int BorderCurve
        {
            get
            {
                return (Rounding / 2) + Thickness + 1;
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
                OnColorStateChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the <see cref="RectangleShape"/> display distance based on thickness and visibility.
        /// </summary>
        [Browsable(false)]
        public int Distance
        {
            get
            {
                return Visible ? Thickness : 0;
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

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates a path of the shape.
        /// </summary>
        /// <param name="rectangleShape">The rectangle shape.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public static GraphicsPath CreatePath(RectangleShape rectangleShape, Rectangle rectangle)
        {
            Rectangle _shapeRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - rectangleShape.Thickness, rectangle.Height - rectangleShape.Thickness);
            GraphicsPath _shapePath = new GraphicsPath();

            switch (rectangleShape.Shape)
            {
                case TileShape.Rectangle:
                    {
                        _shapePath.AddRectangle(_shapeRectangle);
                        break;
                    }

                case TileShape.Rounded:
                    {
                        _shapePath.AddArc(rectangle.X, rectangle.Y, rectangleShape.Rounding, rectangleShape.Rounding, 180.0F, 90.0F);
                        _shapePath.AddArc(rectangle.Right - rectangleShape.Rounding, rectangle.Y, rectangleShape.Rounding, rectangleShape.Rounding, 270.0F, 90.0F);
                        _shapePath.AddArc(rectangle.Right - rectangleShape.Rounding, rectangle.Bottom - rectangleShape.Rounding, rectangleShape.Rounding, rectangleShape.Rounding, 0.0F, 90.0F);
                        _shapePath.AddArc(rectangle.X, rectangle.Bottom - rectangleShape.Rounding, rectangleShape.Rounding, rectangleShape.Rounding, 90.0F, 90.0F);
                        break;
                    }
            }

            _shapePath.CloseAllFigures();
            return _shapePath;
        }

        /// <summary>
        /// Creates a path of the shape.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="type">The shape.</param>
        /// <returns>The <see cref="GraphicsPath"/>.</returns>
        public static GraphicsPath CreatePath(Rectangle rectangle, int rounding, int thickness, TileShape type)
        {
            RectangleShape rectangleShape = new RectangleShape(Default.Color, rounding, type, thickness);
            return CreatePath(rectangleShape, rectangle);
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

        #endregion Public Methods

        #region Protected Methods

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

        #endregion Protected Methods
    }
}