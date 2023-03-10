using Elements.Constants;
using Elements.Enumerators;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="TextStyle"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The text style of the component.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class TextStyle
    {
        #region Private Fields

        private StringAlignment textAlignment;
        private ControlColorState textColorState;
        private StringAlignment textLineAlignment;
        private TextRenderingHint textRenderingHint;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextStyle"/> class.
        /// </summary>
        public TextStyle()
        {
            textColorState = new ControlColorState(Color.Black, Color.Black, Color.Black, Color.Black);
            textRenderingHint = TextRenderingHint.ClearTypeGridFit;
            textAlignment = StringAlignment.Center;
            textLineAlignment = StringAlignment.Center;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextStyle"/> class.
        /// </summary>
        /// <param name="colorState">The color State.</param>
        public TextStyle(ControlColorState colorState) : this()
        {
            textColorState = colorState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextStyle"/> class.
        /// </summary>
        /// <param name="colorState">State of the color.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="lineAlignment">The line alignment.</param>
        /// <param name="renderingHint">The rendering hint.</param>
        public TextStyle(ControlColorState colorState, StringAlignment alignment, StringAlignment lineAlignment, TextRenderingHint renderingHint) : this(colorState)
        {
            textAlignment = alignment;
            textLineAlignment = lineAlignment;
            textRenderingHint = renderingHint;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the state of the color.
        /// </summary>
        /// <value>The state of the color.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlColorState ColorState
        {
            get
            {
                return textColorState;
            }

            set
            {
                textColorState = value;
            }
        }

        /// <summary>
        /// Gets or sets the disabled.
        /// </summary>
        /// <value>The disabled.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Disabled
        {
            get
            {
                return textColorState.Disabled;
            }

            set
            {
                textColorState.Disabled = value;
            }
        }

        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        /// <value>The enabled.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Enabled
        {
            get
            {
                return textColorState.Enabled;
            }

            set
            {
                textColorState.Enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets the hover.
        /// </summary>
        /// <value>The hover.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Hover
        {
            get
            {
                return textColorState.Hover;
            }

            set
            {
                textColorState.Hover = value;
            }
        }

        /// <summary>
        /// Gets or sets the pressed.
        /// </summary>
        /// <value>The pressed.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color Pressed
        {
            get
            {
                return textColorState.Pressed;
            }

            set
            {
                textColorState.Pressed = value;
            }
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <value>The string format.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat { Alignment = textAlignment, LineAlignment = textLineAlignment };

                return stringFormat;
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextAlignment)]
        public StringAlignment TextAlignment
        {
            get
            {
                return textAlignment;
            }

            set
            {
                textAlignment = value;
            }
        }

        /// <summary>
        /// Gets or sets the text line alignment.
        /// </summary>
        /// <value>The text line alignment.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextAlignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return textLineAlignment;
            }

            set
            {
                textLineAlignment = value;
            }
        }

        /// <summary>
        /// Gets or sets the text rendering hint.
        /// </summary>
        /// <value>The text rendering hint.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextRenderingHint)]
        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return textRenderingHint;
            }

            set
            {
                textRenderingHint = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Retrieves the color state.
        /// </summary>
        /// <param name="textStyle">The text style.&gt;</param>
        /// <param name="enabled">The enabled state.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color GetColorState(TextStyle textStyle, bool enabled, MouseStates mouseState)
        {
            Color _textColor = Color.Empty;

            switch (mouseState)
            {
                case MouseStates.Normal:
                    {
                        _textColor = enabled ? textStyle.Enabled : textStyle.Disabled;
                        break;
                    }

                case MouseStates.Hover:
                    {
                        _textColor = enabled ? textStyle.Hover : textStyle.Disabled;
                        break;
                    }

                case MouseStates.Pressed:
                    {
                        _textColor = enabled ? textStyle.Pressed : textStyle.Disabled;
                        break;
                    }
            }

            return _textColor;
        }

        /// <summary>
        /// Gets the state of the color.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="state">The state.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public Color GetColorState(bool enabled, MouseStates state)
        {
            return GetColorState(this, enabled, state);
        }

        #endregion Public Methods
    }
}