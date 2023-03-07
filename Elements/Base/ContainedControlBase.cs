using Elements.Enumerators;
using Elements.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Elements.Base
{
    /// <summary>
    /// The <see cref="ContainedControlBase"/> class.
    /// </summary>
    /// <seealso cref="ControlBase"/>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DesignerCategory("code")]
    [ToolboxItem(false)]
    public abstract class ContainedControlBase : ControlBase
    {
        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainedControlBase"/> class.
        /// </summary>
        protected ContainedControlBase()
        {
        }

        #endregion Protected Constructors

        #region Internal Methods

        /// <summary>
        /// Gets the internal control location.
        /// </summary>
        /// <param name="border">The border of the container control.</param>
        /// <returns>The <see cref="Point"/>.</returns>
        internal static Point GetInternalControlLocation(Border border)
        {
            return new Point((border.Rounding / 2) + border.Thickness + 1, (border.Rounding / 2) + border.Thickness + 1);
        }

        /// <summary>
        /// Gets the internal control size.
        /// </summary>
        /// <param name="size">The size of the container control.</param>
        /// <param name="border">The shape of the container control.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        internal static Size GetInternalControlSize(Size size, Border border)
        {
            return new Size(size.Width - border.Rounding - border.Thickness - 3, size.Height - border.Rounding - border.Thickness - 3);
        }

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:Enter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Hover));
        }

        /// <summary>
        /// Raises the <see cref="E:Leave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Normal));
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnMouseStateChanged(this, new Events.MouseStateEventArgs(MouseStates.Normal));
        }

        #endregion Protected Methods
    }
}