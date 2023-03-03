using System;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="TCHITTESTFLAGS"/> enum.
    /// </summary>
    [Flags]
    public enum TCHITTESTFLAGS
    {
        /// <summary>
        /// The TCHT nowhere
        /// </summary>
        TCHT_NOWHERE = 1,

        /// <summary>
        /// The TCHT onitemicon
        /// </summary>
        TCHT_ONITEMICON = 2,

        /// <summary>
        /// The TCHT onitemlabel
        /// </summary>
        TCHT_ONITEMLABEL = 4,

        /// <summary>
        /// The TCHT onitem
        /// </summary>
        TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
    }
}