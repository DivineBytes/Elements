using Elements.Designer;
using Elements.InteropServices;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace Elements.Controls.ProgressBar
{
    internal class ProgressBarDesigner : BaseControlDesigner
    {
        /// <summary>
        /// Gets a list of System.Windows.Forms.Design.Behavior.SnapLine objects, representing alignment points for the edited control.
        /// </summary>
        /// <value>
        /// The snap lines.
        /// </value>
        public override IList SnapLines
        {
            get
            {
                // Get the SnapLines collection from the base class
                ArrayList snapList = base.SnapLines as ArrayList;

                // Calculate the Baseline for the Font used by the Control and add it to the SnapLines
                int textBaseline = GetBaseline(base.Control, ContentAlignment.MiddleCenter);
                if (textBaseline > 0)
                {
                    snapList.Add(new SnapLine(SnapLineType.Baseline, textBaseline, SnapLinePriority.Medium));
                }

                return snapList;
            }
        }

        /// <summary>
        /// Gets the baseline.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="alignment">The alignment.</param>
        /// <returns>The <see cref="int"/>.</returns>
        private static int GetBaseline(Control ctrl, ContentAlignment alignment)
        {
            int textAscent = 0;
            int textHeight = 0;

            // Retrieve the ClientRect of the Control
            Rectangle clientRect = ctrl.ClientRectangle;

            // Create a Graphics object for the Control
            using (Graphics graphics = ctrl.CreateGraphics())
            {
                // Retrieve the device context Handle
                IntPtr hDC = graphics.GetHdc();

                // Create a wrapper for the Font of the Control
                Font controlFont = ctrl.Font;
                HandleRef tempFontHandle = new HandleRef(controlFont, controlFont.ToHfont());

                try
                {
                    // Create a wrapper for the device context
                    HandleRef deviceContextHandle = new HandleRef(ctrl, hDC);

                    // Select the Font into the device context
                    IntPtr originalFont = GDI32.SelectObject(deviceContextHandle, tempFontHandle);

                    // Create a TEXTMETRIC and calculate metrics for the selected Font
                    TEXTMETRIC tEXTMETRIC = new TEXTMETRIC();
                    if (GDI32.GetTextMetrics(deviceContextHandle, ref tEXTMETRIC) != 0)
                    {
                        textAscent = tEXTMETRIC.tmAscent + 1;
                        textHeight = tEXTMETRIC.tmHeight;
                    }

                    // Restore original Font
                    HandleRef originalFontHandle = new HandleRef(ctrl, originalFont);
                    GDI32.SelectObject(deviceContextHandle, originalFontHandle);
                }
                finally
                {
                    // Cleanup tempFont
                    GDI32.DeleteObject(tempFontHandle);

                    // Release device context
                    graphics.ReleaseHdc(hDC);
                }
            }

            // Calculate return value based on the specified alignment; first check top alignment
            if ((alignment & (ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight)) != 0)
            {
                return clientRect.Top + textAscent;
            }

            // Check middle alignment
            if ((alignment &
                 (ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight)) == 0)
            {
                return clientRect.Bottom - textHeight + textAscent;
            }

            // Assume bottom alignment
            return (int)Math.Round(clientRect.Top + (double)clientRect.Height / 2 - (double)textHeight / 2 + textAscent);
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            // properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }
    }
}