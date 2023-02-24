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
    /// The <see cref="ColorState"/> class.
    /// </summary>
    [TypeConverter(typeof(SettingsTypeConverter))]
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The color states of a component.")]
    [Category(PropertyCategory.Appearance)]
    public class ColorState
    {
        private Color _disabled;
        private Color _enabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorState"/> class.
        /// </summary>
        /// <param name="disabled">The disabled color.</param>
        /// <param name="enabled">The normal color.</param>
        public ColorState(Color disabled, Color enabled) : this()
        {
            _disabled = disabled;
            _enabled = enabled;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorState"/> class.
        /// </summary>
        public ColorState()
        {
            _disabled = Color.FromArgb(255, 255, 255);
            _enabled = Color.FromArgb(255, 255, 255);
        }

        /// <summary>
        /// Occurs when [disabled color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property event changed")]
        public event ControlDelegates.BackColorStateChangedEventHandler DisabledColorChanged;

        /// <summary>
        /// Occurs when [normal color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property event changed")]
        public event ControlDelegates.BackColorStateChangedEventHandler NormalColorChanged;

        /// <summary>
        /// Gets or sets the disabled.
        /// </summary>
        /// <value>The disabled.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Color")]
        public Color Disabled
        {
            get
            {
                return _disabled;
            }

            set
            {
                _disabled = value;
                OnDisabledColorChanged(new ColorEventArgs(_disabled));
            }
        }

        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        /// <value>The enabled.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Color")]
        public Color Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
                OnDisabledColorChanged(new ColorEventArgs(_enabled));
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ColorState"/> is empty.
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return _disabled.IsEmpty && _enabled.IsEmpty;
            }
        }

        /// <summary>
        /// Get the control back color state.
        /// </summary>
        /// <param name="colorState">The color State.</param>
        /// <param name="enabled">The enabled toggle.</param>
        /// <param name="mouseState">The mouse state.</param>
        /// <returns><see cref="Color"/></returns>
        public static Color BackColorState(ColorState colorState, bool enabled, MouseStates mouseState)
        {
            Color _color;

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
                            _color = colorState.Enabled;
                            break;
                        }

                    case MouseStates.Pressed:
                        {
                            _color = colorState.Enabled;
                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException(nameof(mouseState), mouseState, null);
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

            if (IsEmpty)
            {
                _stringBuilder.Append("IsEmpty");
            }
            else
            {
                _stringBuilder.Append("Disabled=");
                _stringBuilder.Append(Disabled);
                _stringBuilder.Append("Normal=");
                _stringBuilder.Append(Enabled);
            }

            _stringBuilder.Append("]");

            return _stringBuilder.ToString();
        }

        /// <summary>
        /// Raises the <see cref="E:DisabledColorChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDisabledColorChanged(ColorEventArgs e)
        {
            DisabledColorChanged?.Invoke(e);
        }

        /// <summary>
        /// Raises the <see cref="E:NormalColorChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnNormalColorChanged(ColorEventArgs e)
        {
            NormalColorChanged?.Invoke(e);
        }
    }
}