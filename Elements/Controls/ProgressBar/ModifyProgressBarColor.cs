using Elements.InteropServices;
using System;

namespace Elements.Controls
{
    /// <summary>
    /// The <see cref="ModifyProgressBarColor"/> class.
    /// </summary>
    public static class ModifyProgressBarColor
    {
        /// <summary>
        /// The <see cref="ProgressBarState"/> enum.
        /// </summary>
        public enum ProgressBarState
        {
            Normal = 1,
            Error = 2,
            Paused = 3
        }

        private const int WM_USER = 0x400;
        private const int PBM_SETSTATE = WM_USER + 16;
        private const int PBM_GETSTATE = WM_USER + 17;

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="progressBar">The progress bar.</param>
        /// <returns>The <see cref="ProgressBarState"/>.</returns>
        public static ProgressBarState GetState(System.Windows.Forms.ProgressBar progressBar)
        {
            return (ProgressBarState)(int)User32.SendMessage(progressBar.Handle, PBM_GETSTATE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="progressBar">The progress bar.</param>
        /// <param name="state">The state.</param>
        public static void SetState(System.Windows.Forms.ProgressBar progressBar, ProgressBarState state)
        {
            User32.SendMessage(progressBar.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);
        }
    }
}