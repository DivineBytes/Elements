using System.Drawing;
using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="TCHITTESTINFO"/> class.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TCHITTESTINFO
    {
        public TCHITTESTINFO(Point location)
        {
            pt = location;
            flags = TCHITTESTFLAGS.TCHT_ONITEM;
        }

        public Point pt;
        public TCHITTESTFLAGS flags;
    }
}
