using Elements.Constants;
using Elements.Delegates;
using Elements.Enumerators;
using Elements.Events;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ControlBase"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control"/>
    /// <seealso cref="System.ICloneable"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DesignerCategory("code")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [ToolboxItem(false)]
    public abstract class ControlBase : Control, ICloneable
    {
        #region Private Fields

        private MouseStates _mouseState;

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlBase"/> class.
        /// </summary>
        protected ControlBase()
        {
            // Allow transparent BackColor.
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Double buffering to reduce drawing flicker.
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Repaint entire control whenever resizing.
            SetStyle(ControlStyles.ResizeRedraw, true);

            UpdateStyles();

            DoubleBuffered = true;
            ResizeRedraw = true;

            _mouseState = MouseStates.Normal;
        }

        #endregion Protected Constructors

        #region Public Events

        /// <summary>
        /// Occurs when [mouse state changed].
        /// </summary>
        [Category(EventCategory.Mouse)]
        [Description("Occours when the MouseState of the control has changed.")]
        public event MouseStateChangedEventHandler MouseStateChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="MouseState"/>.
        /// </summary>
        [Category(PropertyCategory.Appearance)]
        [Description("The mouse state.")]
        public MouseStates MouseState
        {
            get
            {
                return _mouseState;
            }

            set
            {
                if (_mouseState == value)
                {
                    return;
                }

                _mouseState = value;
                OnMouseStateChanged(this, new MouseStateEventArgs(_mouseState));
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Creates a copy of the current object.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion Public Methods

        #region Protected Methods

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
        /// Raises the <see cref="E:MouseHover"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            OnMouseStateChanged(this, new MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Invokes the mouse state changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected virtual void OnMouseStateChanged(object sender, MouseStateEventArgs e)
        {
            MouseState = e.MouseStates;
            Invalidate();
            MouseStateChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods
    }
}