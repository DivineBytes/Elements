using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="ControlExtensions" /> class.
    /// </summary>
    /// <remarks>Manages the extensibility of the elements.</remarks>
    public static class ControlExtensions
    {
        /// <summary>Scroll down the <see cref="Panel" />.</summary>
        /// <param name="panel">The panel.</param>
        /// <param name="position">The position (should be positive).</param>
        public static void ScrollDown(this Panel panel, int position)
        {
            // position passed in should be positive
            using (Control c = new Control { Parent = panel, Height = 1, Top = panel.ClientSize.Height + position })
            {
                panel.ScrollControlIntoView(c);
            }
        }

        /// <summary>Scroll to the bottom of the <see cref="Panel" />.</summary>
        /// <param name="panel">The panel.</param>
        public static void ScrollToBottom(this Panel panel)
        {
            using (Control c = new Control { Parent = panel, Dock = DockStyle.Bottom })
            {
                panel.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }

        /// <summary>Scroll up the <see cref="Panel" />.</summary>
        /// <param name="panel">The panel.</param>
        /// <param name="position">The position (should be negative).</param>
        public static void ScrollUp(this Panel panel, int position)
        {
            // position passed in should be negative
            using (Control c = new Control { Parent = panel, Height = 1, Top = position })
            {
                panel.ScrollControlIntoView(c);
            }
        }
    }
}