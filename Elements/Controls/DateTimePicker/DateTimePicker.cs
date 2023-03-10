using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using Elements.Models;
using Elements.Renders;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Elements.Controls.DateTimePicker
{
    /// <summary>
    /// The <see cref="DateTimePicker"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.DateTimePicker"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Checked")]
    [Description("The DateTimePicker")]
    [Designer(typeof(DateTimePickerDesigner))]
    [ToolboxBitmap(typeof(DateTimePicker), "CheckBox.bmp")]
    [ToolboxItem(true)]
    public class DateTimePicker : System.Windows.Forms.DateTimePicker
    {
        #region Private Fields

        private ColorState _arrowColor;
        private Size _arrowSize;
        private ColorState _backColor;
        private Border _border;
        private bool _focused;
        private Image _image;
        private Size _imageSize;
        private MouseStates _mouseState;
        private bool _showFocus;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePicker"/> class.
        /// </summary>
        public DateTimePicker()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;

            _arrowSize = new Size(10, 5);
            _imageSize = new Size(16, 16);

            _arrowColor = new ColorState(Color.FromArgb(119, 119, 118), Color.FromArgb(119, 119, 118));

            _border = new Border();
            _mouseState = MouseStates.Normal;

            _image = null;

            _backColor = new ColorState();
            _focused = false;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when the mouse state changed.
        /// </summary>
        [Category(EventCategory.Mouse)]
        [Description(EventDescription.MouseStateChanged)]
        public event MouseStateChangedEventHandler MouseStateChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the color of the arrow.
        /// </summary>
        /// <value>The color of the arrow.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState ArrowColor
        {
            get
            {
                return _arrowColor;
            }

            set
            {
                _arrowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the arrow.
        /// </summary>
        /// <value>The size of the arrow.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Size)]
        public Size ArrowSize
        {
            get
            {
                return _arrowSize;
            }

            set
            {
                _arrowSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(true)]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ColorState BackColorState
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(true)]
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }

            set
            {
                base.BackgroundImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(PropertyCategory.Appearance)]
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
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(true)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
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
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Size)]
        public Size ImageSize
        {
            get
            {
                return _imageSize;
            }

            set
            {
                _imageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is pressed.
        /// </summary>
        /// <value><c>true</c> if this instance is pressed; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsPressed
        {
            get
            {
                return _mouseState == MouseStates.Pressed;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MouseState"/>.
        /// </summary>
        /// <value>The state of the mouse.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.MouseState)]
        public MouseStates MouseState
        {
            get
            {
                return _mouseState;
            }

            set
            {
                if (value == _mouseState)
                {
                    return;
                }

                _mouseState = value;
                OnMouseStateChanged(this, new MouseStateEventArgs(_mouseState));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether show focus.
        /// </summary>
        /// <value><c>true</c> if [show focus]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [DefaultValue(false)]
        [Description(PropertyDescription.Toggle)]
        public bool ShowFocus
        {
            get
            {
                return _showFocus;
            }

            set
            {
                _showFocus = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether show up down.
        /// </summary>
        /// <value><c>true</c> if [show up down]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool ShowUpDown
        {
            get
            {
                return base.ShowUpDown;
            }

            set
            {
                base.ShowUpDown = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether use selectable.
        /// </summary>
        /// <value><c>true</c> if [use selectable]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Category(PropertyCategory.Behavior)]
        [DefaultValue(true)]
        public bool UseSelectable
        {
            get
            {
                return GetStyle(ControlStyles.Selectable);
            }

            set
            {
                SetStyle(ControlStyles.Selectable, value);
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="proposedSize">Size of the proposed.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize;
            base.GetPreferredSize(proposedSize);

            using (Graphics graphics = CreateGraphics())
            {
                string measureText = Text.Length > 0 ? Text : CategoryBase.DefaultName;
                proposedSize = new Size(int.MaxValue, int.MaxValue);
                preferredSize = TextRenderer.MeasureText(graphics, measureText, Font, proposedSize, TextFormatFlags.Left | TextFormatFlags.LeftAndRightPadding | TextFormatFlags.VerticalCenter);
                preferredSize.Height += 10;
            }

            return preferredSize;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Enter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            _focused = true;
            _mouseState = MouseStates.Hover;
            Invalidate();

            base.OnEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            _focused = true;
            _mouseState = MouseStates.Hover;
            Invalidate();
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _mouseState = MouseStates.Hover;
                Invalidate();
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:KeyUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            _mouseState = MouseStates.Normal;
            Invalidate();
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:Leave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            _focused = false;
            _mouseState = MouseStates.Normal;
            Invalidate();
            base.OnLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            _focused = false;
            _mouseState = MouseStates.Normal;
            Invalidate();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseState = MouseStates.Pressed;
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseEnter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseState = MouseStates.Hover;
            Invalidate();

            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            _mouseState = MouseStates.Hover;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseState = MouseStates.Normal;
            Invalidate();

            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Invokes the mouse state changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnMouseStateChanged(object sender, MouseStateEventArgs e)
        {
            Invalidate();
            MouseStateChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseState = MouseStates.Hover;
            Invalidate();

            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                MinimumSize = new Size(0, GetPreferredSize(Size.Empty).Height);

                Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);
                Color backColorState = ColorState.GetColorState(_backColor, Enabled, MouseState);

                e.Graphics.SetClip(controlGraphicsPath);
                ImageRender.Render(e.Graphics, backColorState, BackgroundImage, _clientRectangle, _border);
                Border.Render(e.Graphics, _border, _mouseState, controlGraphicsPath);
                Rectangle arrowRectangle = new Rectangle(Width - _arrowSize.Width - 5, (Height / 2) - (_arrowSize.Height / 2), _arrowSize.Width, _arrowSize.Height);

                Color colorState = _arrowColor.GetColorState(Enabled, _mouseState);
                ControlRender.RenderTriangle(e.Graphics, arrowRectangle, colorState, _image, Vertical.Down);

                var _check = 0;
                Rectangle checkBoxRectangle = new Rectangle(3, (Height / 2) - 6, 12, 12);

                if (ShowCheckBox)
                {
                    _check = 15;

                    if (Checked)
                    {
                        CheckBoxRenderer.DrawCheckBox(e.Graphics, checkBoxRectangle.Location, CheckBoxState.CheckedNormal);
                    }
                    else
                    {
                        CheckBoxRenderer.DrawCheckBox(e.Graphics, checkBoxRectangle.Location, CheckBoxState.UncheckedNormal);
                    }
                }

                Size textSize = StringUtilities.MeasureText(Text, Font);

                Rectangle textBoxRectangle = new Rectangle(2 + _check, (Height / 2) - (textSize.Height / 2), textSize.Width, textSize.Height);
                TextRenderer.DrawText(e.Graphics, Text, Font, textBoxRectangle, ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                if (_showFocus && _focused)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
                }

                e.Graphics.ResetClip();
            }
            catch
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ValueChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            Invalidate();
        }

        #endregion Protected Methods
    }
}