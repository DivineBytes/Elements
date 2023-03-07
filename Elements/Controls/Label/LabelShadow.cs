using Elements.TypeConverters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Elements.Controls.Label
{
    /// <summary>
    /// The <see cref="LabelShadow"/> class.
    /// </summary>
    [Description("The shadow settings.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class LabelShadow
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelShadow"/> class.
        /// </summary>
        public LabelShadow()
        {
            Color = Color.FromArgb(100, 0, 0, 0);
            Depth = 4;
            Direction = 315;
            Enabled = false;
            Location = new Point(0, 0);
            Smoothness = 1.5F;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Description("The color.")]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>The depth.</value>
        [Description("The depth.")]
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Description("The direction.")]
        public int Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LabelShadow"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Description("The enabled.")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [Description("The location.")]
        public Point Location { get; set; }

        /// <summary>
        /// Gets or sets the smoothness.
        /// </summary>
        /// <value>The smoothness.</value>
        [Description("The smoothness.")]
        public float Smoothness { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Render the text shadow.
        /// </summary>
        /// <param name="labelShadow">The label shadow.</param>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font to draw.</param>
        /// <param name="clientRectangle">The client rectangle.</param>
        /// <exception cref="ArgumentOutOfRangeException">orientation</exception>
        public static void Render(LabelShadow labelShadow, Graphics graphics, Orientation orientation, string text, Font font, Rectangle clientRectangle)
        {
            // Create shadow into a bitmap
            Bitmap shadowBitmap = new Bitmap(Math.Max((int)(clientRectangle.Width / labelShadow.Smoothness), 1), Math.Max((int)(clientRectangle.Height / labelShadow.Smoothness), 1));
            Graphics imageGraphics = Graphics.FromImage(shadowBitmap);

            // Setup text render
            imageGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Create transformation matrix
            Matrix transformMatrix = new Matrix();
            transformMatrix.Scale(1 / labelShadow.Smoothness, 1 / labelShadow.Smoothness);
            transformMatrix.Translate((float)(labelShadow.Depth * Math.Cos(labelShadow.Direction)), (float)(labelShadow.Depth * Math.Sin(labelShadow.Direction)));
            imageGraphics.Transform = transformMatrix;

            switch (orientation)
            {
                case Orientation.Horizontal:
                    {
                        imageGraphics.DrawString(text, font, new SolidBrush(labelShadow.Color), labelShadow.Location);
                        break;
                    }
                case Orientation.Vertical:
                    {
                        imageGraphics.DrawString(text, font, new SolidBrush(labelShadow.Color), labelShadow.Location, new StringFormat(StringFormatFlags.DirectionVertical));
                        break;
                    }
            }

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(shadowBitmap, clientRectangle, 0, 0, shadowBitmap.Width, shadowBitmap.Height, GraphicsUnit.Pixel);
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }

        #endregion Public Methods
    }
}