using System;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="ToggleEventArgs"/> class.
    /// </summary>
    /// <seealso cref="EventArgs"/>
    public class ToggleEventArgs : EventArgs
    {
        #region Private Fields

        private bool _state;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleEventArgs"/> class.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public ToggleEventArgs(bool state)
        {
            _state = state;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToggleEventArgs"/> is state.
        /// </summary>
        /// <value><c>true</c> if state; otherwise, <c>false</c>.</value>
        public bool State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        #endregion Public Properties
    }
}