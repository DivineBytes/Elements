using Elements.Constants;
using Elements.Models;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;

namespace Elements.Controls.ComboBox
{
    /// <summary>
    /// The <see cref="ComboBoxSeparator"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The ComboBox Separator.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ComboBoxSeparator
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxSeparator"/> class.
        /// </summary>
        public ComboBoxSeparator()
        {
            Color = Color.FromArgb(180, 180, 180);
            Thickness = 1;
            Location = new Point(0, 0);
            Size = new Size(0, 0);
            Visible = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxSeparator"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="thickness">The thickness.</param>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public ComboBoxSeparator(Color color, int thickness, Point location, Size size, bool visible) : this()
        {
            Color = color;
            Thickness = thickness;
            Location = location;
            Size = size;
            Visible = visible;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        public int Thickness { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Point Location { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ComboBoxSeparator"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }

        #endregion Public Properties

        /// <summary>
        /// Renders the separator.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="border">The border.</param>
        /// <param name="comboBox">The combo box.</param>
        public void Render(Graphics graphics, Rectangle rect, Border border, System.Windows.Forms.ComboBox comboBox)
        {
            Location = new Point(rect.X - 1, border.Thickness);
            Size = new Size(1, comboBox.Height - border.Thickness - 1);

            graphics.DrawLine(new Pen(Color, Thickness),
                new Point(Location.X, Location.Y),
                new Point(Location.X, Size.Height));
        }
    }
}