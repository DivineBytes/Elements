using Elements.Base;
using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Models;
using Elements.Properties;
using Elements.Renders;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Tile
{
    /// <summary>
    /// The <see cref="Tile"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Color")]
    [Description("The tile control.")]
    [Designer(typeof(TileDesigner))]
    [ToolboxBitmap(typeof(Tile), "Tile.bmp")]
    [ToolboxItem(true)]
    public class Tile : ControlBase
    {
        private int _rounding;
        private TileType _tileType;
        private TileShape _tileShape;
        private int _thickness;
        private bool _visible;
        private System.Drawing.Image _image;
        private Point _offset;
        private ElementImageLayout _backgroundLayout;
        private ElementImageLayout _imageLayout;
        private ControlColorState _backColorState;
        private TextStyle _textStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        public Tile()
        {
            Size = new Size(85, 75);

            _backgroundLayout = ElementImageLayout.Stretch;
            _imageLayout = ElementImageLayout.Stretch;
            _backColorState = new ControlColorState(Color.FromArgb(180, 180, 180), Color.FromArgb(180, 180, 180), Color.FromArgb(180, 180, 180), Color.FromArgb(180, 180, 180));
            _image = Resources.Logo;
            _offset = new Point(0, 0);

            _thickness = 5;
            _rounding = 5;
            _tileShape = TileShape.Rectangle;
            _tileType = TileType.Text;
            _visible = true;
            _textStyle = new TextStyle();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="rounding">The rounding.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="type">The type.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public Tile(ControlColorState color, int thickness, int rounding, TileShape shape, TileType type, bool visible) : this()
        {
            _backColorState = color;
            _thickness = thickness;
            _rounding = rounding;
            _tileShape = shape;
            _tileType = type;
            _visible = visible;
        }

        /// <summary>
        /// Occurs when [color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event ColorChangedEventHandler ColorChanged;

        /// <summary>
        /// Occurs when [rounding changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event RoundingChangedEventHandler RoundingChanged;

        /// <summary>
        /// Occurs when [thickness changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event ThicknessChangedEventHandler ThicknessChanged;

        /// <summary>
        /// Occurs when [type changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event TypeChangedEventHandler TypeChanged;

        /// <summary>
        /// Occurs when [shape changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event TypeChangedEventHandler ShapeChanged;

        /// <summary>
        /// Occurs when [visible changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public new event VisibleChangedEventHandler VisibleChanged;

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
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState BackColorState
        {
            get
            {
                return _backColorState;
            }

            set
            {
                _backColorState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background image layout.
        /// </summary>
        /// <value>The background image layout.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The background layout.")]
        public new ElementImageLayout BackgroundImageLayout
        {
            get
            {
                return _backgroundLayout;
            }

            set
            {
                _backgroundLayout = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image layout.
        /// </summary>
        /// <value>The background image layout.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The image layout.")]
        public ElementImageLayout ImageLayout
        {
            get
            {
                return _imageLayout;
            }

            set
            {
                _imageLayout = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The image.")]
        public System.Drawing.Image Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        [Category(PropertyCategory.Layout)]
        [Description("The offset.")]
        public Point Offset
        {
            get
            {
                return _offset;
            }

            set
            {
                _offset = value;
            }
        }

        /// <summary>
        /// Gets or sets the text style.
        /// </summary>
        /// <value>The text style.</value>
        [Category(PropertyCategory.Layout)]
        [Description("The text style.")]
        public TextStyle TextStyle
        {
            get
            {
                return _textStyle;
            }
            set
            {
                _textStyle = value;
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
                Invalidate();
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
                return _tileShape;
            }

            set
            {
                _tileShape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public TileType Type
        {
            get
            {
                return _tileType;
            }

            set
            {
                _tileType = value;
                Invalidate();
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
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Tile"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public new bool Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            Cursor = Cursors.Default;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Enabled)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Enabled)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Color backColor = ControlColorState.GetColorState(_backColorState, Enabled, MouseState);

            ImageRender.Render(e.Graphics, backColor, BackgroundImage, _backgroundLayout, ClientRectangle);
            RenderTile(e.Graphics, _tileType, _imageLayout, ClientRectangle, Image, Text, Font, Enabled, MouseState, _textStyle, _offset);

            base.OnPaint(e);
        }

        /// <summary>
        /// Render the tile.
        /// </summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="type">The type to draw.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="mouseState">The mouse State.</param>
        /// <param name="textStyle">The text Style.</param>
        /// <param name="offset">The location offset.</param>
        /// <returns></returns>
        public static void RenderTile(Graphics graphics, TileType type, ElementImageLayout layout, Rectangle clientRectangle, Image image, string text, Font font, bool enabled, MouseStates mouseState, TextStyle textStyle, Point offset = new Point())
        {
            switch (type)
            {
                case TileType.Image:
                    {
                        ImageRender.Render(graphics, image, layout, clientRectangle);
                        break;
                    }

                case TileType.Text:
                    {
                        TextRender.RenderText(graphics, clientRectangle, text, font, enabled, mouseState, textStyle);
                        break;
                    }
            }
        }
    }
}