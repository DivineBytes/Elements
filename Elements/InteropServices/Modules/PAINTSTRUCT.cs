using System;
using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="PAINTSTRUCT"/> class. Contains information to be used to paint the client area of a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PAINTSTRUCT
    {
        /* A handle to the display DC to use for painting. */
        public IntPtr hdc;

        /* Indicates whether the background should be erased. */
        public bool fErase;

        /* A RECT structure that specifies the upper left and lower right 
        corners of the rectangle in which the painting is requested, */
        public RECT rcPaint;

        /* Reserved; used internally by the system. */
        public bool fRestore;

        /* Reserved; used internally by the system. */
        public bool fIncUpdate;
    }
}
