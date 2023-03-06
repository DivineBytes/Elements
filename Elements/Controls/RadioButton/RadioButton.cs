using Elements.Base;
using Elements.Controls.RadialProgress;
using Elements.Events;
using Elements.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Elements.Controls.RadioButton
{
    /// <summary>
    /// The <see cref="RadioButton"/> class.
    /// </summary>
    /// <seealso cref="Elements.Base.ToggleCheckmarkBase" />
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("ToggleChanged")]
    [DefaultProperty("Checked")]
    [Description("The RadioButton")]
    [Designer(typeof(RadioButtonDesigner))]
    [ToolboxBitmap(typeof(RadioButton), "RadioButton.bmp")]
    [ToolboxItem(true)]
    public class RadioButton : ToggleCheckmarkBase
    {
        /// <summary>Initializes a new instance of the <see cref="RadioButton" /> class.</summary>
        public RadioButton()
        {
            Cursor = Cursors.Hand;
            Size = new Size(125, 23);

            CheckOptions.BoxBorder.Rounding = 12;
        }

        /// <summary>
        /// Raises the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            if (!Checked)
            {
                Checked = true;
            }

            base.OnClick(e);
        }

        /// <summary>
        /// Occurs when the ToggleChanged event fires.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected override void OnToggleChanged(object sender, ToggleEventArgs e)
        {
            base.OnToggleChanged(sender, e);
            AutoUpdateOthers();
            Invalidate();
        }

        /// <summary>
        /// Automatics the update others.
        /// </summary>
        private void AutoUpdateOthers()
        {
            // Only un-check others if they are checked
            if (Checked)
            {
                Control parent = Parent;
                if (parent != null)
                {
                    // Search all sibling controls
                    foreach (Control control in parent.Controls)
                    {
                        // If another radio button found, that is not us
                        if ((control != this) && control is RadioButton button)
                        {
                            // Cast to correct type
                            RadioButton radioButton = button;

                            // If target allows auto check changed and is currently checked
                            if (radioButton.Checked)
                            {
                                // Set back to not checked
                                radioButton.Checked = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
