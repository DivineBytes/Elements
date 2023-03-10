using Elements.Base;
using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using Elements.Models;
using Elements.Renders;
using Elements.TypeConverters;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.NumericUpDown
{
    /// <summary>
    /// The <see cref="NumericUpDown"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("Value")]
    [Description("The NumericUpDown")]
    [Designer(typeof(NumericUpDownDesigner))]
    [ToolboxBitmap(typeof(NumericUpDown), "NumericUpDown.bmp")]
    [ToolboxItem(true)]
    public class NumericUpDown : ControlBase
    {
        #region Private Fields

        private Border _border;
        private Color _buttonColor;
        private Font _buttonFont;
        private Color _buttonForeColor;
        private Orientation _buttonOrientation;
        private GraphicsPath _buttonPath;
        private Rectangle _buttonRectangle;
        private int _buttonWidth;
        private ColorState _colorState;
        private bool _keyboardNum;
        private long _maximumValue;
        private long _minimumValue;
        private long _value;
        private int _xValue;
        private int _yValue;
        private Color _separatorColor;

        private bool _readOnly;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericUpDown"/> class.
        /// </summary>
        public NumericUpDown()
        {
            MinimumSize = new Size(95, 25);
            Size = new Size(95, 25);

            _buttonWidth = 50;
            _separatorColor = Color.FromArgb(180, 180, 180);
            _buttonColor = Color.FromArgb(220, 220, 220);
            _buttonForeColor = Color.FromArgb(128, 128, 128);

            _colorState = new ColorState(Color.FromArgb(220, 220, 220), Color.FromArgb(241, 244, 249));
            _minimumValue = 0;
            _maximumValue = 100;
            _buttonOrientation = Orientation.Horizontal;

            _border = new Border();
            _readOnly = false;
            _buttonFont = new Font(DefaultFont.FontFamily, 14, FontStyle.Bold);
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when the value changed.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ValueChangedEventHandler ValueChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>
        /// The state of the back color.
        /// </value>
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
        /// <value>
        /// The border.
        /// </value>
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
        /// Gets or sets the color of the button.
        /// </summary>
        /// <value>
        /// The color of the button.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color ButtonColor
        {
            get
            {
                return _buttonColor;
            }

            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the button font.
        /// </summary>
        /// <value>
        /// The button font.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Font)]
        public Font ButtonFont
        {
            get
            {
                return _buttonFont;
            }

            set
            {
                _buttonFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the button fore.
        /// </summary>
        /// <value>
        /// The color of the button fore.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color ButtonForeColor
        {
            get
            {
                return _buttonForeColor;
            }

            set
            {
                _buttonForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the button orientation.
        /// </summary>
        /// <value>
        /// The button orientation.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Orientation)]
        public Orientation ButtonOrientation
        {
            get
            {
                return _buttonOrientation;
            }

            set
            {
                _buttonOrientation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the button.
        /// </summary>
        /// <value>
        /// The width of the button.
        /// </value>
        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Size)]
        public int ButtonWidth
        {
            get
            {
                return _buttonWidth;
            }

            set
            {
                _buttonWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        [Category(PropertyCategory.Behavior)]
        public long MaximumValue
        {
            get
            {
                return _maximumValue;
            }

            set
            {
                if (value > _minimumValue)
                {
                    _maximumValue = value;
                }

                if (_value > _maximumValue)
                {
                    _value = _maximumValue;
                    OnValueChanged(this, new ValueChangedEventArgs(_value));
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        [Category(PropertyCategory.Behavior)]
        public long MinimumValue
        {
            get
            {
                return _minimumValue;
            }

            set
            {
                if (value < _maximumValue)
                {
                    _minimumValue = value;
                }

                if (_value < _minimumValue)
                {
                    _value = MinimumValue;
                    OnValueChanged(this, new ValueChangedEventArgs(_value));
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [read only]; otherwise, <c>false</c>.
        /// </value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.ReadOnly)]
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }

            set
            {
                _readOnly = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>
        /// The separator.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Separator
        {
            get
            {
                return _separatorColor;
            }

            set
            {
                _separatorColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [Category(PropertyCategory.Behavior)]
        public long Value
        {
            get
            {
                return _value;
            }

            set
            {
                if ((value <= _maximumValue) & (value >= _minimumValue))
                {
                    _value = value;
                    OnValueChanged(this, new ValueChangedEventArgs(_value));
                }

                Invalidate();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Decrement the value by the specified amount.
        /// </summary>
        /// <param name="value">The amount.</param>
        public void Decrement(int value)
        {
            _value -= value;
            OnValueChanged(this, new ValueChangedEventArgs(_value));
            Invalidate();
        }

        /// <summary>
        /// Increment the value by the specified amount.
        /// </summary>
        /// <param name="value">The amount.</param>
        public void Increment(int value)
        {
            _value += value;
            OnValueChanged(this, new ValueChangedEventArgs(_value));
            Invalidate();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:KeyPress" /> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            // Determines if control is not readonly
            if (!_readOnly)
            {
                try
                {
                    if (_keyboardNum)
                    {
                        _value = long.Parse(_value + e.KeyChar.ToString());
                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                    }

                    if (_value > _maximumValue)
                    {
                        _value = _maximumValue;
                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:KeyUp" /> event.
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            // Determines if control is not readonly
            if (!_readOnly)
            {
                if (e.KeyCode == Keys.Back)
                {
                    string temporaryValue = _value.ToString();
                    temporaryValue = temporaryValue.Remove(Convert.ToInt32(temporaryValue.Length - 1));
                    if (temporaryValue.Length == 0)
                    {
                        temporaryValue = "0";
                    }

                    _value = Convert.ToInt32(temporaryValue);
                    OnValueChanged(this, new ValueChangedEventArgs(_value));
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            OnMouseClick(e);

            // Determines if control is not readonly
            if (!_readOnly)
            {
                switch (_buttonOrientation)
                {
                    case Orientation.Vertical:
                        {
                            // Check if mouse in X position.
                            if ((_xValue > Width - _buttonRectangle.Width) && (_xValue < Width))
                            {
                                // Determine the button middle separator by checking for the Y position.
                                if ((_yValue > _buttonRectangle.Y) && (_yValue < Height / 2))
                                {
                                    if (Value + 1 <= _maximumValue)
                                    {
                                        _value++;
                                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                                    }
                                }
                                else if ((_yValue > Height / 2) && (_yValue < Height))
                                {
                                    if (Value - 1 >= _minimumValue)
                                    {
                                        _value--;
                                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                                    }
                                }
                            }
                            else
                            {
                                _keyboardNum = !_keyboardNum;
                                Focus();
                            }

                            break;
                        }

                    case Orientation.Horizontal:
                        {
                            // Check if mouse in X position.
                            if ((_xValue > Width - _buttonRectangle.Width) && (_xValue < Width))
                            {
                                // Determine the button middle separator by checking for the X position.
                                if ((_xValue > _buttonRectangle.X) && (_xValue < _buttonRectangle.X + (_buttonRectangle.Width / 2)))
                                {
                                    if (Value + 1 <= _maximumValue)
                                    {
                                        _value++;
                                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                                    }
                                }
                                else if ((_xValue > _buttonRectangle.X + (_buttonRectangle.Width / 2)) && (_xValue < Width))
                                {
                                    if (Value - 1 >= _minimumValue)
                                    {
                                        _value--;
                                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                                    }
                                }
                            }
                            else
                            {
                                _keyboardNum = !_keyboardNum;
                                Focus();
                            }

                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = MouseStates.Hover;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = MouseStates.Normal;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _xValue = e.Location.X;
            _yValue = e.Location.Y;
            Invalidate();

            // IBeam cursor toggle
            if (e.X < _buttonRectangle.X)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseWheel" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            // Determines if control is not readonly
            if (!_readOnly)
            {
                if (e.Delta > 0)
                {
                    if (Value + 1 <= _maximumValue)
                    {
                        _value++;
                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                    }

                    Invalidate();
                }
                else
                {
                    if (Value - 1 >= _minimumValue)
                    {
                        _value--;
                        OnValueChanged(this, new ValueChangedEventArgs(_value));
                    }

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            var controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            _graphics.SetClip(controlGraphicsPath);

            _buttonRectangle = new Rectangle(Width - _buttonWidth, 1, _buttonWidth, Height);

            Size incrementSize = StringUtilities.MeasureText("+", _buttonFont, _graphics);
            Size decrementSize = StringUtilities.MeasureText("-", _buttonFont, _graphics);

            Point[] _decrementButtonPoints = new Point[2];
            Point[] _incrementButtonPoints = new Point[2];

            // Vertical
            _incrementButtonPoints[0] = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2) - (incrementSize.Width / 2), _buttonRectangle.Y + (_buttonRectangle.Height / 2) - (_buttonRectangle.Height / 4) - (incrementSize.Height / 2));
            _decrementButtonPoints[0] = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2) - (decrementSize.Width / 2), _buttonRectangle.Y + (_buttonRectangle.Height / 2) + (_buttonRectangle.Height / 4) - (decrementSize.Height / 2) - 4);

            // Horizontal
            _incrementButtonPoints[1] = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 4) - (incrementSize.Width / 2), (Height / 2) - (incrementSize.Height / 2));
            _decrementButtonPoints[1] = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2) + (_buttonRectangle.Width / 4) - (decrementSize.Width / 2), (Height / 2) - (decrementSize.Height / 2) - 2);

            Point buttonSeparator1 = new Point();
            Point buttonSeparator2 = new Point();

            int toggleInt = 0;
            switch (_buttonOrientation)
            {
                case Orientation.Horizontal:
                    {
                        toggleInt = 1;
                        buttonSeparator1 = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2), _border.Thickness);
                        buttonSeparator2 = new Point(_buttonRectangle.X + (_buttonRectangle.Width / 2), Height - _border.Thickness - 1);
                        break;
                    }

                case Orientation.Vertical:
                    {
                        toggleInt = 0;
                        buttonSeparator1 = new Point(_buttonRectangle.X, _buttonRectangle.Height / 2);
                        buttonSeparator2 = new Point(_buttonRectangle.Right, _buttonRectangle.Height / 2);

                        break;
                    }
            }

            _buttonPath = new GraphicsPath();
            _buttonPath.AddRectangle(_buttonRectangle);
            _buttonPath.CloseAllFigures();

            Color _backColor = Enabled ? BackColorState.Enabled : BackColorState.Disabled;
            ImageRender.Render(e.Graphics, _backColor, BackgroundImage, _clientRectangle, Border);

            _graphics.FillRectangle(new SolidBrush(_buttonColor), _buttonRectangle);
            _graphics.ResetClip();

            _graphics.DrawString("+", _buttonFont, new SolidBrush(_buttonForeColor), _incrementButtonPoints[toggleInt]);
            _graphics.DrawString("-", _buttonFont, new SolidBrush(_buttonForeColor), _decrementButtonPoints[toggleInt]);

            Rectangle _buttonEdgeSeparator = new Rectangle(_buttonRectangle.X, _border.Thickness, 1, Height - _border.Thickness - 1);
            
            DrawText(_graphics);

            _graphics.DrawLine(new Pen(new SolidBrush(_separatorColor)), buttonSeparator1, buttonSeparator2);
            _graphics.DrawLine(new Pen(new SolidBrush(_separatorColor)), new Point(_buttonEdgeSeparator.X, _buttonEdgeSeparator.Y), new Point(_buttonEdgeSeparator.X, _buttonEdgeSeparator.Height));
          
            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);
        }

        /// <summary>
        /// Called when [value changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Draws the text on the graphics.
        /// </summary>
        /// <param name="graphics">The graphics to draw on.</param>
        private void DrawText(Graphics graphics)
        {
            Rectangle textBoxRectangle = new Rectangle(6, 0, Width - 1, Height - 1);
            StringFormat stringFormat = new StringFormat
            {
                // Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            graphics.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor), textBoxRectangle, stringFormat);
        }

        #endregion Private Methods
    }
}