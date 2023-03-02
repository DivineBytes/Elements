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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Tile
{
    /// <summary>
    /// The <see cref="Tile"/> class.
    /// </summary>
    /// <seealso cref="ControlBase"/>
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
        private TileType _tileType;
        private Border _border;
        private Image _image;
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
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;

            Size = new Size(85, 75);

            _border = new Border();

            _backgroundLayout = ElementImageLayout.Stretch;
            _imageLayout = ElementImageLayout.Stretch;

            _backColorState = new ControlColorState(
                Color.FromArgb(180, 180, 180),
                Color.FromArgb(253, 253, 253),
                Color.FromArgb(180, 180, 180),
                Color.FromArgb(180, 180, 180));

            _image = Resources.Logo;
            _offset = new Point(0, 0);
            _tileType = TileType.Text;
            _textStyle = new TextStyle();
            _textStyle.ColorState.Enabled = Color.Black;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="border">The border.</param>
        /// <param name="type">The type.</param>
        public Tile(ControlColorState color, Border border, TileType type) : this()
        {
            _backColorState = color;
            _border = border;
            _tileType = type;
        }

        /// <summary>
        /// Occurs when [color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property Event Changed")]
        public event ColorChangedEventHandler ColorChanged;

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
        public event ShapeChangedEventHandler ShapeChanged;

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Border Border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
                Invalidate();
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
        public Image Image
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
                Invalidate();
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
                OnTypeChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Invokes the rounding changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnColorChanged(object sender, EventArgs e)
        {
            Invalidate();
            ColorChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes the type changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnTypeChanged(object sender, EventArgs e)
        {
            Invalidate();
            TypeChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Invokes the shape changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnShapeChanged(object sender, EventArgs e)
        {
            Invalidate();
            ShapeChanged?.Invoke(sender, e);
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
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Color backColor = ControlColorState.GetColorState(_backColorState, Enabled, MouseState);

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            e.Graphics.SetClip(controlGraphicsPath);
            ImageRender.Render(e.Graphics, backColor, BackgroundImage, _backgroundLayout, ClientRectangle);
            RenderTile(e.Graphics, _tileType, _imageLayout, ClientRectangle, Image, Text, Font, Enabled, MouseState, _textStyle, _offset);
            e.Graphics.ResetClip();

            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);

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
                        TextRender.Render(graphics, clientRectangle, text, font, enabled, mouseState, textStyle);
                        break;
                    }
            }
        }
    }
}