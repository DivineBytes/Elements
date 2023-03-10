using Elements.Base;
using Elements.Constants;
using Elements.Events;
using Elements.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.CheckBox
{
    /// <summary>
    /// The <see cref="CheckBox"/> class.
    /// </summary>
    /// <seealso cref="ToggleCheckmarkBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Checked")]
    [Description("The CheckBox")]
    [Designer(typeof(CheckBoxDesigner))]
    [ToolboxBitmap(typeof(CheckBox), "CheckBox.bmp")]
    [ToolboxItem(true)]
    public class CheckBox : ToggleCheckmarkBase
    {
        #region Private Fields

        private CheckState _checkState;
        private bool _threeState;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class.
        /// </summary>
        public CheckBox()
        {
            Size = new Size(125, 23);

            CheckOptions.Box = new Rectangle(0, 4, 14, 14);
            CheckOptions.Check = new Rectangle(9, 3, 14, 14);
            CheckOptions.BoxBorder.Rounding = 3;
            CheckOptions.CheckBorder.Thickness = 3;
            CheckOptions.Style = CheckOptions.CheckStyle.Check;

            _checkState = CheckState.Unchecked;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Occurs when the check state changed.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Checked")]
        public event EventHandler CheckStateChanged;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets or sets the state of the check.
        /// </summary>
        /// <value>The state of the check.</value>
        [DefaultValue(typeof(CheckState), "Unchecked")]
        [Category(PropertyCategory.Behavior)]
        [Description("Check state.")]
        public CheckState CheckState
        {
            get
            {
                return _checkState;
            }

            set
            {
                if (_checkState != value)
                {
                    _checkState = value;

                    bool newChecked = _checkState != CheckState.Unchecked;
                    bool checkedChanged = Checked != newChecked;

                    Checked = newChecked;

                    // Generate events
                    if (checkedChanged)
                    {
                        OnToggleChanged(this, new ToggleEventArgs(Toggle));
                    }

                    OnCheckStateChanged(EventArgs.Empty);

                    // Repaint
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether three state.
        /// </summary>
        /// <value><c>true</c> if [three state]; otherwise, <c>false</c>.</value>
        [Category(PropertyCategory.Behavior)]
        [DefaultValue(false)]
        [Description(PropertyDescription.Toggle)]
        public bool ThreeState
        {
            get
            {
                return _threeState;
            }

            set
            {
                if (_threeState != value)
                {
                    _threeState = value;
                    Invalidate();
                }
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:CheckStateChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            CheckStateChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnClick(EventArgs e)
        {
            switch (_checkState)
            {
                case CheckState.Unchecked:
                    {
                        CheckState = CheckState.Checked;
                        break;
                    }

                case CheckState.Checked:
                    {
                        CheckState = ThreeState ? CheckState.Indeterminate : CheckState.Unchecked;
                        break;
                    }

                case CheckState.Indeterminate:
                    {
                        CheckState = CheckState.Unchecked;
                        break;
                    }
            }

            base.OnClick(e);
        }

        /// <summary>
        /// Occurs when the ToggleChanged event fires.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected override void OnToggleChanged(object sender, ToggleEventArgs e)
        {
            base.OnToggleChanged(sender, e);
            OnCheckStateChanged(EventArgs.Empty);
            Invalidate();
        }

        #endregion Protected Methods
    }
}