using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace Elements.Dialogs
{
    /// <summary>
    /// The <see cref="IconPickerDialog"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.CommonDialog" />
    public class IconPickerDialog : CommonDialog
    {
        /// <summary>
        /// Shes the pick icon dialog.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="pszFilename">The PSZ filename.</param>
        /// <param name="cchFilenameMax">The CCH filename maximum.</param>
        /// <param name="pnIconIndex">Index of the pn icon.</param>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "#62", CharSet = CharSet.Unicode, SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool SHPickIconDialog(IntPtr hWnd, StringBuilder pszFilename, int cchFilenameMax, out int pnIconIndex);

        private const int MAX_PATH = 260;

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [DefaultValue(default(string))]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the index of the icon.
        /// </summary>
        /// <value>
        /// The index of the icon.
        /// </value>
        [DefaultValue(0)]
        public int IconIndex { get; set; }

        /// <summary>
        /// Runs the dialog.
        /// </summary>
        /// <param name="hwndOwner">The HWND owner.</param>
        /// <returns></returns>
        protected override bool RunDialog(IntPtr hwndOwner)
        {
            var buf = new StringBuilder(FileName, MAX_PATH);
            int index;

            bool ok = SHPickIconDialog(hwndOwner, buf, MAX_PATH, out index);
            if (ok)
            {
                FileName = Environment.ExpandEnvironmentVariables(buf.ToString());
                IconIndex = index;
            }

            return ok;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public override void Reset()
        {
            FileName = null;
            IconIndex = 0;
        }
    }
}