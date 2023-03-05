using Elements.Base;
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

namespace Elements.Controls.Toggle
{
    /// <summary>
    /// The <see cref="Controls.Toggle"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Toggle")]
    [Description("The Toggle")]
    [Designer(typeof(ToggleDesigner))]
    [ToolboxBitmap(typeof(Toggle), "Toggle.bmp")]
    [ToolboxItem(true)]
    public class Toggle : ControlBase
    {
        #region Private Fields

        private readonly Timer _animationTimer;
        private Border _border;
        private Button.Button _button;
        private ColorState _colorState;
        private bool _toggle;
        private ToggleOptions _toggleOptions;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Toggle"/> class.
        /// </summary>
        public Toggle()
        {
            Size = new Size(50, 25);

            _animationTimer = new Timer { Interval = 1 };
            _animationTimer.Tick += AnimationTimerTick;

            _border = new Border();
            _border.Rounding = 20;

            _button = new Button.Button();
            _button.Location = new Point(0, 0);
            _button.Size = new Size(20, 20);
            _button.Text = string.Empty;
            _button.Border.Rounding = 18;
            _button.BackColor = Color.Transparent;

            _colorState = new ColorState();
            _toggleOptions = new ToggleOptions();
            _toggle = false;

            Controls.Add(_button);
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [toggle changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the toggle has been changed on the control.")]
        public event ToggleChangedEventHandler ToggleChanged;

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
                return _colorState;
            }

            set
            {
                _colorState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
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
        [Browsable(false)]
        public Button.Button Button
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
        /// Gets or sets a value indicating whether this <see cref="Toggle"/> is toggled.
        /// </summary>
        /// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category(PropertyCategory.Behavior)]
        [Description("Toggles the behaviour.")]
        public bool Toggled
        {
            get
            {
                return _toggle;
            }

            set
            {
                _toggle = value;
                OnToggleChanged(this, new ToggleEventArgs(_toggle));
            }
        }

        /// <summary>
        /// Gets or sets the toggle options.
        /// </summary>
        /// <value>The toggle options.</value>
        public ToggleOptions ToggleOptions
        {
            get
            {
                return _toggleOptions;
            }

            set
            {
                _toggleOptions = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:HandleCreated"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _animationTimer.Start();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

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
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Hover));
            Toggled = !Toggled;
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            Color _backColor = ColorState.GetColorState(_colorState, Enabled, MouseState);

            // Adjust the toggle state location
            Point _startPoint = new Point(0 + 2, (_clientRectangle.Height / 2) - (_button.Height / 2));
            Point _endPoint = new Point(_clientRectangle.Width - _button.Width - 2, (_clientRectangle.Height / 2) - (_button.Height / 2));
            Point _buttonLocation;

            if (_toggle)
            {
                _buttonLocation = _endPoint;
            }
            else
            {
                _buttonLocation = _startPoint;
            }

            Rectangle _buttonRectangle = new Rectangle(_buttonLocation, _button.Size);
            _button.Location = _buttonRectangle.Location;

            _graphics.SetClip(controlGraphicsPath);

            ImageRender.Render(e.Graphics, _backColor, BackgroundImage, _clientRectangle, Border);
            DrawToggleText(_graphics);

            _graphics.ResetClip();

            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);
        }

        /// <summary>
        /// Occurs when the ToggleChanged event fires.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnToggleChanged(object sender, ToggleEventArgs e)
        {
            ToggleChanged?.Invoke(sender, e);
            Invalidate();
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Create a slide animation when toggled.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            var _toggleLocation = 0;

            if (_toggle)
            {
                if (_toggleLocation >= 100)
                {
                    return;
                }

                _toggleLocation += 10;
                Invalidate(false);
            }
            else if (_toggleLocation > 0)
            {
                _toggleLocation -= 10;
                Invalidate(false);
            }
        }

        /// <summary>
        /// Draws the toggle text.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        private void DrawToggleText(Graphics graphics)
        {
            string _textProcessor = string.Empty;

            // Determines the type of toggle to draw.
            switch (_toggleOptions.Type)
            {
                case ToggleTypes.YesNo:
                    {
                        _textProcessor = ToggleOptions.NoYes.GetValue(_toggle);
                        break;
                    }

                case ToggleTypes.OnOff:
                    {
                        _textProcessor = ToggleOptions.OffOn.GetValue(_toggle);
                        break;
                    }

                case ToggleTypes.IO:
                    {
                        _textProcessor = ToggleOptions.OI.GetValue(_toggle);
                        break;
                    }

                case ToggleTypes.Custom:
                    {
                        _textProcessor = Toggled ? _toggleOptions.FalseText : _toggleOptions.TrueText;
                        break;
                    }
            }

            // Draw string
            Rectangle textBoxRectangle;

            const int XOff = 5;
            const int XOn = 7;

            if (_toggle)
            {
                textBoxRectangle = new Rectangle(XOff, 0, Width - 1, Height - 1);
            }
            else
            {
                Size textSize = StringUtilities.MeasureText(_textProcessor, Font, graphics);
                textBoxRectangle = new Rectangle(Width - (textSize.Width / 2) - (XOn * 2), 0, Width - 1, Height - 1);
            }

            StringFormat stringFormat = new StringFormat
            {
                // Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Color _foreColor = Enabled ? ForeColor : Color.Gray;

            graphics.DrawString(
                _textProcessor,
                new Font(Font.FontFamily, 7f, Font.Style),
                new SolidBrush(_foreColor),
                textBoxRectangle,
                stringFormat);
        }

        #endregion Private Methods
    }
}