using Elements.Base;
using Elements.Constants;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.RadialProgress
{
    /// <summary>
    /// The <see cref="RadialProgress"/> class.
    /// </summary>
    /// <seealso cref="ProgressBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Value")]
    [Description("The Radial Progress")]
    [Designer(typeof(RadialProgressDesigner))]
    [ToolboxBitmap(typeof(RadialProgress), "RadialProgress.bmp")]
    [ToolboxItem(true)]
    public class RadialProgress : ProgressBase
    {
        private Color _backCircleColor;
        private bool _backCircleVisible;
        private Color _foreCircleColor;
        private bool _foreCircleVisible;
        private LineCap _lineCap;
        private Color _progressColor;
        private float _progressSize;
        private bool _textVisible;
        private Image _image;
        private Point _imageLocation;
        private Size _imageSize;
        private bool _percentageVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadialProgress"/> class.
        /// </summary>
        public RadialProgress()
        {
            _backCircleVisible = true;
            _foreCircleVisible = true;
            _percentageVisible = true;
            _textVisible = false;
            _lineCap = LineCap.Round;
            _progressSize = 5f;
            _imageSize = new Size(16, 16);

            _backCircleColor = Color.FromArgb(220, 220, 220);
            _foreCircleColor = Color.LightGray;
            _progressColor = Color.Green;

            Size = new Size(100, 100);
            MinimumSize = Size;
            Maximum = 100;
            Text = string.Empty;
        }

        /// <summary>
        /// Gets or sets the color of the back circle.
        /// </summary>
        /// <value>The color of the back circle.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Back circle color")]
        public Color BackCircleColor
        {
            get
            {
                return _backCircleColor;
            }

            set
            {
                _backCircleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [back circle visible].
        /// </summary>
        /// <value><c>true</c> if [back circle visible]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Category(PropertyCategory.Appearance)]
        [Description("Back circle visible")]
        public bool BackCircleVisible
        {
            get
            {
                return _backCircleVisible;
            }

            set
            {
                _backCircleVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the fore circle.
        /// </summary>
        /// <value>The fore circle.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Fore circle color")]
        public Color ForeCircle
        {
            get
            {
                return _foreCircleColor;
            }

            set
            {
                _foreCircleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [fore circle visible].
        /// </summary>
        /// <value><c>true</c> if [fore circle visible]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        [Category(PropertyCategory.Appearance)]
        [Description("Fore circle visible")]
        public bool ForeCircleVisible
        {
            get
            {
                return _foreCircleVisible;
            }

            set
            {
                _foreCircleVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The image")]
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
        /// Gets or sets the image location.
        /// </summary>
        /// <value>The image location.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Image location")]
        public Point ImageLocation
        {
            get
            {
                return _imageLocation;
            }

            set
            {
                _imageLocation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        [Category(PropertyCategory.Layout)]
        [Description("Image size")]
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
        /// Gets or sets the line cap.
        /// </summary>
        /// <value>The line cap.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Type")]
        public LineCap LineCap
        {
            get
            {
                return _lineCap;
            }

            set
            {
                _lineCap = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        [DefaultValue(typeof(Color), "Green")]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color ProgressColor
        {
            get
            {
                return _progressColor;
            }

            set
            {
                _progressColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the progress.
        /// </summary>
        /// <value>The size of the progress.</value>
        [DefaultValue(5F)]
        [Category(PropertyCategory.Layout)]
        [Description("Size")]
        public float ProgressSize
        {
            get
            {
                return _progressSize;
            }

            set
            {
                _progressSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text visible].
        /// </summary>
        /// <value><c>true</c> if [text visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Visible")]
        public bool TextVisible
        {
            get
            {
                return _textVisible;
            }

            set
            {
                _textVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [percentage visible].
        /// </summary>
        /// <value><c>true</c> if [percentage visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Visible")]
        public bool PercentageVisible
        {
            get
            {
                return _percentageVisible;
            }

            set
            {
                _percentageVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateSize();
        }

        /// <summary>
        /// Raises the <see cref="E:SizeChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateSize();
        }

        /// <summary>
        /// Updates the size.
        /// </summary>
        private void UpdateSize()
        {
            Size = new Size(Math.Max(Width, Height), Math.Max(Width, Height));
        }

        /// <summary>
        /// Draws the circles.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        protected void DrawCircles(Graphics graphics)
        {
            if (_backCircleVisible)
            {
                graphics.FillEllipse(new SolidBrush(_backCircleColor), _progressSize, _progressSize, Width - _progressSize - 1, Height - _progressSize - 1);
            }

            using (Pen progressPen = new Pen(_progressColor, _progressSize))
            {
                progressPen.StartCap = _lineCap;
                progressPen.EndCap = _lineCap;
                graphics.DrawArc(progressPen, _progressSize + 2, _progressSize + 2, Width - (_progressSize * 2), Height - (_progressSize * 2), -90, (int)Math.Round(360.0 / Maximum * Value));
            }

            if (_foreCircleVisible)
            {
                graphics.FillEllipse(new SolidBrush(_foreCircleColor), _progressSize + 4, _progressSize + 4, Width - _progressSize - 10, Height - _progressSize - 10);
            }
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        protected void DrawImage(Graphics graphics)
        {
            if (Image == null)
            {
                return;
            }

            Rectangle _imageRectangle;

            if (AutoSize)
            {
                _imageLocation = new Point((Width / 2) - (_imageSize.Width / 2), (Height / 2) - (_imageSize.Height / 2));
                _imageRectangle = new Rectangle(_imageLocation, _imageSize);
            }
            else
            {
                _imageRectangle = new Rectangle(_imageLocation, _imageSize);
            }

            graphics.DrawImage(Image, _imageRectangle);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        protected void DrawText(Graphics graphics)
        {
            string _value;
            if (_textVisible)
            {
                _value = Text;
            }
            else
            {
                if (_percentageVisible)
                {
                    _value = Value.ToString("0") + "%";
                }
                else
                {
                    _value = Value.ToString("0");
                }
            }

            SizeF _textSize = StringUtilities.MeasureTextF(_value, Font, graphics);
            PointF _textPoint = new PointF((Width / 2) - (_textSize.Width / 2), (Height / 2) - (_textSize.Height / 2));

            graphics.DrawString(_value, Font, new SolidBrush(ForeColor), _textPoint);
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            DrawCircles(graphics);
            DrawImage(graphics);
            DrawText(graphics);
        }
    }
}