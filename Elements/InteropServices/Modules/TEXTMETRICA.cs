using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="TEXTMETRICA"/> class. Contains basic information about a physical font. This is the ANSI version of the structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TEXTMETRICA
    {
        /* The height (ascent + descent) of characters. */
        public int tmHeight;

        /* The ascent (units above the base line) of characters. */
        public int tmAscent;

        /* The descent (units below the base line) of characters. */
        public int tmDescent;

        /* The amount of leading (space) inside the bounds set by the tmHeight member. */
        public int tmInternalLeading;

        /* The amount of extra leading (space) that the application adds between rows. */
        public int tmExternalLeading;

        /* The average width of characters in the font (generally defined as the width of the letter x). */
        public int tmAveCharWidth;

        /* The width of the widest character in the font. */
        public int tmMaxCharWidth;

        /* The weight of the font. */
        public int tmWeight;

        /* The extra width per string that may be added to some synthesized fonts. */
        public int tmOverhang;

        /* The horizontal aspect of the device for which the font was designed. */
        public int tmDigitizedAspectX;

        /* The vertical aspect of the device for which the font was designed. */
        public int tmDigitizedAspectY;

        /* The value of the first character defined in the font. */
        public byte tmFirstChar;

        /* The value of the last character defined in the font. */
        public byte tmLastChar;

        /* The value of the character to be substituted for characters not in the font. */
        public byte tmDefaultChar;

        /* The value of the character that will be used to define word breaks for text justification. */
        public byte tmBreakChar;

        /* Specifies an italic font if it is nonzero. */
        public byte tmItalic;

        /* Specifies an underlined font if it is nonzero. */
        public byte tmUnderlined;

        /* A strikeout font if it is nonzero. */
        public byte tmStruckOut;

        /* Specifies information about the pitch, the technology, and the family of a physical font. */
        public byte tmPitchAndFamily;

        /* The character set of the font. */
        public byte tmCharSet;
    }
}
