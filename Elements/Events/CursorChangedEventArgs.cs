using System;
using System.Windows.Forms;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="CursorChangedEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class CursorChangedEventArgs : EventArgs
    {
        #region Private Fields

        private Cursor _cursor;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorChangedEventArgs"/> class.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        public CursorChangedEventArgs(Cursor cursor)
        {
            _cursor = cursor;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>The cursor.</value>
        public Cursor Cursor
        {
            get
            {
                return _cursor;
            }

            set
            {
                _cursor = value;
            }
        }

        #endregion Public Properties
    }
}