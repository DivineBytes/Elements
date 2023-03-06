using Elements.Constants;
using Elements.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckOptions" /> class.
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
            BoxBorder = new Border();
            CheckBorder = new Border();
            ColorState = new ControlColorState();
            Color = Color.FromArgb(45, 136, 45);
            Box = Rectangle.Empty;
            Check = Rectangle.Empty;
            Spacing = 2;
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>
        /// The border.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public Border BoxBorder { get; set; }

        /// <summary>
        /// Gets or sets the check border.
        /// </summary>
        /// <value>
        /// The check border.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public Border CheckBorder { get; set; }

        /// <summary>
        /// Gets or sets the state of the color.
        /// </summary>
        /// <value>
        /// The state of the color.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public ControlColorState ColorState { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description("The color.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Color Color { get; set; }


        /// <summary>
        /// Gets or sets the box.
        /// </summary>
        /// <value>
        /// The box.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description("The box.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Rectangle Box { get; set; }

        /// <summary>
        /// Gets or sets the check.
        /// </summary>
        /// <value>
        /// The check.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description("The check.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public Rectangle Check { get; set; }

        /// <summary>
        /// Gets or sets the spacing.
        /// </summary>
        /// <value>
        /// The spacing.
        /// </value>
        [Category(PropertyCategory.Appearance)]
        [Description("The spacing.")]
        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int Spacing { get; set; }

        #endregion Public Properties
    }
}
