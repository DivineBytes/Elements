using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Elements.Utilities
{
    /// <summary>
    ///     The <see cref="ControlUtilities" /> class.
    /// </summary>
    public class ControlUtilities
    {
        /// <summary>Invokes if required the control.</summary>
        /// <param name="control">The control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequired<TControl>(TControl control, MethodInvoker action) where TControl : Control
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), "The control cannot be null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "The action cannot be null.");
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>Invokes if required the 'Tool Strip Menu Item' control.</summary>
        /// <param name="control">The ToolStripMenu item control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequiredToolStrip<TControl>(TControl control, Action<TControl> action) where TControl : ToolStripItem
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), "The tool strip control cannot be null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "The action cannot be null.");
            }

            if (control.GetCurrentParent() != null && control.GetCurrentParent().InvokeRequired)
            {
                control.GetCurrentParent().Invoke(new Action(() => action(control)));
            }
            else
            {
                action(control);
            }
        }

        /// <summary>
        /// Invokes if required.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequired(ISynchronizeInvoke obj, MethodInvoker action)
        {
            if (obj != null && action != null)
            {
                if (obj.InvokeRequired)
                {
                    object[] args = new object[0];
                    obj.Invoke(action, args);
                }
                else
                {
                    action();
                }
            }
        }
    }
}