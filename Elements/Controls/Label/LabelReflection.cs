using Elements.TypeConverters;
using Elements.Utilities;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Elements.Controls.Label
{
    /// <summary>
    /// The <see cref="LabelReflection"/> class.
    /// </summary>
    [Description("The reflection settings.")]
    [TypeConverter(typeof(LabelReflectionTypeConverter))]
    public class LabelReflection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelReflection"/> class.
        /// </summary>
        public LabelReflection()
        {
            Color = Color.FromArgb(120, 0, 0, 0);
            Enabled = false;
            Spacing = 0F;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LabelReflection"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Description("The reflection enabled.")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Description("The reflection color.")]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the spacing.
        /// </summary>
        /// <value>The spacing.</value>
        [Description("The reflection spacing.")]
        public float Spacing { get; set; }

        /// <summary>
        /// Renders the text reflection.
        /// </summary>
        /// <param name="labelReflection">The label reflection.</param>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <param name="location">The location.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="lineAlignment">The line Alignment.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">orientation</exception>
        public static void Render(LabelReflection labelReflection, Graphics graphics, Orientation orientation, string text, Font font, Rectangle clientRectangle, PointF location, StringAlignment alignment, StringAlignment lineAlignment)
        {
            PointF reflectionLocation = new PointF(0, 0);
            Bitmap reflectionBitmap = new Bitmap(clientRectangle.Width, clientRectangle.Height);
            Graphics imageGraphics = Graphics.FromImage(reflectionBitmap);

            // Setup text render
            imageGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Rotate reflection
            switch (orientation)
            {
                case Orientation.Horizontal:
                    {
                        imageGraphics.TranslateTransform(0, StringUtilities.MeasureText(text, font, graphics).Height);
                        imageGraphics.ScaleTransform(1, -1);

                        reflectionLocation = new PointF(0, location.Y - (StringUtilities.MeasureText(text, font, graphics).Height / 2) - labelReflection.Spacing);
                        break;
                    }
                case Orientation.Vertical:
                    {
                        imageGraphics.ScaleTransform(-1, 1);
                        reflectionLocation = new PointF(location.X - (StringUtilities.MeasureText(text, font, graphics).Width / 2) + labelReflection.Spacing, 0);
                        break;
                    }
            }

            // Draw reflected string
            imageGraphics.DrawString(text, font, new SolidBrush(labelReflection.Color), reflectionLocation, StringUtilities.GetOrientedStringFormat(orientation, alignment, lineAlignment));

            // Draw the reflection image
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(reflectionBitmap, clientRectangle, 0, 0, reflectionBitmap.Width, reflectionBitmap.Height, GraphicsUnit.Pixel);
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
    }
}