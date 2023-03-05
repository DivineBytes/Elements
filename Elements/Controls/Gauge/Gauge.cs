using Elements.Base;
using Elements.Constants;
using Elements.Models;
using Elements.TypeConverters;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Gauge
{
    /// <summary>
    /// The <see cref="Gauge"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ProgressBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Value")]
    [Description("The Gauge")]
    [Designer(typeof(GaugeDesigner))]
    [ToolboxBitmap(typeof(Gauge), "Gauge.bmp")]
    [ToolboxItem(true)]
    public class Gauge : ProgressBase
    {
        #region Private Fields

        private ColorState _colorState;
        private System.Windows.Forms.Label _labelMaximum;
        private System.Windows.Forms.Label _labelMinimum;
        private System.Windows.Forms.Label _labelProgress;
        private Color _progress;
        private Size _progressTextSize;
        private int _thickness;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Gauge"/> class.
        /// </summary>
        public Gauge()
        {
            _colorState = new ColorState();
            _progress = Color.Green;
            _thickness = 25;
            Maximum = 100;

            _labelProgress = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(83, 34),
                Margin = new Padding(6, 0, 6, 0),
                Name = "labelProgress",
                Size = new Size(22, 24),
                TabIndex = 1,
                Text = @"0",
                BackColor = Color.Transparent
            };

            _labelMinimum = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(26, 86),
                Margin = new Padding(6, 0, 6, 0),
                Name = "labelMinimum",
                Size = new Size(15, 17),
                TabIndex = 2,
                Text = @"0",
                BackColor = Color.Transparent
            };

            _labelMaximum = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new Point(145, 86),
                Margin = new Padding(6, 0, 6, 0),
                Name = "labelMaximum",
                Size = new Size(29, 17),
                TabIndex = 3,
                Text = @"100",
                BackColor = Color.Transparent
            };

            Controls.Add(_labelMaximum);
            Controls.Add(_labelMinimum);
            Controls.Add(_labelProgress);

            Margin = new Padding(6);
            Size = new Size(174, 117);

            Font = SystemFonts.DefaultFont;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [TypeConverter(typeof(SettingsTypeConverter))]
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
        /// Gets or sets the maximum label.
        /// </summary>
        /// <value>The maximum label.</value>
        public System.Windows.Forms.Label MaximumLabel
        {
            get
            {
                return _labelMaximum;
            }
            set
            {
                _labelMaximum = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [maximum visible].
        /// </summary>
        /// <value><c>true</c> if [maximum visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Visible")]
        public bool MaximumVisible
        {
            get
            {
                return _labelMaximum.Visible;
            }

            set
            {
                _labelMaximum.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum label.
        /// </summary>
        /// <value>The minimum label.</value>
        public System.Windows.Forms.Label MinimumLabel
        {
            get
            {
                return _labelMinimum;
            }
            set
            {
                _labelMinimum = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [minimum visible].
        /// </summary>
        /// <value><c>true</c> if [minimum visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Visible")]
        public bool MinimumVisible
        {
            get
            {
                return _labelMinimum.Visible;
            }

            set
            {
                _labelMinimum.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>The progress.</value>
        [DefaultValue(typeof(Color), "Green")]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress label.
        /// </summary>
        /// <value>The progress label.</value>
        public System.Windows.Forms.Label ProgressLabel
        {
            get
            {
                return _labelProgress;
            }
            set
            {
                _labelProgress = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [progress visible].
        /// </summary>
        /// <value><c>true</c> if [progress visible]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("Visible")]
        public bool ProgressVisible
        {
            get
            {
                return _labelProgress.Visible;
            }

            set
            {
                _labelProgress.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        [DefaultValue(30)]
        [Category(PropertyCategory.Layout)]
        [Description("Thickness")]
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [DefaultValue(0)]
        [Category(PropertyCategory.Behavior)]
        public new int Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                base.Value = value;
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

            _progressTextSize = StringUtilities.MeasureText(_labelProgress.Text + @"%", Font, e.Graphics);
            _labelProgress.Location = new Point((Width / 2) - (_progressTextSize.Width / 2), Height - _progressTextSize.Height - 30);

            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;

            Color _backColor = Enabled ? BackColorState.Enabled : BackColorState.Disabled;

            Pen _penBackground = new Pen(_backColor, _thickness);
            int _width = Size.Width - (_thickness * 2);
            Rectangle _rectangle = new Rectangle(_thickness, Size.Height / 4, _width, _width);
            Pen _penProgress = new Pen(_progress, _thickness);

            _graphics.DrawArc(_penBackground, _rectangle, 180F, 180F);
            _graphics.DrawArc(_penProgress, _rectangle, 180F, MathUtilities.GetHalfRadianAngle(Value));

            _labelProgress.Text = Value + @"%";
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            _labelMinimum.Top = _labelMaximum.Top = Height - _labelMaximum.Height - 10;
            _labelMinimum.Left = 20;
            _labelMaximum.Left = Size.Width - _labelMaximum.Width - 20;
        }

        #endregion Protected Methods
    }
}