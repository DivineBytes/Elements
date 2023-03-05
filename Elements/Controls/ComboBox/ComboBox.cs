using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using Elements.Models;
using Elements.Renders;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.ComboBox
{
    /// <summary>
    /// The <see cref="ComboBox"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Items")]
    [Description("The ComboBox")]
    [Designer(typeof(ComboBoxDesigner))]
    [ToolboxBitmap(typeof(ComboBox), "ComboBox.bmp")]
    [ToolboxItem(true)]
    public class ComboBox : System.Windows.Forms.ComboBox
    {
        #region Private Fields

        private ColorState _backColorState;
        private Border _border;
        private ComboBoxButton _button;
        private int _index;
        private ImageList _imageList;
        private bool _imageVisible;
        private bool _itemImageVisible;
        private TextStyle _itemStyle;
        private Color _menuItemHover;
        private Color _menuItemNormal;
        private Color _menuTextColor;
        private MouseStates _mouseState;
        private ComboBoxSeparator _separator;
        private TextImageRelation _textImageRelation;
        private TextStyle _textStyle;
        private Watermark _watermark;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            UpdateStyles();

            BackColor = SystemColors.Control;
            DrawMode = DrawMode.OwnerDrawVariable;
            DropDownHeight = 100;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            ResizeRedraw = true;
            Size = new Size(135, 26);
            ItemHeight = 24;

            BackColor = SystemColors.Control;
            MinimumSize = new Size(0, 26);
            MaximumSize = new Size(0, 26);

            _button = new ComboBoxButton();
            _border = new Border();

            _backColorState = new ColorState();

            _imageVisible = false;
            _itemImageVisible = true;
            _menuItemHover = Color.FromArgb(120, 183, 230);
            _menuItemNormal = Color.FromArgb(241, 244, 249);
            _menuTextColor = Color.Black;
            _textImageRelation = TextImageRelation.ImageBeforeText;

            _mouseState = MouseStates.Normal;

            _itemStyle = new TextStyle();
            _imageList = new ImageList();
            _textStyle = new TextStyle();

            _watermark = new Watermark();

            _separator = new ComboBoxSeparator();
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [mouse state changed].
        /// </summary>
        [Category(EventCategory.Mouse)]
        [Description("Occours when the MouseState of the control has changed.")]
        public event MouseStateChangedEventHandler MouseStateChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState BackColorState
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
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(true)]
        [Description("Image")]
        public new Image BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [Category(PropertyCategory.Appearance)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
        /// Gets or sets the button.
        /// </summary>
        /// <value>The button.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBoxButton Button
        {
            get
            {
                return _button;
            }

            set
            {
                _button = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image list.
        /// </summary>
        /// <value>The image list.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Image List")]
        public ImageList ImageList
        {
            get
            {
                return _imageList;
            }

            set
            {
                _imageList = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [image visible].
        /// </summary>
        /// <value><c>true</c> if [image visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("Visible")]
        public bool ImageVisible
        {
            get
            {
                return _imageVisible;
            }

            set
            {
                _imageVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [item image visible].
        /// </summary>
        /// <value><c>true</c> if [item image visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("Visible")]
        public bool ItemImageVisible
        {
            get
            {
                return _itemImageVisible;
            }

            set
            {
                _itemImageVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the menu item hover.
        /// </summary>
        /// <value>The menu item hover.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color MenuItemHover
        {
            get
            {
                return _menuItemHover;
            }

            set
            {
                _menuItemHover = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the menu item normal.
        /// </summary>
        /// <value>The menu item normal.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color MenuItemNormal
        {
            get
            {
                return _menuItemNormal;
            }

            set
            {
                _menuItemNormal = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the menu text.
        /// </summary>
        /// <value>The color of the menu text.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color MenuTextColor
        {
            get
            {
                return _menuTextColor;
            }

            set
            {
                _menuTextColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MouseState"/>.
        /// </summary>
        [Category(PropertyCategory.Appearance)]
        [Description("The mouse state.")]
        public MouseStates MouseState
        {
            get
            {
                return _mouseState;
            }

            set
            {
                if (_mouseState == value)
                {
                    return;
                }

                _mouseState = value;
                OnMouseStateChanged(this, new MouseStateEventArgs(_mouseState));
            }
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        [Category(PropertyCategory.Behavior)]
        [Description("Start Index")]
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
                try
                {
                    SelectedIndex = value;
                }
                catch (Exception)
                {
                    // ignored
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBoxSeparator Separator
        {
            get
            {
                return _separator;
            }

            set
            {
                _separator = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text image relation.
        /// </summary>
        /// <value>The text image relation.</value>
        public TextImageRelation TextImageRelation
        {
            get
            {
                return _textImageRelation;
            }

            set
            {
                _textImageRelation = value;
                Invalidate();
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
                return _textStyle;
            }

            set
            {
                _textStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the watermark.
        /// </summary>
        /// <value>The watermark.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Watermark Watermark
        {
            get { return _watermark; }

            set
            {
                _watermark = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Invokes the mouse state changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnMouseStateChanged(object sender, MouseStateEventArgs e)
        {
            MouseState = e.MouseStates;
            Invalidate();
            MouseStateChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Enter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:Leave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            SuspendLayout();
            Update();
            ResumeLayout();
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Pressed));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath _controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            _graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1));
            _graphics.SetClip(_controlGraphicsPath);

            Color _backColor = ColorState.GetColorState(_backColorState, Enabled, MouseState);
            ImageRender.Render(_graphics, _backColor, BackgroundImage, _clientRectangle, _border);

            Rectangle _buttonRectangle = new Rectangle(new Point(Width - _button.Width, 0), new Size(_button.Width, Height));
            Rectangle _textBoxRectangle = new Rectangle(new Point(), new Size(Width - _button.Width, Height));

            DrawContent(_graphics, _textBoxRectangle);

            _button.Render(_graphics, _buttonRectangle);
            _separator.Render(_graphics, _buttonRectangle, _border, this);

            _graphics.ResetClip();

            if (Text.Length == 0)
            {
                Rectangle watermarkRectangle = new Rectangle(0, 0, _textBoxRectangle.Width, _textBoxRectangle.Height);
                HorizontalAlignment horizontalAlignment = Extensions.Extensions.GetAlignment(_textStyle.TextAlignment);
                _watermark.Render(_graphics, _backColor, watermarkRectangle, horizontalAlignment, System.Windows.Forms.VisualStyles.VerticalAlignment.Center, RightToLeft);
            }

            Border.Render(_graphics, _border, MouseState, _controlGraphicsPath);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        /// <param name="rectangle">The rectangle to draw on.</param>
        public void DrawContent(Graphics graphics, Rectangle rectangle)
        {
            Color _textColor = _textStyle.GetColorState(Enabled, _mouseState);

            if ((SelectedIndex != -1) && (_imageList != null) && ImageVisible)
            {
                ControlRender.RenderContent(graphics, rectangle, Text, Font, _textColor, _imageList.Images[SelectedIndex], _imageList.ImageSize, _textImageRelation);
            }
            else
            {
                TextRender.Render(graphics, rectangle, Text, Font, _textColor, _textStyle.StringFormat);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:DrawItem"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // e.DrawBackground();
            e.Graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(_menuItemHover) : new SolidBrush(_menuItemNormal), e.Bounds);

            if (e.Index != -1)
            {
                Point _location;

                if (_imageList != null && _imageList.Images.Count > 0 && _itemImageVisible)
                {
                    e.Graphics.DrawImage(_imageList.Images[e.Index], e.Bounds.X, e.Bounds.Y + (e.Bounds.Height / 2) - (_imageList.ImageSize.Height / 2), _imageList.ImageSize.Width, _imageList.ImageSize.Height);

                    _location = new Point(e.Bounds.X + _imageList.ImageSize.Width, e.Bounds.Y);
                }
                else
                {
                    _location = new Point(e.Bounds.X, e.Bounds.Y);
                }

                e.Graphics.DrawString(GetItemText(Items[e.Index]), Font, new SolidBrush(_menuTextColor), new Rectangle(_location, new Size(DropDownWidth, ItemHeight)), _textStyle.StringFormat);
            }

            // Draw rectangle over the item selected e.DrawFocusRectangle();
        }

        /// <summary>
        /// Raises the <see cref="E:MeasureItem"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="MeasureItemEventArgs"/> instance containing the event data.
        /// </param>
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            Graphics g = CreateGraphics();
            var maxWidth = 0;

            foreach (int width in Items.Cast<object>().Select(element => (int)g.MeasureString(element.ToString(), Font).Width).Where(width => width > maxWidth))
            {
                maxWidth = width;
            }

            DropDownWidth = maxWidth + 20;
        }

        /// <summary>
        /// Raises the <see cref="E:SelectionChangeCommitted"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            OnLostFocus(e);
        }

        #endregion Private Methods
    }
}