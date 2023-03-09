using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="FontUtilities"/> class.
    /// </summary>
    public static class FontUtilities
    {
        #region Public Fields

        /// <summary>
        /// The default font size.
        /// </summary>
        public const float DefaultFontSize = 12.0F;

        #endregion Public Fields

        #region Public Properties

        /// <summary>
        /// Gets a <see cref="List{T}"/> of all the installed <see cref="FontFamily"/>'s.
        /// </summary>
        /// <returns>The <see cref="FontFamily"/>.</returns>
        public static List<FontFamily> InstalledFonts
        {
            get
            {
                return new InstalledFontCollection().Families.ToList();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Construct a <see cref="Font"/> from <see cref="byte"/>'s.
        /// </summary>
        /// <param name="bytes">The <see cref="Font"/> bytes.</param>
        /// <param name="size">The <see cref="Font"/> size.</param>
        /// <param name="style">The <see cref="Font"/> style.</param>
        /// <param name="unit">The <see cref="Font"/> unit.</param>
        /// <returns>The <see cref="Font"/>.</returns>
        public static Font CreateFont(byte[] bytes, float size = DefaultFontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            if (bytes.Length == 0)
            {
                throw new ArgumentNullException(nameof(bytes), "Cannot be empty.");
            }

            IntPtr _buffer = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, _buffer, bytes.Length);

            using (PrivateFontCollection privateFontCollection = new PrivateFontCollection())
            {
                privateFontCollection.AddMemoryFont(_buffer, bytes.Length);
                return new Font(privateFontCollection.Families[0].Name, size, style, unit);
            }
        }

        /// <summary>
        /// Construct a <see cref="Font"/> from a file path.
        /// </summary>
        /// <param name="path">The <see cref="Font"/> path.</param>
        /// <param name="size">The <see cref="Font"/> size.</param>
        /// <param name="style">The <see cref="Font"/> style.</param>
        /// <param name="unit">The <see cref="Font"/> unit.</param>
        /// <returns>The <see cref="Font"/>.</returns>
        /// <exception cref="ArgumentNullException">nameof(path), Cannot be null or empty.</exception>
        /// <exception cref="FileNotFoundException">The file path cannot be found., path</exception>
        public static Font CreateFont(string path, float size = DefaultFontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "Cannot be null or empty.");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The file path cannot be found.", path);
            }

            byte[] fontBytes = File.ReadAllBytes(path);
            return CreateFont(fontBytes, size, style, unit);
        }

        /// <summary>
        /// Draws the marlett character.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="character">The character.</param>
        /// <param name="color">The color.</param>
        /// <param name="location">The location.</param>
        /// <param name="format">The format.</param>
        /// <param name="size">The size.</param>
        /// <param name="style">The style.</param>
        /// <param name="unit">The unit.</param>
        public static void DrawMarlettCharacter(Graphics graphics, char character, Color color, PointF location, StringFormat format, float size = DefaultFontSize, FontStyle style = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            const string Marlett = "Marlett";

            if (IsFontInstalled(Marlett))
            {
                Font marlettFont = GetFont(Marlett, size, style, unit);
                graphics.DrawString(character.ToString(), marlettFont, new SolidBrush(color), location, format);
            }
        }

        /// <summary>
        /// Gets the <see cref="Font"/>.
        /// </summary>
        /// <param name="familyName">Name of the family.</param>
        /// <param name="emSize">Size of the em.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="graphicsUnit">The graphics unit.</param>
        /// <returns>The <see cref="Font"/>.</returns>
        public static Font GetFont(string familyName, float emSize = 12, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit graphicsUnit = GraphicsUnit.Pixel)
        {
            if (string.IsNullOrEmpty(familyName))
            {
                throw new ArgumentNullException(nameof(familyName), "Cannot be null or empty.");
            }

            return new Font(familyName, emSize, fontStyle, graphicsUnit);
        }
        /// <summary>
        /// Determines whether the <see cref="Font"/> is installed on the system.
        /// </summary>
        /// <param name="familyName">The font name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsFontInstalled(string familyName)
        {
            if (string.IsNullOrEmpty(familyName))
            {
                throw new ArgumentNullException(nameof(familyName), "Cannot be null or empty.");
            }

            return InstalledFonts.Any(_fontFamily => _fontFamily.Name == familyName);
        }

        #endregion Public Methods
    }
}