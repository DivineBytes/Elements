using System.Drawing;

namespace Elements.Controls.Rating
{
    /// <summary>
    /// The <see cref="StarGenerator"/> class.
    /// </summary>
    public static class StarGenerator
    {
        #region Public Methods

        /// <summary>
        /// Generate half of the detailed star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateDetailedSemiStar(RectangleF rectangle)
        {
            return new[]
                {
                    new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.4f), rectangle.Y + (rectangle.Height * 0.73f)), new PointF(rectangle.X + (rectangle.Width * 0.17f), rectangle.Y + (rectangle.Height * 0.83f)), new PointF(rectangle.X + (rectangle.Width * 0.27f), rectangle.Y + (rectangle.Height * 0.6f)), new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.5f)),
                    new PointF(rectangle.X + (rectangle.Width * 0.27f), rectangle.Y + (rectangle.Height * 0.4f)), new PointF(rectangle.X + (rectangle.Width * 0.17f), rectangle.Y + (rectangle.Height * 0.17f)), new PointF(rectangle.X + (rectangle.Width * 0.4f), rectangle.Y + (rectangle.Height * 0.27f))
                };
        }

        /// <summary>
        /// Generate a detailed star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateDetailedStar(RectangleF rectangle)
        {
            return new[]
                {
                    new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f)), new PointF(rectangle.X + (rectangle.Width * 0.6f), rectangle.Y + (rectangle.Height * 0.27f)), new PointF(rectangle.X + (rectangle.Width * 0.83f), rectangle.Y + (rectangle.Height * 0.17f)), new PointF(rectangle.X + (rectangle.Width * 0.73f), rectangle.Y + (rectangle.Height * 0.4f)), new PointF(rectangle.X + (rectangle.Width * 1f), rectangle.Y + (rectangle.Height * 0.5f)), new PointF(rectangle.X + (rectangle.Width * 0.73f), rectangle.Y + (rectangle.Height * 0.6f)),
                    new PointF(rectangle.X + (rectangle.Width * 0.83f), rectangle.Y + (rectangle.Height * 0.83f)), new PointF(rectangle.X + (rectangle.Width * 0.6f), rectangle.Y + (rectangle.Height * 0.73f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.4f), rectangle.Y + (rectangle.Height * 0.73f)), new PointF(rectangle.X + (rectangle.Width * 0.17f), rectangle.Y + (rectangle.Height * 0.83f)), new PointF(rectangle.X + (rectangle.Width * 0.27f), rectangle.Y + (rectangle.Height * 0.6f)),
                    new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.5f)), new PointF(rectangle.X + (rectangle.Width * 0.27f), rectangle.Y + (rectangle.Height * 0.4f)), new PointF(rectangle.X + (rectangle.Width * 0.17f), rectangle.Y + (rectangle.Height * 0.17f)), new PointF(rectangle.X + (rectangle.Width * 0.4f), rectangle.Y + (rectangle.Height * 0.27f))
                };
        }

        /// <summary>
        /// Generate half of a fat star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateFatSemiStar(RectangleF rectangle)
        {
            return new[] { new PointF(rectangle.X + (rectangle.Width * 0.31f), rectangle.Y + (rectangle.Height * 0.33f)), new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.37f)), new PointF(rectangle.X + (rectangle.Width * 0.25f), rectangle.Y + (rectangle.Height * 0.62f)), new PointF(rectangle.X + (rectangle.Width * 0.19f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0.81f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f)) };
        }

        /// <summary>
        /// Generate a fat star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateFatStar(RectangleF rectangle)
        {
            return new[]
                {
                    new PointF(rectangle.X + (rectangle.Width * 0.31f), rectangle.Y + (rectangle.Height * 0.33f)), new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.37f)), new PointF(rectangle.X + (rectangle.Width * 0.25f), rectangle.Y + (rectangle.Height * 0.62f)), new PointF(rectangle.X + (rectangle.Width * 0.19f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0.81f)), new PointF(rectangle.X + (rectangle.Width * 0.81f), rectangle.Y + (rectangle.Height * 1f)),
                    new PointF(rectangle.X + (rectangle.Width * 0.75f), rectangle.Y + (rectangle.Height * 0.62f)), new PointF(rectangle.X + (rectangle.Width * 1f), rectangle.Y + (rectangle.Height * 0.37f)), new PointF(rectangle.X + (rectangle.Width * 0.69f), rectangle.Y + (rectangle.Height * 0.33f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f))
                };
        }

        /// <summary>
        /// Generate half of a typical thin star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateNormalSemiStar(RectangleF rectangle)
        {
            return new[] { new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f)), new PointF(rectangle.X + (rectangle.Width * 0.38f), rectangle.Y + (rectangle.Height * 0.38f)), new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.38f)), new PointF(rectangle.X + (rectangle.Width * 0.31f), rectangle.Y + (rectangle.Height * 0.61f)), new PointF(rectangle.X + (rectangle.Width * 0.19f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0.77f)) };
        }

        /// <summary>
        /// Generate a typical thin star polygon as a point[].
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="PointF"/>.</returns>
        public static PointF[] GenerateNormalStar(RectangleF rectangle)
        {
            return new[]
                {
                    new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0f)), new PointF(rectangle.X + (rectangle.Width * 0.38f), rectangle.Y + (rectangle.Height * 0.38f)), new PointF(rectangle.X + (rectangle.Width * 0f), rectangle.Y + (rectangle.Height * 0.38f)), new PointF(rectangle.X + (rectangle.Width * 0.31f), rectangle.Y + (rectangle.Height * 0.61f)), new PointF(rectangle.X + (rectangle.Width * 0.19f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.5f), rectangle.Y + (rectangle.Height * 0.77f)),
                    new PointF(rectangle.X + (rectangle.Width * 0.8f), rectangle.Y + (rectangle.Height * 1f)), new PointF(rectangle.X + (rectangle.Width * 0.69f), rectangle.Y + (rectangle.Height * 0.61f)), new PointF(rectangle.X + (rectangle.Width * 1f), rectangle.Y + (rectangle.Height * 0.38f)), new PointF(rectangle.X + (rectangle.Width * 0.61f), rectangle.Y + (rectangle.Height * 0.38f))
                };
        }

        #endregion Public Methods
    }
}