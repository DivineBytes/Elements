using Elements.Controls;
using Elements.Controls.ProgressIndicator;
using Elements.Enumerators;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Elements.Utilities
{
    /// <summary>
    /// The <see cref="GraphicsUtilities"/> class.
    /// </summary>
    public static class GraphicsUtilities
    {
        /// <summary>Apply a gradient background image on the control.</summary>
        /// <param name="control">The control.</param>
        /// <param name="size">The size.</param>
        /// <param name="topLeft">The color for top-left.</param>
        /// <param name="topRight">The color for top-right.</param>
        /// <param name="bottomLeft">The color for bottom-left.</param>
        /// <param name="bottomRight">The color for bottom-right.</param>
        public static void AssignGradientBackground(Control control, Size size, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight)
        {
            if (control != null)
            {
                if (control.BackgroundImageLayout != ImageLayout.Stretch)
                {
                    control.BackgroundImageLayout = ImageLayout.Stretch;
                }

                Image _image = ImageUtilities.CreateGradient(size, topLeft, topRight, bottomLeft, bottomRight);
                control.BackgroundImage = _image;
            }
        }

        /// <summary>
        /// Flip the size by orientation.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="size">Current size.</param>
        /// <returns>The <see cref="Size"/>.</returns>
        public static Size FlipOrientationSize(Orientation orientation, Size size)
        {
            Size newSize = new Size(0, 0);

            switch (orientation)
            {
                case Orientation.Horizontal:
                    if (size.Width < size.Height)
                    {
                        newSize = new Size(size.Height, size.Width);
                    }
                    break;

                case Orientation.Vertical:
                    if (size.Width > size.Height)
                    {
                        newSize = new Size(size.Height, size.Width);
                    }
                    break;
            }

            return newSize;
        }

        /// <summary>
        /// Retrieves the design mode state.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsDesignMode()
        {
            bool isInDesignMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime) || Debugger.IsAttached;

            if (isInDesignMode)
            {
                return true;
            }

            using (Process process = Process.GetCurrentProcess())
            {
                return process.ProcessName.ToLowerInvariant().Contains("devenv");
            }
        }

        /// <summary>Draws the rounded rectangle with the specific values.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="rounding">The curve.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(int x, int y, int width, int height, int rounding)
        {
            Rectangle _rectangle = new Rectangle(x, y, width, height);
            GraphicsPath _graphicsPath = DrawRoundedRectangle(_rectangle, rounding);
            return _graphicsPath;
        }

        /// <summary>Draws the rounded rectangle with the specified values.</summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="rounding">The rounding.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(Rectangle rectangle, int rounding)
        {
            GraphicsPath _graphicsPath = new GraphicsPath();
            _graphicsPath.AddArc(rectangle.X, rectangle.Y, rounding, rounding, 180F, 90F);
            _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Y, rounding, rounding, 270F, 90F);
            _graphicsPath.AddArc(rectangle.Width - rounding, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
            _graphicsPath.AddArc(rectangle.X, rectangle.Height - rounding, rounding, rounding, 90F, 90F);
            return _graphicsPath;
        }

        /// <summary>Draws the rounded rectangle with the specified values.</summary>
        /// <param name="rectangle">The Rectangle to fill.</param>
        /// <param name="curve">The Rounding border radius.</param>
        /// <param name="topLeft">The top left of rectangle be round or not.</param>
        /// <param name="topRight">The top right of rectangle be round or not.</param>
        /// <param name="bottomLeft">The bottom left of rectangle be round or not.</param>
        /// <param name="bottomRight">The bottom right of rectangle be round or not.</param>
        /// <returns>The <see cref="GraphicsPath" />.</returns>
        public static GraphicsPath DrawRoundedRectangle(Rectangle rectangle, int curve, bool topLeft = true, bool topRight = true, bool bottomLeft = true, bool bottomRight = true)
        {
            curve = curve * 2;

            GraphicsPath createRoundPath = new GraphicsPath(FillMode.Winding);
            if (!topLeft)
            {
                createRoundPath.AddLine(rectangle.X, rectangle.Y, rectangle.X, rectangle.Y);
            }
            else
            {
                createRoundPath.AddArc(rectangle.X, rectangle.Y, curve, curve, 180f, 90f);
            }

            if (!topRight)
            {
                createRoundPath.AddLine(rectangle.Right - rectangle.Width, rectangle.Y, rectangle.Width, rectangle.Y);
            }
            else
            {
                createRoundPath.AddArc(rectangle.Right - curve, rectangle.Y, curve, curve, 270f, 90f);
            }

            if (!bottomRight)
            {
                createRoundPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
            }
            else
            {
                createRoundPath.AddArc(rectangle.Right - curve, rectangle.Bottom - curve, curve, curve, 0f, 90f);
            }

            if (!bottomLeft)
            {
                createRoundPath.AddLine(rectangle.X, rectangle.Bottom, rectangle.X, rectangle.Bottom);
            }
            else
            {
                createRoundPath.AddArc(rectangle.X, rectangle.Bottom - curve, curve, curve, 90f, 90f);
            }

            createRoundPath.CloseFigure();
            return createRoundPath;
        }

        /// <summary>Apply BackColor change on the container and it's child controls.</summary>
        /// <param name="container">The container control.</param>
        /// <param name="backgroundColor">The container backgroundColor.</param>
        public static void ApplyContainerBackColorChange(Control container, Color backgroundColor)
        {
            if (container == null)
            {
                return;
            }

            foreach (object control in container.Controls)
            {
                if (control != null)
                {
                    ((Control)control).BackColor = backgroundColor;
                }
            }
        }

        /// <summary>Set's the container controls BackColor.</summary>
        /// <param name="control">Current control.</param>
        /// <param name="backgroundColor">Container background color.</param>
        /// <param name="onControlRemoved">Control removed?</param>
        public static void SetControlBackColor(Control control, Color backgroundColor, bool onControlRemoved)
        {
            if (control == null)
            {
                return;
            }

            Color backColor;

            if (onControlRemoved)
            {
                backColor = Color.Transparent;

                // The Control doesn't support transparent background
                if (control is ProgressIndicator)
                {
                    backColor = SystemColors.Control;
                }
            }
            else
            {
                backColor = backgroundColor;
            }

            control.BackColor = backColor;
        }
    }
}