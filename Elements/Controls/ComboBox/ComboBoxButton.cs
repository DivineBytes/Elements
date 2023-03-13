using Elements.Constants;
using Elements.Enumerators;
using Elements.Renders;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;

namespace Elements.Controls.ComboBox
{
    /// <summary>
    /// The <see cref="ComboBoxButton"/> class.
    /// </summary>
    [Category(PropertyCategory.Appearance)]
    [Description("The ComboBox Button.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class ComboBoxButton
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxButton"/> class.
        /// </summary>
        public ComboBoxButton()
        {
            Color = Color.FromArgb(119, 119, 118);
            Image = null;
            Style = ComboBoxButtonStyles.Arrow;
            Width = 30;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxButton"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="image">The image.</param>
        /// <param name="style">The style.</param>
        /// <param name="width">The width.</param>
        public ComboBoxButton(Color color, Image image, ComboBoxButtonStyles style, int width) : this()
        {
            Color = color;
            Image = image;
            Style = style;
            Width = width;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public ComboBoxButtonStyles Style { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Renders the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void Render(Graphics graphics, Rectangle rectangle)
        {
            Point _buttonImageLocation;
            Size _buttonImageSize;

            switch (Style)
            {
                case ComboBoxButtonStyles.Arrow:
                    {
                        _buttonImageSize = new Size(10, 6);
                        _buttonImageLocation = new Point(rectangle.X + (rectangle.Width / 2) - (_buttonImageSize.Width / 2), rectangle.Y + (rectangle.Height / 2) - (_buttonImageSize.Height / 2));
                        ControlRender.RenderTriangle(graphics, Color, new Rectangle(_buttonImageLocation, _buttonImageSize), Vertical.Down);
                        break;
                    }

                case ComboBoxButtonStyles.Bars:
                    {
                        _buttonImageSize = new Size(18, 10);
                        _buttonImageLocation = new Point(rectangle.X + (rectangle.Width / 2) - (_buttonImageSize.Width / 2), rectangle.Y + (rectangle.Height / 2) - _buttonImageSize.Height);
                        ControlRender.RenderBars(graphics, _buttonImageLocation, _buttonImageSize, Color, 3, 5);
                        break;
                    }

                case ComboBoxButtonStyles.Image:
                    {
                        if (Image != null)
                        {
                            _buttonImageLocation = new Point(rectangle.X + (rectangle.Width / 2) - (Image.Width / 2), rectangle.Y + (rectangle.Height / 2) - (Image.Height / 2));
                            graphics.DrawImage(Image, _buttonImageLocation);
                            //ImageRender.RenderCentered(graphics, new Rectangle(_buttonImageLocation.X, _buttonImageLocation.Y, Image.Width, Image.Height), Image, new Point((rectangle.Right - Width) + (Image.Width / 2) - 2, (rectangle.Height / 2) - (Image.Height / 2)));
                        }
                        break;
                    }
            }
        }

        #endregion Public Methods
    }
}