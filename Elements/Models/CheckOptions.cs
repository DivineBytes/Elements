using Elements.Constants;
using Elements.TypeConverters;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="CheckOptions"/> class.
    /// </summary>
    [Category(PropertyCategory.Design)]
    [Description("The check options.")]
    [TypeConverter(typeof(SettingsTypeConverter))]
    public class CheckOptions
    {
        #region Public Enums

        /// <summary>
        /// The <see cref="CheckStyle"/> enum.
        /// </summary>
        public enum CheckStyle
        {
            /// <summary>
            /// The Check.
            /// </summary>
            Check = 0,

            /// <summary>
            /// The Image.
            /// </summary>
            Image = 1,

            /// <summary>
            /// The Shape.
            /// </summary>
            Shape = 2,

            /// <summary>
            /// The Symbol.
            /// </summary>
            Symbol = 3
        }

        #endregion Public Enums

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckOptions"/> class.
        /// </summary>
        /// <param name="box">The rectangle.</param>
        /// <param name="check">The check.</param>
        public CheckOptions(Rectangle box, Rectangle check) : this()
        {
            Box = box;
            Check = check;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        /// Prevents a default instance of the <see cref="CheckOptions"/> class from being created.
        /// </summary>
        private CheckOptions()
        {
            AutoSize = true;
            BoxBorder = new Border();
            CheckBorder = new Border();
            ColorState = new ControlColorState();
            Color = Color.FromArgb(45, 136, 45);
            Box = Rectangle.Empty;
            Check = Rectangle.Empty;
            Image = null;
            Spacing = 2;
            Style = CheckStyle.Check;
            Character = '✔';
            Font = new Font(Control.DefaultFont.FontFamily, 9, FontStyle.Bold);
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether automatic size.
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public bool AutoSize { get; set; }

        /// <summary>
        /// Gets or sets the box.
        /// </summary>
        /// <value>The box.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Rectangle)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Rectangle Box { get; set; }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public Border BoxBorder { get; set; }

        /// <summary>
        /// Gets or sets the character.
        /// </summary>
        /// <value>The character.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public char Character { get; set; }

        /// <summary>
        /// Gets or sets the check.
        /// </summary>
        /// <value>The check.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Rectangle)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Rectangle Check { get; set; }

        /// <summary>
        /// Gets or sets the check border.
        /// </summary>
        /// <value>The check border.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public Border CheckBorder { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the state of the color.
        /// </summary>
        /// <value>The state of the color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public ControlColorState ColorState { get; set; }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        [NotifyParentProperty(true)]
        public Font Font { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [NotifyParentProperty(true)]
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the spacing.
        /// </summary>
        /// <value>The spacing.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Spacing)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int Spacing { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Enum)]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public CheckStyle Style { get; set; }

        #endregion Public Properties
    }
}