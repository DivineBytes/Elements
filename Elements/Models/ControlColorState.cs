using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using Elements.TypeConverters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="ControlColorState"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The control color states of a component.")]
    [DesignerCategory("code")]
    [ToolboxItem(false)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ControlColorState : HoverColorState
    {
        private Color _pressed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlColorState"/> class.
        /// </summary>
        public ControlColorState() : base()
        {
            _pressed = Color.FromArgb(192, 192, 192);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlColorState" /> class.
        /// </summary>
        /// <param name="pressed">The pressed.</param>
        /// <exception cref="System.ArgumentNullException">disabled - Cannot be empty.
        /// or
        /// enabled - Cannot be empty.</exception>
        public ControlColorState(Color pressed) : this()
        {
            if (pressed == Color.Empty)
            {
                throw new ArgumentNullException(nameof(pressed), "Cannot be empty.");
            }

            _pressed = pressed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlColorState"/> class.
        /// </summary>
        /// <param name="disabled">The disabled.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="hover">The hover.</param>
        /// <param name="pressed">The pressed.</param>
        /// <exception cref="System.ArgumentNullException">hover - Cannot be empty.</exception>
        public ControlColorState(Color disabled, Color enabled, Color hover, Color pressed) : base(disabled, enabled, hover)
        {
            if (pressed == Color.Empty)
            {
                throw new ArgumentNullException(nameof(hover), "Cannot be empty.");
            }

            _pressed = pressed;
        }

        /// <summary>
        /// Occurs when [pressed color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property event changed")]
        public event ColorStateChangedEventHandler PressedColorChanged;

        /// <summary>
        /// Gets or sets the pressed.
        /// </summary>
        /// <value>
        /// The pressed.
        /// </value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Color")]
        public Color Pressed
        {
            get
            {
                return _pressed;
            }

            set
            {
                _pressed = value;
                OnPressedColorChanged(new ColorEventArgs(_pressed));
            }
        }

        /// <summary>
        /// Gets the state of the color.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="state">The state.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public new Color GetColorState(bool enabled, MouseStates state)
        {
            return GetColorState(this, enabled, state);
        }

        /// <summary>
        /// Get the control back color state.
        /// </summary>
        /// <param name="colorState">The color State.</param>
        /// <param name="enabled">The enabled toggle.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <returns><see cref="Color"/></returns>
        public static Color GetColorState(ControlColorState colorState, bool enabled, MouseStates mouseState)
        {
            Color _color = Color.Empty;

            if (enabled)
            {
                switch (mouseState)
                {
                    case MouseStates.Normal:
                        {
                            _color = colorState.Enabled;
                            break;
                        }
                    case MouseStates.Hover:
                        {
                            _color = colorState.Hover;
                            break;
                        }
                    case MouseStates.Pressed:
                        {
                            _color = colorState.Pressed;
                            break;
                        }
                }
            }
            else
            {
                _color = colorState.Disabled;
            }

            return _color;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder _stringBuilder = new StringBuilder();
            _stringBuilder.Append(GetType().Name);
            _stringBuilder.Append(" [");
            _stringBuilder.Append("Disabled=");
            _stringBuilder.Append(Disabled);
            _stringBuilder.Append(",");
            _stringBuilder.Append("Enabled=");
            _stringBuilder.Append(Enabled);
            _stringBuilder.Append(",");
            _stringBuilder.Append("Hover=");
            _stringBuilder.Append(Hover);
            _stringBuilder.Append(",");
            _stringBuilder.Append("Pressed=");
            _stringBuilder.Append(Pressed);
            _stringBuilder.Append("]");

            return _stringBuilder.ToString();
        }

        /// <summary>
        /// Raises the <see cref="E:PressedColorChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPressedColorChanged(ColorEventArgs e)
        {
            PressedColorChanged?.Invoke(this, e);
        }
    }
}