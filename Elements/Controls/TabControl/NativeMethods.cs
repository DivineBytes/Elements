using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Controls.TabControl
{
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    //[SecurityPermission(SecurityAction.Assert, Flags=SecurityPermissionFlag.UnmanagedCode)]
    internal static class NativeMethods
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        public static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            // This Method replaces the User32 method SendMessage, but will only work for sending
            // messages to Managed controls.
            Control control = Control.FromHandle(hWnd);
            if (control == null)
            {
                return IntPtr.Zero;
            }

            Message message = new Message();
            message.HWnd = hWnd;
            message.LParam = lParam;
            message.WParam = wParam;
            message.Msg = msg;

            MethodInfo wproc = control.GetType().GetMethod("WndProc"
                , BindingFlags.NonPublic
                  | BindingFlags.InvokeMethod
                  | BindingFlags.FlattenHierarchy
                  | BindingFlags.IgnoreCase
                  | BindingFlags.Instance);

            object[] args = { message };
            wproc.Invoke(control, args);

            return ((Message)args[0]).Result;
        }

        /// <summary>
        /// The wm gettabrect
        /// </summary>
        public const int WM_GETTABRECT = 0x130a;

        /// <summary>
        /// The ws ex transparent
        /// </summary>
        public const int WS_EX_TRANSPARENT = 0x20;

        /// <summary>
        /// The wm setfont
        /// </summary>
        public const int WM_SETFONT = 0x30;

        /// <summary>
        /// The wm fontchange
        /// </summary>
        public const int WM_FONTCHANGE = 0x1d;

        /// <summary>
        /// The wm hscroll
        /// </summary>
        public const int WM_HSCROLL = 0x114;

        /// <summary>
        /// The TCM hittest
        /// </summary>
        public const int TCM_HITTEST = 0x130D;

        /// <summary>
        /// The wm paint
        /// </summary>
        public const int WM_PAINT = 0xf;

        /// <summary>
        /// The ws ex layoutrtl
        /// </summary>
        public const int WS_EX_LAYOUTRTL = 0x400000;

        /// <summary>
        /// The ws ex noinheritlayout
        /// </summary>
        public const int WS_EX_NOINHERITLAYOUT = 0x100000;

        /// <summary>
        /// Any right align
        /// </summary>
        public static readonly ContentAlignment AnyRightAlign =
            ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;

        /// <summary>
        /// Any left align
        /// </summary>
        public static readonly ContentAlignment AnyLeftAlign =
            ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft;

        /// <summary>
        /// Any top align
        /// </summary>
        public static readonly ContentAlignment AnyTopAlign =
            ContentAlignment.TopRight | ContentAlignment.TopCenter | ContentAlignment.TopLeft;

        /// <summary>
        /// Any bottom align
        /// </summary>
        public static readonly ContentAlignment AnyBottomAlign =
            ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;

        /// <summary>
        /// Any middle align
        /// </summary>
        public static readonly ContentAlignment AnyMiddleAlign =
            ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;

        /// <summary>
        /// Any center align
        /// </summary>
        public static readonly ContentAlignment AnyCenterAlign =
            ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="dWord">The d word.</param>
        /// <returns></returns>
        public static int LoWord(IntPtr dWord)
        {
            return dWord.ToInt32() & 0xffff;
        }

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="dWord">The d word.</param>
        /// <returns></returns>
        public static int HiWord(IntPtr dWord)
        {
            if ((dWord.ToInt32() & 0x80000000) == 0x80000000)
            {
                return dWord.ToInt32() >> 16;
            }

            return (dWord.ToInt32() >> 16) & 0xffff;
        }

        /// <summary>
        /// Converts to intptr.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Security", "CA2106:SecureAsserts")]
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static IntPtr ToIntPtr(object structure)
        {
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
            Marshal.StructureToPtr(structure, lparam, false);
            return lparam;
        }
    }
}