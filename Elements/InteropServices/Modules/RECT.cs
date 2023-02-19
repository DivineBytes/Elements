using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Elements.InteropServices
{
    /// <summary>
    /// The <see cref="RECT"/> struct.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// The rect side.
        /// </summary>
        public int Left, Top, Right, Bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> struct.
        /// </summary>
        /// <param name="r">The r.</param>
        public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
        {
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X
        {
            get
            {
                return Left;
            }

            set
            {
                Right -= Left - value;
                Left = value;
            }
        }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y
        {
            get
            {
                return Top;
            }

            set
            {
                Bottom -= Top - value;
                Top = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get
            {
                return Bottom - Top;
            }

            set
            {
                Bottom = value + Top;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get
            {
                return Right - Left;
            }

            set
            {
                Right = value + Left;
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Point Location
        {
            get
            {
                return new Point(Left, Top);
            }

            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }

            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="RECT"/> to <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Rectangle(RECT r)
        {
            return new Rectangle(r.Left, r.Top, r.Width, r.Height);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="RECT"/>.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator RECT(Rectangle r)
        {
            return new RECT(r);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="r1">The r1.</param>
        /// <param name="r2">The r2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(RECT r1, RECT r2)
        {
            return r1.Equals(r2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="r1">The r1.</param>
        /// <param name="r2">The r2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(RECT r1, RECT r2)
        {
            return !r1.Equals(r2);
        }

        /// <summary>
        /// Equalses the specified r.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public bool Equals(RECT r)
        {
            return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is RECT rECT)
            {
                return Equals(rECT);
            }

            if (obj is Rectangle rectangle)
            {
                return Equals(new RECT(rectangle));
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return ((Rectangle) this).GetHashCode();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
        }

        /// <summary>
        /// Froms the xywh.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x, y, x + width, y + height);
        }

        /// <summary>
        /// Froms the int PTR.
        /// </summary>
        /// <param name="ptr">The PTR.</param>
        /// <returns></returns>
        public static RECT FromIntPtr(IntPtr ptr)
        {
            RECT rect = (RECT)Marshal.PtrToStructure(ptr, typeof(RECT));
            return rect;
        }

    }
}