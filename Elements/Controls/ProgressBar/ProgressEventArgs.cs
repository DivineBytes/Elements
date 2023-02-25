using System;

namespace Elements.Controls.ProgressBar
{
    /// <summary>
    /// The <see cref="ProgressEventArgs"/> class.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class ProgressEventArgs : EventArgs
    {
        /// <summary>
        /// The empty <see cref="ProgressEventArgs" />.
        /// </summary>
        public static new readonly ProgressEventArgs Empty = new ProgressEventArgs();

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public object Object { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressEventArgs"/> class.
        /// </summary>
        public ProgressEventArgs()
        {
            Object = null;
            Value = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressEventArgs" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="obj">The object.</param>
        public ProgressEventArgs(int value, object obj) : this()
        {
            Object = obj;
            Value = value;
        }
    }
}