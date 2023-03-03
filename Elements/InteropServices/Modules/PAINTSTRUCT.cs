using System;
using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="PAINTSTRUCT"/> class. Contains information to be used to paint the client
    /// area of a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PAINTSTRUCT
    {
        /// <summary>
        /// A handle to the display DC to use for painting.
        /// </summary>
        public IntPtr hdc;

        /// <summary>
        /// Indicates whether the background should be erased.
        /// </summary>
        public bool fErase;

        /// <summary>
        /// A RECT structure that specifies the upper left and lower right corners of the rectangle
        /// in which the painting is requested.
        /// </summary>
        public RECT rcPaint;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool fRestore;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool fIncUpdate;
    }
}