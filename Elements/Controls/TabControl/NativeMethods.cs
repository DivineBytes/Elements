#region Namespaces

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace Elements.Controls.TabControl
{
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    //[SecurityPermission(SecurityAction.Assert, Flags=SecurityPermissionFlag.UnmanagedCode)]
    internal static class NativeMethods
    {
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

        #region Windows Constants

        public const int WM_GETTABRECT = 0x130a;

        public const int WS_EX_TRANSPARENT = 0x20;

        public const int WM_SETFONT = 0x30;

        public const int WM_FONTCHANGE = 0x1d;

        public const int WM_HSCROLL = 0x114;

        public const int TCM_HITTEST = 0x130D;

        public const int WM_PAINT = 0xf;

        public const int WS_EX_LAYOUTRTL = 0x400000;

        public const int WS_EX_NOINHERITLAYOUT = 0x100000;

        #endregion

        #region Content Alignment

        public static readonly ContentAlignment AnyRightAlign =
            ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;

        public static readonly ContentAlignment AnyLeftAlign =
            ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft;

        public static readonly ContentAlignment AnyTopAlign =
            ContentAlignment.TopRight | ContentAlignment.TopCenter | ContentAlignment.TopLeft;

        public static readonly ContentAlignment AnyBottomAlign =
            ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;

        public static readonly ContentAlignment AnyMiddleAlign =
            ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;

        public static readonly ContentAlignment AnyCenterAlign =
            ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;

        #endregion

        #region Misc Functions

        public static int LoWord(IntPtr dWord)
        {
            return dWord.ToInt32() & 0xffff;
        }

        public static int HiWord(IntPtr dWord)
        {
            if ((dWord.ToInt32() & 0x80000000) == 0x80000000)
            {
                return dWord.ToInt32() >> 16;
            }

            return (dWord.ToInt32() >> 16) & 0xffff;
        }

        [SuppressMessage("Microsoft.Security", "CA2106:SecureAsserts")]
        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static IntPtr ToIntPtr(object structure)
        {
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
            Marshal.StructureToPtr(structure, lparam, false);
            return lparam;
        }

        #endregion
    }
}