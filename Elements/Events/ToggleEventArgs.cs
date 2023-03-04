using System;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="ToggleEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class ToggleEventArgs : EventArgs
    {
        private bool _state;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleEventArgs"/> class.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public ToggleEventArgs(bool state)
        {
            _state = state;
        }

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
    }
}