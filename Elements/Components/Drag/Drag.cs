using Elements.Base;
using Elements.Components.Gradient;
using Elements.Constants;
using Elements.Delegates;
using Elements.Events;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Components.Drag
{
    /// <summary>
    /// The <see cref="Drag"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ComponentBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ControlDrag")]
    [DefaultProperty("Text")]
    [Description("The drag component enables controls to be draggable.")]
    [ToolboxBitmap(typeof(Drag), "Drag.bmp")]
    [ToolboxItem(true)]
    public class Drag : ComponentBase
    {
        #region Private Fields

        private Control _control;
        private Cursor _cursorMove;
        private DragDirection _direction;
        private Point _lastPosition;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="cursor">The cursor.</param>
        /// <param name="direction">The direction.</param>
        /// <exception cref="System.ArgumentNullException">control</exception>
        public Drag(Control control, Cursor cursor, DragDirection direction) : this()
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), ArgumentDescription.CannotBeNull);
            }

            _control = control;
            _cursorMove = cursor;
            _direction = direction;

            if (Enabled)
            {
                ToggleAttachment(true);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="cursor">The cursor.</param>
        public Drag(Control control, Cursor cursor) : this(control, cursor, DragDirection.Both)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public Drag(Control control) : this(control, Cursors.SizeAll)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        public Drag()
        {
            _control = null;
            _cursorMove = Cursors.SizeAll;
            _direction = DragDirection.Both;
            _lastPosition = Point.Empty;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when the control drag.
        /// </summary>
        [Category(EventCategory.DragDrop)]
        [Description(EventDescription.ControlDragChanged)]
        public event ControlDragEventHandler ControlDrag;

        /// <summary>
        /// Occurs when the control drag cursor changed.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.CursorChanged)]
        public event ControlDragCursorChangedEventHandler ControlDragCursorChanged;

        /// <summary>
        /// Occurs when the control drag toggle.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.ControlDragToggleChanged)]
        public event ControlDragToggleEventHandler ControlDragToggle;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Control)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Control Control
        {
            get
            {
                return _control;
            }

            set
            {
                _control = value;
            }
        }

        /// <summary>
        /// Gets or sets the cursor move.
        /// </summary>
        /// <value>The cursor move.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Cursor)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Cursor CursorMove
        {
            get
            {
                return _cursorMove;
            }

            set
            {
                _cursorMove = value;
                OnControlDragCursorChanged(new CursorChangedEventArgs(_cursorMove));
            }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.DragDirection)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public DragDirection Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;

                if (_direction != DragDirection.None)
                {
                    ToggleAttachment(true);
                }
                else
                {
                    ToggleAttachment(false);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Drag"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.Toggle)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool Enabled
        {
            get
            {
                return _direction != DragDirection.None;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is dragging.
        /// </summary>
        /// <value><c>true</c> if this instance is dragging; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Category(PropertyCategory.Behavior)]
        [Description(PropertyDescription.IsDragging)]
        public bool IsDragging { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Toggles the attachment.
        /// </summary>
        /// <param name="attach">if set to <c>true</c> [attach].</param>
        public void ToggleAttachment(bool attach)
        {
            if (_control == null)
            {
                return;
            }

            if (attach)
            {
                _control.MouseDown += ControlMouseDown;
                _control.MouseMove += ControlMouseMove;
                _control.MouseUp += ControlMouseUp;
            }
            else
            {
                _control.MouseDown -= ControlMouseDown;
                _control.MouseMove -= ControlMouseMove;
                _control.MouseUp -= ControlMouseUp;
            }

            OnControlDragToggle(new ToggleEventArgs(Enabled));
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:ControlDrag"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="DragControlEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnControlDrag(DragControlEventArgs e)
        {
            ControlDrag?.Invoke(e);
        }

        /// <summary>
        /// Raises the <see cref="E:ControlDragCursorChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="CursorChangedEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnControlDragCursorChanged(CursorChangedEventArgs e)
        {
            ControlDragCursorChanged?.Invoke(e);
        }

        /// <summary>
        /// Raises the <see cref="E:ControlDragToggle"/> event.
        /// </summary>
        /// <param name="e">The <see cref="ToggleEventArgs"/> instance containing the event data.</param>
        protected virtual void OnControlDragToggle(ToggleEventArgs e)
        {
            ControlDragToggle?.Invoke(e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Control mouse down event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            _lastPosition = e.Location;
            _control.Cursor = CursorMove;
        }

        /// <summary>
        /// Control mouse move event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void ControlMouseMove(object sender, MouseEventArgs e)
        {
            if (!Enabled || (e.Button != MouseButtons.Left))
            {
                return;
            }

            switch (_direction)
            {
                case DragDirection.Both:
                    {
                        _control.Left += e.Location.X - _lastPosition.X;
                        _control.Top += e.Location.Y - _lastPosition.Y;
                        break;
                    }

                case DragDirection.Horizontal:
                    {
                        _control.Left += e.Location.X - _lastPosition.X;
                        break;
                    }

                case DragDirection.Vertical:
                    {
                        _control.Top += e.Location.Y - _lastPosition.Y;
                        break;
                    }

                case DragDirection.None:
                    {
                        break;
                    }
            }

            IsDragging = true;
            OnControlDrag(new DragControlEventArgs(e.Location));
        }

        /// <summary>
        /// Control mouse up event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void ControlMouseUp(object sender, MouseEventArgs e)
        {
            if (Enabled)
            {
                _control.Cursor = Cursors.Default;
            }
        }

        #endregion Private Methods
    }
}