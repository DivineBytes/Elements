using Elements.Constants;
using Elements.Delegates;
using Elements.Events;
using System.ComponentModel;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ToggleBase"/> class.
    /// </summary>
    /// <seealso cref="ControlBase"/>
    public class ToggleBase : ControlBase
    {
        #region Public Events

        /// <summary>
        /// Occurs when the toggle changed.
        /// </summary>
        [Category(EventCategory.PropertyChanged)]
        [Description("Occours when the toggle has been changed on the control.")]
        public event ToggleChangedEventHandler ToggleChanged;

        #endregion Public Events

        #region Internal Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToggleBase"/> is toggle.
        /// </summary>
        /// <value><c>true</c> if toggle; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool Toggle { get; set; }

        #endregion Internal Properties

        #region Protected Methods

        /// <summary>
        /// Occurs when the ToggleChanged event fires.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnToggleChanged(object sender, ToggleEventArgs e)
        {
            Toggle = e.State;
            ToggleChanged?.Invoke(sender, e);
            Invalidate();
        }

        #endregion Protected Methods
    }
}