using System.Drawing;

namespace Elements.Components.Gradient
{
    /// <summary>
    /// The <see cref="ColorField"/> class.
    /// </summary>
    public class ColorField
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class.
        /// </summary>
        public ColorField()
        {
            TopLeft = Color.Empty;
            TopRight = Color.Empty;
            BottomLeft = Color.Empty;
            BottomRight = Color.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorField"/> class.
        /// </summary>
        /// <param name="topLeft">The top left.</param>
        /// <param name="topRight">The top right.</param>
        /// <param name="bottomLeft">The bottom left.</param>
        /// <param name="bottomRight">The bottom right.</param>
        public ColorField(Color topLeft, Color topRight, Color bottomLeft, Color bottomRight) : this()
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the bottom left.
        /// </summary>
        /// <value>The bottom left.</value>
        public Color BottomLeft { get; set; }

        /// <summary>
        /// Gets or sets the bottom right.
        /// </summary>
        /// <value>The bottom right.</value>
        public Color BottomRight { get; set; }

        /// <summary>
        /// Gets or sets the top left.
        /// </summary>
        /// <value>The top left.</value>
        public Color TopLeft { get; set; }

        /// <summary>
        /// Gets or sets the top right.
        /// </summary>
        /// <value>The top right.</value>
        public Color TopRight { get; set; }

        #endregion Public Properties
    }
}