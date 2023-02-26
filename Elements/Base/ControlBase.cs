using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ControlBase"/> class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control"/>
    /// <seealso cref="System.ICloneable"/>
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract class ControlBase : Control, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlBase"/> class.
        /// </summary>
        protected ControlBase()
        {
            // Allow transparent BackColor.
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Double buffering to reduce drawing flicker.
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Repaint entire control whenever resizing.
            SetStyle(ControlStyles.ResizeRedraw, true);

            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>
        /// Creates a copy of the current object.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}