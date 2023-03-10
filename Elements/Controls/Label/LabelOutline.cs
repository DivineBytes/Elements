using Elements.Constants;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elements.Controls.Label
{
    /// <summary>
    /// The <see cref="LabelOutline"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The outline settings.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class LabelOutline
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelOutline"/> class.
        /// </summary>
        public LabelOutline()
        {
            Color = Color.Red;
            Enabled = false;
            Location = new Point(0, 0);
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
        /// Gets or sets a value indicating whether this <see cref="LabelOutline"/> is enabled.
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

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Renders the specified label outline.
        /// </summary>
        /// <param name="labelOutline">The label outline.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        public static void Render(LabelOutline labelOutline, Graphics graphics, Orientation orientation, string text, Font font)
        {
            GraphicsPath outlinePath = new GraphicsPath();

            switch (orientation)
            {
                case Orientation.Horizontal:
                    {
                        outlinePath.AddString(
                            text,
                            font.FontFamily,
                            (int)font.Style,
                            graphics.DpiY * font.SizeInPoints / 72,
                            labelOutline.Location,
                            new StringFormat());

                        break;
                    }

                case Orientation.Vertical:
                    {
                        outlinePath.AddString(
                            text,
                            font.FontFamily,
                            (int)font.Style,
                            graphics.DpiY * font.SizeInPoints / 72,
                            labelOutline.Location,
                            new StringFormat(StringFormatFlags.DirectionVertical));

                        break;
                    }
            }

            graphics.DrawPath(new Pen(labelOutline.Color), outlinePath);
        }

        #endregion Public Methods
    }
}