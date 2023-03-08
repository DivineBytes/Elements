using System;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="ValueChangedEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class ValueChangedEventArgs : EventArgs
    {
        #region Fields

        private long _value;

        #endregion Fields

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ValueChangedEventArgs(long value)
        {
            _value = value;
        }

        #endregion Constructors and Destructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        #endregion Public Properties
    }
}