using Elements.Base;
using Elements.Constants;
using Elements.Enumerators;
using Elements.Events;
using Elements.Models;
using Elements.Renders;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.Button
{
    /// <summary>
    /// The <see cref="Button"/> class.
    /// </summary>
    /// <seealso cref="ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The Button")]
    [Designer(typeof(ButtonDesigner))]
    [ToolboxBitmap(typeof(Button), "Button.bmp")]
    [ToolboxItem(true)]
    public class Button : ControlBase, IButtonControl
    {
        #region Private Fields

        private ControlColorState _backColorState;
        private Border _border;
        private Image _image;
        private ElementImageLayout _imageLayout;
        private TextImageRelation _textImageRelation;
        private TextStyle _textStyle;
        private DialogResult dialogResult;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
        {
            Size = new Size(140, 45);
            _border = new Border();
            _backColorState = new ControlColorState();

            dialogResult = DialogResult.None;
            _textImageRelation = TextImageRelation.Overlay;
            _imageLayout = ElementImageLayout.Stretch;

            _textStyle = new TextStyle();
        }

        #endregion Public Constructors

        #region Private Destructors

        /// <summary>
        /// Finalizes an instance of the <see cref="Button"/> class.
        /// </summary>
        ~Button()
        {
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Events

        /// <summary>
        /// Occurs when [text style changed].
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event EventHandler TextStyleChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the back color.
        /// </summary>
        /// <value>The state of the back color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlColorState BackColorState
        {
            get
            {
                return _backColorState;
            }

            set
            {
                _backColorState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background image layout.
        /// </summary>
        /// <value>The background image layout.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.ImageLayout)]
        public new ElementImageLayout BackgroundImageLayout
        {
            get
            {
                return _imageLayout;
            }

            set
            {
                _imageLayout = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Border Border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value returned from the parent form when the button is clicked.
        /// </summary>
        [Browsable(false)]
        public DialogResult DialogResult
        {
            get
            {
                return dialogResult;
            }

            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    dialogResult = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public new Color ForeColor
        {
            get
            {
                base.ForeColor = _textStyle.Enabled;
                return base.ForeColor;
            }

            set
            {
                _textStyle.Enabled = value;
                base.ForeColor = _textStyle.Enabled;
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
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
        /// Gets or sets the text image relation.
        /// </summary>
        /// <value>The text image relation.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.TextImageRelation)]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return _textImageRelation;
            }

            set
            {
                _textImageRelation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TextStyle"/>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public TextStyle TextStyle
        {
            get
            {
                return _textStyle;
            }

            set
            {
                if (_textStyle == null)
                {
                    return;
                }

                _textStyle = value;
                OnTextStyleChanged(this, new EventArgs());
            }
        }

        #endregion Public Properties

        #region Private Properties

        private bool IsDefault { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Notify s a control that this is the default button so that its appearance and behavior
        /// is adjusted accordingly.
        /// </summary>
        /// <param name="value">If the control should behave as a default button.</param>
        public void NotifyDefault(bool value)
        {
            if (IsDefault != value)
            {
                IsDefault = value;
            }
        }

        /// <summary>
        /// Generates a click event for the control.
        /// </summary>
        public void PerformClick()
        {
            if (CanSelect)
            {
                OnClick(EventArgs.Empty);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            Form form = FindForm();

            if (form != null)
            {
                form.DialogResult = dialogResult;
            }

            AccessibilityNotifyClients(AccessibleEvents.StateChange, -1);
            AccessibilityNotifyClients(AccessibleEvents.NameChange, -1);

            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Pressed));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (Enabled)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;

            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.TextRenderingHint = TextStyle.TextRenderingHint;

            Rectangle _clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath controlGraphicsPath = Border.CreatePath(_border, _clientRectangle);

            Color _backColor = ControlColorState.GetColorState(BackColorState, Enabled, MouseState);

            e.Graphics.SetClip(controlGraphicsPath);
            ImageRender.Render(e.Graphics, _backColor, BackgroundImage, _imageLayout, _clientRectangle);

            if (_image != null)
            {
                Color _textColor = Enabled ? ForeColor : TextStyle.Disabled;
                ControlRender.RenderContent(e.Graphics, ClientRectangle, Text, Font, _textColor, _image, _image.Size, _textImageRelation);
            }
            else
            {
                TextRender.Render(e.Graphics, ClientRectangle, Text, Font, Enabled, MouseState, TextStyle);
            }

            e.Graphics.ResetClip();
            Border.Render(e.Graphics, _border, MouseState, controlGraphicsPath);

            base.OnPaint(e);
        }

        /// <summary>
        /// Invokes the text style changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnTextStyleChanged(object sender, EventArgs e)
        {
            Invalidate();
            TextStyleChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods
    }
}