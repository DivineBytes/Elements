using Elements.Constants;
using Elements.Controls.ProgressBar;
using Elements.InteropServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Elements.Controls
{
    /// <summary>
    /// Represents a Windows progress bar control which displays its <see
    /// cref="System.Windows.Forms.ProgressBar.Value"/> as text on a faded background.
    /// </summary>
    /// <remarks>
    /// ProgressBarEx is a specialized type of <see cref="System.Windows.Forms.ProgressBar"/>, which
    /// it extends to fade its background colors and to display its <see cref="Text"/>.
    /// <para>
    /// You can manipulate the background fading intensity by changing the value of property <see
    /// cref="Fade"/> which accepts values between 0 and 255. Lower values make the
    /// background darker; higher values make the background lighter.
    /// </para>
    /// <para>
    /// The current <see cref="System.Windows.Forms.ProgressBar.Text"/> is displayed using the
    /// values of properties <see cref="Font"/> and <see cref="ForeColor"/>.
    /// </para>
    /// <para>
    /// <note type="inherit">When you derive from ProgressBarEx, adding new functionality to the
    /// derived class, if your derived class references objects that must be disposed of before an
    /// instance of your class is destroyed, you must override the <see
    /// cref="Dispose(System.Boolean)"/> method, and call <see
    /// cref="System.ComponentModel.Component.Dispose()">Dispose()</see> on all objects that are
    /// referenced in your class, before calling <c>Dispose(disposing)</c> on the base class.</note>
    /// </para>
    /// </remarks>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Value")]
    [Description("Provides a ProgressBar which displays its Value as text on a faded background.")]
    [Designer(typeof(ProgressBarDesigner))]
    [ToolboxBitmap(typeof(ProgressBarEx), "ProgressBar.bmp")]
    [ToolboxItem(true)]
    public class ProgressBarEx : System.Windows.Forms.ProgressBar
    {
        private int _fade;
        private SolidBrush _fadeBrush;
        private bool _progressVisible;

        /// <summary>
        /// The <see cref="ValueChangedEventHandler"/> delegate.
        /// </summary>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedEventHandler(ProgressEventArgs e);

        /// <summary>
        /// The value changed.
        /// </summary>
        public ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        public ProgressBarEx()
        {
            ForeColor = SystemColors.ControlText;
            _fadeBrush = new SolidBrush(Color.FromArgb(Fade, Color.White));
            _progressVisible = true;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Value - Provided value is out of the Minimum to Maximum range of values.
        /// </exception>
        [Bindable(true)]
        [Category(PropertyCategory.Behavior)]
        [Description("The current value for the ProgressBar, in the range specified by the minimum and maximum properties.")]
        public new int Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                if (value != base.Value)
                {
                    if ((value < Minimum) || (value > Maximum))
                    {
                        throw new ArgumentOutOfRangeException(nameof(Value), "Provided value is out of the Minimum to Maximum range of values.");
                    }

                    base.Value = value;
                    OnValueChanged(new ProgressEventArgs(base.Value, this));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [progress visible].
        /// </summary>
        /// <value><c>true</c> if [progress visible]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ProgressVisible
        {
            get
            {
                return _progressVisible;
            }

            set
            {
                _progressVisible = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the opacity of the white overlay brush which fades the background colors of
        /// the <see cref="ProgressBar"/>.
        /// </summary>
        /// <value>
        /// An <see cref="System.Int32"/> representing the alpha value of the overlay color. The
        /// default is <b>150</b>.
        /// </value>
        /// <remarks>
        /// You can use this property to manipulate the density of the background coloring of this
        /// control, to allow for better readability of any text within the <see
        /// cref="ProgressBar"/>. You can use the <see cref="Font"/> and <see
        /// cref="ForeColor"/> properties to further optimize the display of text.
        /// <para>
        /// Acceptable values for this property are between 0 and 255 inclusive. The default is 150;
        /// lower values make the background darker; higher values make the background lighter.
        /// </para>
        /// </remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The value assigned to the property is less than 0 or greater than 255.
        /// </exception>
        [Category("Appearance")]
        [DefaultValue(0)]
        [Description("Specifies the opacity of the white overlay brush which fades the background colors of the ProgressBar.")]
        public int Fade
        {
            get
            {
                return _fade;
            }

            set
            {
                if (value < 0 || value > 255)
                {
                    object[] str = { value };
                    throw new ArgumentOutOfRangeException("value",
                        string.Format(CultureInfo.CurrentCulture,
                            "A value of '{0}' is not valid for 'Fade'. 'Fade' must be between 0 and 255.", str));
                }

                _fade = value;

                // Clean up previous brush
                if (_fadeBrush != null)
                {
                    _fadeBrush.Dispose();
                }

                _fadeBrush = new SolidBrush(Color.FromArgb(value, Color.White));

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Drawing.Font"/> of the text displayed by the <see cref="ProgressBar"/>.
        /// </summary>
        /// <value>
        /// The <see cref="System.Drawing.Font"/> to apply to the text displayed by the control.
        /// </value>
        /// <remarks>
        /// You can use the Font property to change the <see cref="System.Drawing.Font"/> to use
        /// when drawing text. To change the text <see cref="Color"/>, use the <see
        /// cref="ForeColor"/> property.
        /// <para>
        /// The Font property is an ambient property. An ambient property is a control property
        /// that, if not set, is retrieved from the parent control.
        /// </para>
        /// <para>
        /// Because the <see cref="System.Drawing.Font"/> class is immutable (meaning that you
        /// cannot adjust any of its properties), you can only assign the Font property a new Font.
        /// However, you can base the new font on the existing font.
        /// </para>
        /// <para>
        /// <note type="inherit">When overriding the Font property in a derived class, use the base
        /// class's Font property to extend the base implementation. Otherwise, you must provide all
        /// the implementation.</note>
        /// </para>
        /// </remarks>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the text displayed by <see cref="ProgressBar"/>.
        /// </summary>
        /// <value>
        /// A <see cref="Color"/> that represents the control's foreground color. The default is <b>ControlText</b>.
        /// </value>
        /// <remarks>
        /// You can use the ForeColor property to change the color of the text within the <see
        /// cref="ProgressBar"/> to match the text of other controls on your form. To change the
        /// <see cref="System.Drawing.Font"/> to use when drawing text, use the <see
        /// cref="Font">ProgressBarEx.Font</see> property.
        /// <para>
        /// <note type="inherit">When overriding the ForeColor property in a derived class, use the
        /// base class's ForeColor property to extend the base implementation. Otherwise, you must
        /// provide all the implementation.</note>
        /// </para>
        /// </remarks>
        [DefaultValue(typeof(Color), "ControlText")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets the text associated with this <see cref="ProgressBar"/>.
        /// </summary>
        /// <value>A <see cref="string"/> representing the text displayed in the control.</value>
        /// <remarks>
        /// The <see cref="ProgressBar"/> control supports display of a single line of text,
        /// consisting of the <see cref="System.Windows.Forms.ProgressBar.Value"/> followed by a
        /// percent sign.
        /// <para>
        /// The text is displayed using the values of properties <see cref="Font"/> and
        /// <see cref="ForeColor"/>.
        /// </para>
        /// </remarks>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(false)]
        public override string Text
        {
            get
            {
                return Value.ToString(CultureInfo.CurrentCulture) + "%";
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ValueChangedEvent"/> event.
        /// </summary>
        /// <param name="eventArgs">
        /// The <see cref="ProgressEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnValueChanged(ProgressEventArgs eventArgs)
        {
            ValueChanged?.Invoke(eventArgs);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="ProgressBar"/> and optionally
        /// releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <b>True</b> to release both managed and unmanaged resources; <b>false</b> to release
        /// only unmanaged resources.
        /// </param>
        /// <remarks>
        /// This method is called by the public <see cref="Control.Dispose"/> method and the <see
        /// cref="object.Finalize"/> method. Dispose invokes Dispose with the <i>disposing</i>
        /// parameter set to <b>true</b>. Finalize invokes Dispose with <i>disposing</i> set to <b>false</b>.
        /// <para>
        /// <note type="inherit">Dispose might be called multiple times by other objects. When
        /// overriding <i>Dispose(Boolean)</i>, be careful not to reference objects that have been
        /// previously disposed of in an earlier call to Dispose.
        /// <para>
        /// If your derived class references objects that must be disposed of before an instance of
        /// your class is destroyed, you must call <see cref="Control.Dispose"/> on all objects that
        /// are referenced in your class, before calling <c>Dispose(disposing)</c> on the base class.
        /// </para>
        /// </note>
        /// </para>
        /// </remarks>
        /// <overloads>
        /// Releases all resources used by the <see cref="ProgressBar"/>.
        /// <para>
        /// This member is overloaded. For complete information about this member, click a name in
        /// the overload list.
        /// </para>
        /// </overloads>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_fadeBrush != null)
                {
                    _fadeBrush.Dispose();
                    _fadeBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns the parameters used to create the window for the <see cref="ProgressBar"/> control.
        /// </summary>
        /// <value>
        /// A <see cref="System.Windows.Forms.CreateParams"/> object that contains the required
        /// creation parameters for the <see cref="ProgressBar"/> control.
        /// </value>
        /// <remarks>
        /// The information returned by the CreateParams property is used to pass information about
        /// the initial state and appearance of this control, at the time an instance of this class
        /// is being created.
        /// <para>
        /// <note type="inherit">When overriding the CreateParams property in a derived class, use
        /// the base class's CreateParams property to extend the base implementation. Otherwise, you
        /// must provide all the implementation.</note>
        /// </para>
        /// </remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myParams = base.CreateParams;

                // Make the control use double buffering
                myParams.ExStyle |= (int)WM.WS_EX_COMPOSITED;

                return myParams;
            }
        }

        /// <summary>
        /// Decrement from the value.
        /// </summary>
        /// <param name="value">Amount of value to decrement.</param>
        public void Decrement(int value)
        {
            if (Value > Minimum)
            {
                Value -= value;
                if (Value < Minimum)
                {
                    Value = Minimum;
                }
            }
            else
            {
                Value = Minimum;
            }

            Invalidate();
        }

        /// <summary>
        /// Increment to the value.
        /// </summary>
        /// <param name="value">Amount of value to increment.</param>
        public new void Increment(int value)
        {
            if (Value < Maximum)
            {
                Value += value;
                if (Value > Maximum)
                {
                    Value = Maximum;
                }
            }
            else
            {
                Value = Maximum;
            }

            Invalidate();
        }

        /// <summary>
        /// Set the minimum and maximum value range.
        /// </summary>
        /// <param name="minimumValue">The minimum.</param>
        /// <param name="maximumValue">The maximum.</param>
        public void SetRange(int minimumValue, int maximumValue)
        {
            if ((Minimum != minimumValue) || (Maximum != maximumValue))
            {
                if (minimumValue > maximumValue)
                {
                    minimumValue = maximumValue;
                }

                Minimum = minimumValue;
                Maximum = maximumValue;

                int beforeValue = Value;
                if (Value < Minimum)
                {
                    Value = Minimum;
                }

                if (Value > Maximum)
                {
                    Value = Maximum;
                }

                if (beforeValue != Value)
                {
                    OnValueChanged(ProgressEventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows Message to process.</param>
        /// <remarks>
        /// All messages are sent to the WndProc method after getting filtered through the
        /// PreProcessMessage method. The WndProc method corresponds exactly to the Windows
        /// WindowProc function.
        /// <para>
        /// <note type="inherit">Inheriting controls should call the base class's WndProc method to
        /// process any messages that they do not handle.</note>
        /// </para>
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            int message = m.Msg;

            if (message == (int)WM.PAINT)
            {
                WmPaint(ref m);
                return;
            }

            if (message == (int)WM.PRINTCLIENT)
            {
                WmPrintClient(ref m);
                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Returns a string representation for this <see cref="ProgressBar"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that describes this control.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(GetType().FullName);
            builder.Append(", Minimum: ");
            builder.Append(Minimum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Maximum: ");
            builder.Append(Maximum.ToString(CultureInfo.CurrentCulture));
            builder.Append(", Value: ");
            builder.Append(Value.ToString(CultureInfo.CurrentCulture));

            return builder.ToString();
        }

        /// <summary>
        /// Paints the private.
        /// </summary>
        /// <param name="device">The device.</param>
        private void PaintPrivate(IntPtr device)
        {
            // Create a Graphics object for the device context
            using (Graphics graphics = Graphics.FromHdc(device))
            {
                Rectangle rect = ClientRectangle;

                if (_fadeBrush != null)
                {
                    // Paint a translucent white layer on top, to fade the colors a bit
                    graphics.FillRectangle(_fadeBrush, rect);
                }

                if (ProgressVisible)
                {
                    TextRenderer.DrawText(graphics, Text, Font, rect, ForeColor);
                }
            }
        }

        /// <summary>
        /// Wms the paint.
        /// </summary>
        /// <param name="m">The m.</param>
        private void WmPaint(ref Message m)
        {
            // Create a wrapper for the Handle
            HandleRef myHandle = new HandleRef(this, Handle);

            // Prepare the window for painting and retrieve a device context
            PAINTSTRUCT pAINTSTRUCT = new PAINTSTRUCT();
            IntPtr hDC = User32.BeginPaint(myHandle, ref pAINTSTRUCT);

            try
            {
                // Apply hDC to message
                m.WParam = hDC;

                // Let Windows paint
                base.WndProc(ref m);

                // Custom painting
                PaintPrivate(hDC);
            }
            finally
            {
                // Release the device context that BeginPaint retrieved
                User32.EndPaint(myHandle, ref pAINTSTRUCT);
            }
        }

        /// <summary>
        /// Wms the print client.
        /// </summary>
        /// <param name="m">The m.</param>
        private void WmPrintClient(ref Message m)
        {
            // Retrieve the device context
            IntPtr hDC = m.WParam;

            // Let Windows paint
            base.WndProc(ref m);

            // Custom painting
            PaintPrivate(hDC);
        }
    }
}