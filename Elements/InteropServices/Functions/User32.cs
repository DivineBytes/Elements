using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Elements.InteropServices
{
    /// <summary>The <see cref="User32" /> interoperability enables you to invoke unmanaged code.</summary>
    /// <remarks>
    ///     <para>Description: Multi-User Windows USER API Client DLL.</para>
    ///     <para>Entry point: <c>User32.dll</c></para>
    /// </remarks>
    [SuppressUnmanagedCodeSecurity]
    public static class User32
    {
        /// <summary>
        ///     Prepares the specified window for painting and fills a PAINTSTRUCT structure with information about the painting
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpPaint">The lp paint.</param>
        /// <returns>The <see cref="IntPtr" />.</returns>
        [DllImport(ExternalDLL.User32, CharSet = CharSet.Auto, ExactSpelling = false)]
        public static extern IntPtr BeginPaint(HandleRef hWnd, [In][Out] ref PAINTSTRUCT lpPaint);

        /// <summary>
        ///     Marks the end of painting in the specified window. This function is required for each call to the BeginPaint
        ///     function, but only after painting is complete.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpPaint">The lp paint.</param>
        /// <returns>The <see cref="bool" />.</returns>
        [DllImport(ExternalDLL.User32, CharSet = CharSet.Auto, ExactSpelling = false)]
        public static extern bool EndPaint(HandleRef hWnd, ref PAINTSTRUCT lpPaint);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="w">The w.</param>
        /// <param name="l">The l.</param>
        /// <returns>The <see cref="IntPtr"/>.</returns>
        [DllImport(ExternalDLL.User32, CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
    }
}