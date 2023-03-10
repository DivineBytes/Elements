using Elements.Base;
using Elements.Constants;
using Elements.Models;
using Elements.TypeConverters;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.ControlBox
{
    /// <summary>
    /// The <see cref="ControlBoxButton"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("MaximizeButton")]
    [Description("The ControlBoxButton")]
    [Designer(typeof(ControlBoxDesigner))]
    [ToolboxBitmap(typeof(ControlBox), "ControlBoxButton.bmp")]
    [ToolboxItem(false)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ControlBoxButton : ControlBase
    {
        #region Public Fields

        /// <summary>
        /// The Default Height.
        /// </summary>
        public const int DefaultHeight = 25;

        /// <summary>
        /// The Default Width.
        /// </summary>
        public const int DefaultWidth = 24;

        #endregion Public Fields

        #region Private Fields

        private ControlColorState _backColorState;
        private ControlBoxType _boxType;
        private ControlColorState _foreColorState;
        private Image _image;
        private Point _offsetLocation;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlBoxButton"/> class.
        /// </summary>
        public ControlBoxButton()
        {
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(DefaultWidth, DefaultHeight);

            _backColorState = new ControlColorState();
            _boxType = ControlBoxType.Default;
            _foreColorState = new ControlColorState();
            _image = null;
            _offsetLocation = new Point(0, 0);
        }

        #endregion Public Constructors

        #region Public Properties

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
        /// Gets or sets the type of the box.
        /// </summary>
        /// <value>The type of the box.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.ControlBoxStyle)]
        public ControlBoxType BoxType
        {
            get
            {
                return _boxType;
            }

            set
            {
                _boxType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the state of the fore color.
        /// </summary>
        /// <value>The state of the fore color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState ForeColorState
        {
            get
            {
                return _foreColorState;
            }

            set
            {
                _foreColorState = value;
                Invalidate();
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
        /// Gets or sets the offset location.
        /// </summary>
        /// <value>The offset location.</value>
        [Category(PropertyCategory.Layout)]
        [Description(PropertyDescription.Location)]
        public Point OffsetLocation
        {
            get
            {
                return _offsetLocation;
            }

            set
            {
                _offsetLocation = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics _graphics = e.Graphics;

            Size _stringSize;

            Color _backColor = ControlColorState.GetColorState(_backColorState, Enabled, MouseState);
            Color _foreColor = ControlColorState.GetColorState(_foreColorState, Enabled, MouseState);

            _graphics.FillRectangle(new SolidBrush(_backColor), ClientRectangle);

            switch (_boxType)
            {
                case ControlBoxType.Default:
                    {
                        Font _font = FontUtilities.GetFont("Marlett");
                        Size fSize = StringUtilities.MeasureText(Text, _font, _graphics);
                        Point _location = new Point((Width / 2) - (fSize.Width / 2) + _offsetLocation.X, (Height / 2) - (fSize.Height / 2) + _offsetLocation.Y);

                        char symbol = Convert.ToChar(Text);
                        FontUtilities.DrawMarlettCharacter(_graphics, symbol, _foreColor, _location, StringFormat.GenericDefault, _font.Size);
                        break;
                    }

                case ControlBoxType.Image:
                    {
                        Point _location = new Point((Width / 2) - (_image.Width / 2) + _offsetLocation.X, (Height / 2) - (_image.Height / 2) + _offsetLocation.Y);
                        _graphics.DrawImage(_image, _location);
                        break;
                    }

                case ControlBoxType.Text:
                    {
                        _stringSize = StringUtilities.MeasureText(Text, Font, _graphics);
                        Point _location = new Point((Width / 2) - (_stringSize.Width / 2) + _offsetLocation.X, (Height / 2) - (_stringSize.Height / 2) + _offsetLocation.Y);

                        _graphics.DrawString(Text, Font, new SolidBrush(_foreColor), _location);
                        break;
                    }
            }
        }

        #endregion Protected Methods
    }
}