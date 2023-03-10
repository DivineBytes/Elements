using Elements.Base;
using Elements.Constants;
using Elements.Delegates;
using Elements.Events;
using Elements.Extensions;
using Elements.TypeConverters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.ControlBox
{
    /// <summary>
    /// The <see cref="ControlBox"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The ControlBox")]
    [Designer(typeof(ControlBoxDesigner))]
    [ToolboxBitmap(typeof(ControlBox), "ControlBox.bmp")]
    [ToolboxItem(true)]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ControlBox : ControlBase
    {
        #region Private Fields

        private ControlBoxButton _closeButton;
        private ControlBoxButton _helpButton;
        private ControlBoxButton _maximizeButton;
        private ControlBoxButton _minimizeButton;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlBox"/> class.
        /// </summary>
        public ControlBox()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BackColor = Color.Transparent;
            Size = new Size(100, 25);
            Padding = new Padding(0);

            _closeButton = new ControlBoxButton
            {
                Location = new Point(ControlBoxButton.DefaultWidth * 3, 0),
                OffsetLocation = new Point(0, 2),
                Text = ControlBoxButtons.Close.GetDisplayName(),

                BackColorState = new Models.ControlColorState(
                    Color.Transparent,
                    Color.Transparent,
                    Color.FromArgb(232, 17, 35),
                    Color.FromArgb(241, 112, 122)),

                ForeColorState = new Models.ControlColorState(
                    Color.FromArgb(105, 105, 105),
                    Color.FromArgb(105, 105, 105),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(255, 255, 255))
            };

            _closeButton.Click += OnClose;
            _closeButton.VisibleChanged += Button_VisibleChanged;

            _maximizeButton = new ControlBoxButton()
            {
                Location = new Point(ControlBoxButton.DefaultWidth * 2, 0),
                OffsetLocation = new Point(1, 2),
                Text = ControlBoxButtons.Maximize.GetDisplayName(),

                BackColorState = new Models.ControlColorState(
                    Color.Transparent,
                    Color.Transparent,
                    Color.FromArgb(190, 186, 186),
                    Color.FromArgb(105, 105, 105)),

                ForeColorState = new Models.ControlColorState(
                    Color.FromArgb(105, 105, 105),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128))
            };

            _maximizeButton.Click += OnMaximize;
            _maximizeButton.VisibleChanged += Button_VisibleChanged;

            _minimizeButton = new ControlBoxButton()
            {
                Location = new Point(ControlBoxButton.DefaultWidth, 0),
                OffsetLocation = new Point(1, 0),
                Text = ControlBoxButtons.Minimize.GetDisplayName(),

                BackColorState = new Models.ControlColorState(
                    Color.Transparent,
                    Color.Transparent,
                    Color.FromArgb(190, 186, 186),
                    Color.FromArgb(105, 105, 105)),

                ForeColorState = new Models.ControlColorState(
                    Color.FromArgb(105, 105, 105),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128))
            };

            _minimizeButton.Click += OnMinimize;
            _minimizeButton.VisibleChanged += Button_VisibleChanged;

            _helpButton = new ControlBoxButton()
            {
                Location = new Point(0, 0),
                OffsetLocation = new Point(0, 1),
                Text = ControlBoxButtons.Help.GetDisplayName(),

                BackColorState = new Models.ControlColorState(
                    Color.Transparent,
                    Color.Transparent,
                    Color.FromArgb(190, 186, 186),
                    Color.FromArgb(105, 105, 105)),

                ForeColorState = new Models.ControlColorState(
                    Color.FromArgb(105, 105, 105),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128),
                    Color.FromArgb(128, 128, 128))
            };

            _helpButton.Click += OnHelp;
            _helpButton.VisibleChanged += Button_VisibleChanged;

            Controls.Add(_helpButton);
            Controls.Add(_minimizeButton);
            Controls.Add(_maximizeButton);
            Controls.Add(_closeButton);
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when the close click.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ControlBoxEventHandler CloseClick;

        /// <summary>
        /// Occurs when the help click.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ControlBoxEventHandler HelpClick;

        /// <summary>
        /// Occurs when the maximize click.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ControlBoxEventHandler MaximizeClick;

        /// <summary>
        /// Occurs when the minimize click.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ControlBoxEventHandler MinimizeClick;

        /// <summary>
        /// Occurs when the window restored.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyChanged)]
        public event ControlBoxEventHandler WindowRestored;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        /// <value>The close.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBoxButton Close
        {
            get
            {
                return _closeButton;
            }

            set
            {
                _closeButton = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the help.
        /// </summary>
        /// <value>The help.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBoxButton Help
        {
            get
            {
                return _helpButton;
            }

            set
            {
                _helpButton = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximize.
        /// </summary>
        /// <value>The maximize.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBoxButton Maximize
        {
            get
            {
                return _maximizeButton;
            }

            set
            {
                _maximizeButton = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimize.
        /// </summary>
        /// <value>The minimize.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBoxButton Minimize
        {
            get
            {
                return _minimizeButton;
            }

            set
            {
                _minimizeButton = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the parent form.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Form ParentForm
        {
            get
            {
                return Parent.FindForm();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Toggles the form window state.
        /// </summary>
        /// <param name="windowState">The form window state.</param>
        /// <returns>The <see cref="FormWindowState"/>.</returns>
        public static FormWindowState ToggleFormWindowState(FormWindowState windowState)
        {
            return windowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        /// <summary>
        /// Automatically places the <see cref="ControlBox"/> on the <see cref="Form"/> corner location.
        /// </summary>
        /// <param name="spacing">The spacing.</param>
        public void AutoPlaceOnForm(int spacing)
        {
            Location = new Point(ParentForm.Location.X + ParentForm.Width - Width + spacing, 0);
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="form">The form.</param>
        public void CloseForm(Form form)
        {
            if (form == null)
            {
                form = ParentForm;
            }

            form.Close();
            OnCloseClick(this, new ControlBoxEventArgs(form));
        }

        /// <summary>
        /// Maximizes the form.
        /// </summary>
        /// <param name="form">The form.</param>
        public void MaximizeForm(Form form)
        {
            if (form == null)
            {
                form = ParentForm;
            }

            if (form.WindowState == FormWindowState.Normal)
            {
                if (!form.MaximizeBox)
                {
                    // Disabled maximizing.
                    return;
                }

                if (_maximizeButton.BoxType == ControlBoxType.Default)
                {
                    _maximizeButton.Text = ControlBoxButtons.Restore.GetDisplayName();
                }

                form.WindowState = ToggleFormWindowState(form.WindowState);
                _maximizeButton.Invalidate();
                OnMaximizeClick(this, new ControlBoxEventArgs(form));
            }
        }

        /// <summary>
        /// Minimizes the form.
        /// </summary>
        /// <param name="form">The form.</param>
        public void MinimizeForm(Form form)
        {
            if (form == null)
            {
                form = ParentForm;
            }

            form.WindowState = FormWindowState.Minimized;

            OnMinimizeClick(this, new ControlBoxEventArgs(form));
        }

        /// <summary>
        /// Restores the window.
        /// </summary>
        /// <param name="form">The form.</param>
        public void RestoreWindow(Form form)
        {
            if (form == null)
            {
                form = ParentForm;
            }

            if (form.WindowState == FormWindowState.Maximized)
            {
                if (!form.MaximizeBox)
                {
                    // Disabled restoring form.
                    return;
                }

                if (_maximizeButton.BoxType == ControlBoxType.Default)
                {
                    _maximizeButton.Text = ControlBoxButtons.Maximize.GetDisplayName();
                }

                form.WindowState = ToggleFormWindowState(form.WindowState);
                Invalidate();
                OnWindowRestored(this, new ControlBoxEventArgs(form));
            }
        }

        /// <summary>
        /// Toggle the window state between maximized and restored form.
        /// </summary>
        /// <param name="form">The form.</param>
        public void ToggleWindowState(Form form)
        {
            if (form == null)
            {
                form = ParentForm;
            }

            if (form.WindowState == FormWindowState.Normal)
            {
                MaximizeForm(form);
            }
            else
            {
                RestoreWindow(form);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the Close event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="ControlBoxEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnClose(object sender, EventArgs e)
        {
            CloseForm(ParentForm);
        }

        /// <summary>
        /// Called when [close click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="ControlBoxEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnCloseClick(object sender, ControlBoxEventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises the Close event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnHelp(object sender, EventArgs e)
        {
            OnHelpClick(sender, new ControlBoxEventArgs(ParentForm));
        }

        /// <summary>
        /// The help button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnHelpClick(object sender, ControlBoxEventArgs e)
        {
            HelpClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Called when [maximize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMaximize(object sender, EventArgs e)
        {
            ToggleWindowState(ParentForm);
        }

        /// <summary>
        /// Called when [maximize click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="ControlBoxEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnMaximizeClick(object sender, ControlBoxEventArgs e)
        {
            MaximizeClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Called when [minimize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMinimize(object sender, EventArgs e)
        {
            MinimizeForm(ParentForm);
        }

        /// <summary>
        /// The minimize button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnMinimizeClick(object sender, ControlBoxEventArgs e)
        {
            MinimizeClick?.Invoke(sender, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (IsHandleCreated)
            {
                Size = GetAdjustedSize();
            }
            else
            {
                Size = new Size(100, 25);
            }
        }

        /// <summary>
        /// Called when [window restored].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="ControlBoxEventArgs"/> instance containing the event data.
        /// </param>
        protected virtual void OnWindowRestored(object sender, ControlBoxEventArgs e)
        {
            WindowRestored?.Invoke(sender, e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Handles the VisibleChanged event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_VisibleChanged(object sender, EventArgs e)
        {
            if (_helpButton.Visible)
            {
                _minimizeButton.Location = new Point(_minimizeButton.Width, 0);
            }
            else
            {
                _minimizeButton.Location = new Point(0, 0);
                _maximizeButton.Location = new Point(_minimizeButton.Right, 0);
                _closeButton.Location = new Point(_maximizeButton.Right, 0);
            }

            if (_minimizeButton.Visible)
            {
                _maximizeButton.Location = new Point(_minimizeButton.Right, 0);
            }
            else
            {
                if (_helpButton.Visible)
                {
                    _maximizeButton.Location = new Point(_helpButton.Right, 0);
                }
                else
                {
                    _maximizeButton.Location = new Point(0, 0);
                }
            }

            if (_maximizeButton.Visible)
            {
                _closeButton.Location = new Point(_maximizeButton.Right, 0);
            }
            else
            {
                if (_minimizeButton.Visible)
                {
                    _closeButton.Location = new Point(_minimizeButton.Right, 0);
                }
                else
                {
                    if (_helpButton.Visible)
                    {
                        _closeButton.Location = new Point(_helpButton.Right, 0);
                    }
                    else
                    {
                        _closeButton.Location = new Point(0, 0);
                    }
                }
            }

            OnResize(new EventArgs());
        }

        /// <summary>
        /// Retrieves the adjusted <see cref="Control"/>- <see cref="Size"/>.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        private Size GetAdjustedSize(int height = ControlBoxButton.DefaultWidth)
        {
            try
            {
                var _x = 0;

                if (_helpButton.Visible)
                {
                    _x += _helpButton.Width;
                }

                if (_minimizeButton.Visible)
                {
                    _x += _minimizeButton.Width;
                }

                if (_maximizeButton.Visible)
                {
                    _x += _maximizeButton.Width;
                }

                if (_closeButton.Visible)
                {
                    _x += ControlBoxButton.DefaultWidth;
                }

                return new Size(_x, height);
            }
            catch
            {
                return new Size(ControlBoxButton.DefaultWidth, ControlBoxButton.DefaultHeight);
            }
        }

        #endregion Private Methods
    }
}