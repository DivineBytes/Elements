using Elements.Base;
using Elements.Constants;
using Elements.Utilities;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Label
{
    /// <summary>
    /// The <see cref="Label"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The Label")]
    [Designer(typeof(LabelDesigner))]
    [ToolboxBitmap(typeof(Label), "Label.bmp")]
    [ToolboxItem(true)]
    public class Label : ControlBase
    {
        #region Private Fields

        private StringAlignment _alignment;
        private LabelOutline _labelOutline;
        private LabelReflection _labelReflection;
        private LabelShadow _labelShadow;
        private StringAlignment _lineAlignment;
        private Orientation _orientation;
        private Color _textDisabled;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        public Label()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            _labelOutline = new LabelOutline();
            _labelReflection = new LabelReflection();
            _labelShadow = new LabelShadow();

            _alignment = StringAlignment.Near;
            _lineAlignment = StringAlignment.Center;
            _orientation = Orientation.Horizontal;
            _textDisabled = Color.Gray;

            Size = new Size(75, 23);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the disabled text.
        /// </summary>
        /// <value>The disabled text.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The disabled text color.")]
        public Color DisabledText
        {
            get
            {
                return _textDisabled;
            }
            set
            {
                _textDisabled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The text orientation.")]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                _orientation = value;
                Size = GraphicsUtilities.FlipOrientationSize(_orientation, Size);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outline.
        /// </summary>
        /// <value>The outline.</value>
        [Category(PropertyCategory.Appearance)]
        public LabelOutline Outline
        {
            get
            {
                return _labelOutline;
            }
            set
            {
                _labelOutline = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the reflection.
        /// </summary>
        /// <value>The reflection.</value>
        [Category(PropertyCategory.Appearance)]
        public LabelReflection Reflection
        {
            get
            {
                return _labelReflection;
            }
            set
            {
                _labelReflection = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow.
        /// </summary>
        /// <value>The shadow.</value>
        [Category(PropertyCategory.Appearance)]
        public LabelShadow Shadow
        {
            get
            {
                return _labelShadow;
            }
            set
            {
                _labelShadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The text alignment.")]
        public StringAlignment TextAlignment
        {
            get
            {
                return _alignment;
            }

            set
            {
                _alignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text line alignment.
        /// </summary>
        /// <value>The text line alignment.</value>
        [Category(PropertyCategory.Appearance)]
        [Description("The text line alignment.")]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return _lineAlignment;
            }

            set
            {
                _lineAlignment = value;
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

            Graphics graphics = e.Graphics;

            RectangleF textBoxRectangle;
            if (Reflection.Enabled && (_orientation == Orientation.Vertical))
            {
                textBoxRectangle = new RectangleF(StringUtilities.MeasureText(Text, Font, graphics).Height, 0, ClientRectangle.Width, ClientRectangle.Height);
            }
            else
            {
                textBoxRectangle = new RectangleF(0, 0, ClientRectangle.Width, ClientRectangle.Height);
            }

            // Draw the text outline
            if (Outline.Enabled)
            {
                _labelOutline.Location = new Point((int)textBoxRectangle.Location.X, (int)textBoxRectangle.Location.Y);
                LabelOutline.Render(_labelOutline, graphics, _orientation, Text, Font);
            }

            // Draw the shadow
            if (Shadow.Enabled)
            {
                LabelShadow.Render(_labelShadow, graphics, _orientation, Text, Font, ClientRectangle);
            }

            // Draw the reflection text.
            if (Reflection.Enabled)
            {
                LabelReflection.Render(_labelReflection, graphics, _orientation, Text, Font, ClientRectangle, textBoxRectangle.Location, _alignment, _lineAlignment);
            }

            Color _foreColor = Enabled ? ForeColor : DisabledText;

            graphics.DrawString(Text, Font, new SolidBrush(_foreColor), textBoxRectangle, StringUtilities.GetOrientedStringFormat(_orientation, _alignment, _lineAlignment));
        }

        #endregion Protected Methods
    }
}