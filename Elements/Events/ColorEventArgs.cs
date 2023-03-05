using System.Drawing;

namespace Elements.Events
{
    /// <summary>
    /// This <see cref="ColorEventArgs"/> class.
    /// </summary>
    public class ColorEventArgs
    {
        #region Private Fields

        private Color _color;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEventArgs"/> class.
        /// </summary>
        public ColorEventArgs()
        {
            _color = Color.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEventArgs"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ColorEventArgs(Color color) : this()
        {
            _color = color;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        #endregion Public Properties
    }
}