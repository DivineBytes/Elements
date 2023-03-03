using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="TEXTMETRIC"/> class. Contains basic information about a physical font. This is the Unicode version of the structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TEXTMETRIC
    {
        /// <summary>
        /// The height (ascent + descent) of characters.
        /// </summary>
        public int tmHeight;

        /// <summary>
        /// The ascent (units above the base line) of characters.
        /// </summary>
        public int tmAscent;

        /// <summary>
        /// The descent (units below the base line) of characters.
        /// </summary>
        public int tmDescent;

        /// <summary>
        /// The amount of leading (space) inside the bounds set by the tmHeight member.
        /// </summary>
        public int tmInternalLeading;

        /// <summary>
        /// The amount of extra leading (space) that the application adds between rows.
        /// </summary>
        public int tmExternalLeading;

        /// <summary>
        /// The average width of characters in the font (generally defined as the width of the letter x).
        /// </summary>
        public int tmAveCharWidth;

        /// <summary>
        /// The width of the widest character in the font.
        /// </summary>
        public int tmMaxCharWidth;

        /// <summary>
        /// The weight of the font. 
        /// </summary>
        public int tmWeight;

        /// <summary>
        /// The extra width per string that may be added to some synthesized fonts.
        /// </summary>
        public int tmOverhang;

        /// <summary>
        /// The horizontal aspect of the device for which the font was designed.
        /// </summary>
        public int tmDigitizedAspectX;

        /// <summary>
        /// The vertical aspect of the device for which the font was designed. 
        /// </summary>
        public int tmDigitizedAspectY;

        /// <summary>
        /// The value of the first character defined in the font.
        /// </summary>
        public char tmFirstChar;

        /// <summary>
        /// The value of the last character defined in the font.
        /// </summary>
        public char tmLastChar;

        /// <summary>
        /// The value of the character to be substituted for characters not in the font.
        /// </summary>
        public char tmDefaultChar;

        /// <summary>
        /// The value of the character that will be used to define word breaks for text justification.
        /// </summary>
        public char tmBreakChar;

        /// <summary>
        /// Specifies an italic font if it is nonzero.
        /// </summary>
        public byte tmItalic;

        /// <summary>
        /// Specifies an underlined font if it is nonzero.
        /// </summary>
        public byte tmUnderlined;

        /// <summary>
        /// A strikeout font if it is nonzero.
        /// </summary>
        public byte tmStruckOut;

        /// <summary>
        /// Specifies information about the pitch, the technology, and the family of a physical font.
        /// </summary>
        public byte tmPitchAndFamily;

        /// <summary>
        ///  The character set of the font.
        /// </summary>
        public byte tmCharSet;
    }
}
