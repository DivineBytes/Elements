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
        /// <summary>
        /// Initializes a new instance of the <see cref="TCHITTESTINFO"/> struct.
        /// </summary>
        /// <param name="location">The location.</param>
        public TCHITTESTINFO(Point location)
        {
            pt = location;
            flags = TCHITTESTFLAGS.TCHT_ONITEM;
        }

        /// <summary>
        /// The pt
        /// </summary>
        public Point pt;

        /// <summary>
        /// The flags
        /// </summary>
        public TCHITTESTFLAGS flags;
    }
}
