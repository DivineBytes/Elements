using System.Drawing;

namespace Elements.Events
{
    /// <summary>
    /// This <see cref="ColorEventArgs"/> class.
    /// </summary>
    public class ColorEventArgs
    {
        private Color _color;

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
    }
}