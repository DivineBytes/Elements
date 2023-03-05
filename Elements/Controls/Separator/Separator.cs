using Elements.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Separator
{
    /// <summary>
    /// The <see cref="Separator"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [Category(Constants.PropertyCategory.Appearance)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Orientation")]
    [Description("The Separator")]
    [Designer(typeof(SeparatorDesigner))]
    [ToolboxBitmap(typeof(Separator), "Separator.bmp")]
    [ToolboxItem(true)]
    public class Separator : ControlBase
    {
        #region Private Fields

        private Color _line;
        private Orientation _orientation;
        private Color _shadow;
        private bool _shadowVisible;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Separator"/> class.
        /// </summary>
        public Separator()
        {
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;

            Size = new Size(75, 4);
            _orientation = Orientation.Horizontal;
            _shadowVisible = true;
            _line = Color.FromArgb(224, 222, 220);
            _shadow = Color.FromArgb(250, 249, 249);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        /// <value>The line.</value>
        [Category("Appearance")]
        [Description("Color")]
        public Color Line
        {
            get
            {
                return _line;
            }

            set
            {
                if (value == _line)
                {
                    return;
                }

                _line = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Behaviour")]
        [Description("Orientation")]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                _orientation = value;

                if (_orientation == Orientation.Horizontal)
                {
                    if (Width < Height)
                    {
                        int temp = Width;
                        Width = Height;
                        Height = temp;
                    }
                }
                else
                {
                    // Vertical
                    if (Width > Height)
                    {
                        int temp = Width;
                        Width = Height;
                        Height = temp;
                    }
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow.
        /// </summary>
        /// <value>The shadow.</value>
        [Category("Appearance")]
        [Description("Color")]
        public Color Shadow
        {
            get
            {
                return _shadow;
            }

            set
            {
                if (value == _shadow)
                {
                    return;
                }

                _shadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [shadow visible].
        /// </summary>
        /// <value><c>true</c> if [shadow visible]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Visible")]
        public bool ShadowVisible
        {
            get
            {
                return _shadowVisible;
            }

            set
            {
                _shadowVisible = value;
                Invalidate();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1);
            _graphics.FillRectangle(new SolidBrush(BackColor), _clientRectangle);

            Point _linePosition;
            Size _lineSize;
            Point _shadowPosition;
            Size _shadowSize;

            switch (_orientation)
            {
                case Orientation.Horizontal:
                    {
                        _linePosition = new Point(0, 1);
                        _lineSize = new Size(Width, 1);

                        _shadowPosition = new Point(0, 2);
                        _shadowSize = new Size(Width, 2);
                        break;
                    }

                case Orientation.Vertical:
                    {
                        _linePosition = new Point(1, 0);
                        _lineSize = new Size(1, Height);

                        _shadowPosition = new Point(2, 0);
                        _shadowSize = new Size(2, Height);
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            Rectangle _lineRectangle = new Rectangle(_linePosition, _lineSize);
            _graphics.DrawRectangle(new Pen(_line), _lineRectangle);

            if (_shadowVisible)
            {
                Rectangle _shadowRectangle = new Rectangle(_shadowPosition, _shadowSize);
                _graphics.DrawRectangle(new Pen(_shadow), _shadowRectangle);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_orientation == Orientation.Horizontal)
            {
                Height = 4;
            }
            else
            {
                Width = 4;
            }
        }

        #endregion Protected Methods
    }
}