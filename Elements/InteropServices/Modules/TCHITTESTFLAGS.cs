using System;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="TCHITTESTFLAGS"/> enum.
    /// </summary>
    [Flags]
    public enum TCHITTESTFLAGS
    {
        TCHT_NOWHERE = 1,
        TCHT_ONITEMICON = 2,
        TCHT_ONITEMLABEL = 4,
        TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
    }
}
