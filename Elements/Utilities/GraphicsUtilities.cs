using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="GraphicsUtilities"/> class.
    /// </summary>
    public static class GraphicsUtilities
    {
        /// <summary>Flip the size by orientation.</summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="size">Current size.</param>
        /// <returns>The <see cref="Size" />.</returns>
        public static Size FlipOrientationSize(Orientation orientation, Size size)
        {
            Size newSize = new Size(0, 0);

            switch (orientation)
            {
                case Orientation.Horizontal:
                    if (size.Width < size.Height)
                    {
                        newSize = new Size(size.Height, size.Width);
                    }
                    break;
                case Orientation.Vertical:
                    if (size.Width > size.Height)
                    {
                        newSize = new Size(size.Height, size.Width);
                    }
                    break;
            }

            return newSize;
        }

        /// <summary>Retrieves the design mode state.</summary>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool IsDesignMode()
        {
            bool isInDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || Debugger.IsAttached;

            if (isInDesignMode)
            {
                return true;
            }

            using (Process process = Process.GetCurrentProcess())
            {
                return process.ProcessName.ToLowerInvariant().Contains("devenv");
            }
        }
    }
}
