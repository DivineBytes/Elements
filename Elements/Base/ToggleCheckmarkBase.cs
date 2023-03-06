using Elements.Constants;
using Elements.Enumerators;
using Elements.Models;
using Elements.Renders;
using Elements.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ToggleCheckmarkBase"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ToggleBase"/>
    public class ToggleCheckmarkBase : ToggleBase
    {
        private CheckOptions _checkOptions;
        private Size _textSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleCheckmarkBase"/> class.
        /// </summary>
        protected ToggleCheckmarkBase()
        {
            _checkOptions = new CheckOptions(
                new Rectangle(0, 0, 14, 14),
                new Rectangle(3, 7, 8, 8));
        }

        /// <summary>
        /// Called when [create control].
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            MouseMove += (sender, args) =>
            {
                Cursor = GraphicsUtilities.IsInBounds(args.Location, _checkOptions.Box) ? Cursors.Hand : Cursors.Default;
            };
        }

        /// <summary>
        /// Gets or sets the size of the text.
        /// </summary>
        /// <value>The size of the text.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size TextSize
        {
            get
            {
                return _textSize;
            }

            set
            {
                _textSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToggleCheckmarkBase"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Category(PropertyCategory.Behavior)]
        [Description("The checked status of the control.")]
        public bool Checked
        {
            get
            {
                return Toggle;
            }

            set
            {
                if (Toggle != value)
                {
                    Toggle = value;
                    OnToggleChanged(this, new Elements.Events.ToggleEventArgs(Toggle));
                    //Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the check options.
        /// </summary>
        /// <value>The check options.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CheckOptions CheckOptions
        {
            get
            {
                return _checkOptions;
            }

            set
            {
                _checkOptions = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _checkOptions.Box = new Rectangle(new Point(Padding.Left, (ClientRectangle.Height / 2) - (_checkOptions.Box.Height / 2)), _checkOptions.Box.Size);

            Color _backColor = _checkOptions.ColorState.GetColorState(Enabled, MouseState);

            Graphics _graphics = e.Graphics;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 2, ClientRectangle.Height + 2);
            GraphicsPath controlGraphicsPath = Border.CreatePath(_checkOptions.BoxBorder, _clientRectangle);

            e.Graphics.SetClip(controlGraphicsPath);

            _textSize = StringUtilities.MeasureText(Text, Font, _graphics);
            Point _textLocation = new Point(_checkOptions.Box.Right + _checkOptions.Spacing, (ClientRectangle.Height / 2) - (_textSize.Height / 2));
            Color _textColor = Enabled ? ForeColor : ForeColor;

            ControlRender.DrawCheckBox(_graphics, _checkOptions, Checked, Enabled, _backColor, BackgroundImage, MouseState, Text, Font, _textColor, _textLocation);
            e.Graphics.ResetClip();
        }
    }
}