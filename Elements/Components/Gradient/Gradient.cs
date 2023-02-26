using Elements.Base;
using Elements.Constants;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Components.Gradient
{
    /// <summary>
    /// The <see cref="Gradient"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ComponentBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Control")]
    [Description("The gradient component can be used to apply gradient backgrounds on controls.")]
    [Designer(typeof(GradientDesigner))]
    [ToolboxBitmap(typeof(Gradient), "Gradient.bmp")]
    [ToolboxItem(true)]
    public class Gradient : ComponentBase
    {
        /// <summary>
        /// The default size.
        /// </summary>
        public static readonly Size DefaultSize = new Size(25, 25);

        private bool _autoSize;
        private ColorField colorField;
        private Control _control;
        private Size _size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gradient"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public Gradient(IContainer container) : this()
        {
            container.Add(this);
            UpdateGradient(DefaultSize, colorField);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gradient" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="colorField">The color field.</param>
        public Gradient(Control control, ColorField colorField) : this(control, colorField, control.Size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gradient" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="colorField">The color field.</param>
        /// <param name="size">The size.</param>
        public Gradient(Control control, ColorField colorField, Size size) : this()
        {
            _control = control;
            Size _gradientSize = GetGradientSize(_autoSize, _control, size);
            UpdateGradient(_gradientSize, colorField);
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Gradient"/> class from being created.
        /// </summary>
        private Gradient()
        {
            colorField = new ColorField(Color.Green, Color.Yellow, Color.Black, Color.Red);
            _size = DefaultSize;
            _autoSize = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic size].
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Auto size")]
        public bool AutoSize
        {
            get
            {
                return _autoSize;
            }

            set
            {
                if (value == _autoSize)
                {
                    return;
                }

                _autoSize = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets or sets the bottom left.
        /// </summary>
        /// <value>The bottom left.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color BottomLeft
        {
            get
            {
                return colorField.BottomLeft;
            }

            set
            {
                colorField.BottomLeft = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets or sets the bottom right.
        /// </summary>
        /// <value>The bottom right.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color BottomRight
        {
            get
            {
                return colorField.BottomRight;
            }

            set
            {
                colorField.BottomRight = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Behavior)]
        [Description("The control to attach to this component.")]
        public Control Control
        {
            get
            {
                return _control;
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                _control = value;

                _control.Resize += Control_Resize;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets the <see cref="Gradient"/> as a bitmap.
        /// </summary>
        [Browsable(true)]
        [Category(PropertyCategory.Appearance)]
        [Description("Image")]
        public Image Image
        {
            get
            {
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                return ImageUtilities.CreateGradient(_gradientSize, colorField.TopLeft, colorField.TopRight, colorField.BottomLeft, colorField.BottomRight);
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Size Size
        {
            get
            {
                return _size;
            }

            set
            {
                if (value == _size)
                {
                    return;
                }

                _size = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets or sets the top left.
        /// </summary>
        /// <value>The top left.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color TopLeft
        {
            get
            {
                return colorField.TopLeft;
            }

            set
            {
                colorField.TopLeft = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Gets or sets the top right.
        /// </summary>
        /// <value>The top right.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(PropertyCategory.Appearance)]
        [Description("Color")]
        public Color TopRight
        {
            get
            {
                return colorField.TopRight;
            }

            set
            {
                colorField.TopRight = value;
                Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
                UpdateGradient(_gradientSize, colorField);
            }
        }

        /// <summary>
        /// Update the gradient.
        /// </summary>
        /// <param name="size">The size of the gradient.</param>
        /// <param name="colorField">The color field.</param>
        private void UpdateGradient(Size size, ColorField colorField)
        {
            _size = size;

            if (_control == null)
            {
                return;
            }

            GraphicsUtilities.AssignGradientBackground(_control, _size, colorField.TopLeft, colorField.TopRight, colorField.BottomLeft, colorField.BottomRight);
        }

        /// <summary>
        /// Handles the Resize event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Control_Resize(object sender, EventArgs e)
        {
            Size _gradientSize = GetGradientSize(_autoSize, _control, _size);
            UpdateGradient(_gradientSize, colorField);
        }

        /// <summary>
        /// Gets the gradient size.
        /// </summary>
        /// <param name="autoSize">The auto size toggle.</param>
        /// <param name="control">The control.</param>
        /// <param name="custom">The custom size.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        public Size GetGradientSize(bool autoSize, Control control, Size custom)
        {
            Size _newSize;

            if (autoSize)
            {
                if (control == null)
                {
                    _newSize = custom;
                }
                else
                {
                    _newSize = control.Size;
                    _size = _newSize;
                }
            }
            else
            {
                _newSize = custom;
            }

            return _newSize;
        }
    }
}