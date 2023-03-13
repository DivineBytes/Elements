using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elements.Events
{
    /// <summary>
    /// The <see cref="DragControlEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class DragControlEventArgs : EventArgs
    {
        #region Private Fields

        private Point _point;
        private Rectangle _rectangle;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DragControlEventArgs"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public DragControlEventArgs(Point point)
        {
            _point = point;
            _rectangle = new Rectangle(_point, Size.Empty);
            _rectangle.Inflate(SystemInformation.DragSize);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the point.
        /// </summary>
        /// <value>The point.</value>
        public Point Point
        {
            get
            {
                return _point;
            }
        }

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <value>The rectangle.</value>
        public Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }

            set
            {
                _rectangle = value;
            }
        }

        #endregion Public Properties
    }
}