using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using Elements.TypeConverters;
using Elements.UITypeEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="HoverColorState"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The hover color states of a component.")]
    [DesignerCategory("code")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [ToolboxItem(false)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class HoverColorState : ColorState
    {
        private Color _hover;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverColorState"/> class.
        /// </summary>
        public HoverColorState() : base()
        {
            _hover = Color.FromArgb(224, 224, 224);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverColorState"/> class.
        /// </summary>
        /// <param name="hover">The hover.</param>
        /// <exception cref="ArgumentNullException">
        /// disabled - Cannot be empty. or enabled - Cannot be empty.
        /// </exception>
        public HoverColorState(Color hover) : this()
        {
            if (hover == Color.Empty)
            {
                throw new ArgumentNullException(nameof(hover), "Cannot be empty.");
            }

            _hover = hover;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoverColorState"/> class.
        /// </summary>
        /// <param name="disabled">The disabled.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="hover">The hover.</param>
        /// <exception cref="ArgumentNullException">
        /// disabled - Cannot be empty. or enabled - Cannot be empty.
        /// </exception>
        public HoverColorState(Color disabled, Color enabled, Color hover) : base(disabled, enabled)
        {
            if (hover == Color.Empty)
            {
                throw new ArgumentNullException(nameof(hover), "Cannot be empty.");
            }

            _hover = hover;
        }

        /// <summary>
        /// Occurs when [hover color changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Property event changed")]
        public event ColorStateChangedEventHandler HoverColorChanged;

        /// <summary>
        /// Gets or sets the hover.
        /// </summary>
        /// <value>The hover.</value>
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Color")]
        public Color Hover
        {
            get
            {
                return _hover;
            }

            set
            {
                _hover = value;
                OnHoverColorChanged(new ColorEventArgs(_hover));
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
        public static Color GetColorState(HoverColorState colorState, bool enabled, MouseStates mouseState)
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
                            _color = colorState.Hover;
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
            _stringBuilder.Append("]");

            return _stringBuilder.ToString();
        }

        /// <summary>
        /// Raises the <see cref="E:HoverColorChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnHoverColorChanged(ColorEventArgs e)
        {
            HoverColorChanged?.Invoke(this, e);
        }
    }
}