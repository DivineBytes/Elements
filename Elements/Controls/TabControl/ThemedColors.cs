using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Elements.Controls.TabControl
{
    /// <summary>
    /// The <see cref="ThemedColors"/> class.
    /// </summary>
    internal static class ThemedColors
    {
        /// <summary>
        /// </summary>
        public enum ColorScheme
        {
            /// <summary>
            /// The normal color
            /// </summary>
            NormalColor = 0,

            /// <summary>
            /// The home stead
            /// </summary>
            HomeStead = 1,

            /// <summary>
            /// The metallic
            /// </summary>
            Metallic = 2,

            /// <summary>
            /// The no theme
            /// </summary>
            NoTheme = 3
        }

        /// <summary>
        /// Gets the index of the current theme.
        /// </summary>
        /// <returns></returns>
        private static ColorScheme GetCurrentThemeIndex()
        {
            ColorScheme theme = ColorScheme.NoTheme;

            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser &&
                Application.RenderWithVisualStyles)
            {
                switch (VisualStyleInformation.ColorScheme)
                {
                    case NormalColor:
                        theme = ColorScheme.NormalColor;
                        break;

                    case HomeStead:
                        theme = ColorScheme.HomeStead;
                        break;

                    case Metallic:
                        theme = ColorScheme.Metallic;
                        break;

                    default:
                        theme = ColorScheme.NoTheme;
                        break;
                }
            }

            return theme;
        }

        /// <summary>
        /// The normal color
        /// </summary>
        private const string NormalColor = "NormalColor";

        /// <summary>
        /// The home stead
        /// </summary>
        private const string HomeStead = "HomeStead";

        /// <summary>
        /// The metallic
        /// </summary>
        private const string Metallic = "Metallic";

        /// <summary>
        /// The no theme
        /// </summary>
        private const string NoTheme = "NoTheme";

        /// <summary>
        /// The tool border
        /// </summary>
        private static readonly Color[] _toolBorder;

        /// <summary>
        /// Gets the index of the current theme.
        /// </summary>
        /// <value>The index of the current theme.</value>
        public static ColorScheme CurrentThemeIndex => GetCurrentThemeIndex();

        /// <summary>
        /// Gets the tool border.
        /// </summary>
        /// <value>The tool border.</value>
        public static Color ToolBorder
        {
            get
            {
                return _toolBorder[(int)CurrentThemeIndex];
            }
        }

        /// <summary>
        /// Initializes the <see cref="ThemedColors"/> class.
        /// </summary>
        static ThemedColors()
        {
            _toolBorder = new[]
            {
                Color.FromArgb(127, 157, 185),
                Color.FromArgb(164, 185, 127),
                Color.FromArgb(165, 172, 178),
                Color.FromArgb(132, 130, 132)
            };
        }
    }
}