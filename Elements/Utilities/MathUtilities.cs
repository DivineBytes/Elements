using System;
using System.Globalization;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="MathUtilities"/> class.
    /// </summary>
    public static class MathUtilities
    {
        /// <summary>
        /// Gets half a radian angle.
        /// </summary>
        /// <param name="value">The progress value.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int GetHalfRadianAngle(int value)
        {
            return int.Parse(Math.Round((value * 180.0) / 100.0, 0).ToString(CultureInfo.CurrentCulture));
        }
    }
}