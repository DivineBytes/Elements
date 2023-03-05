using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="DebuggerDisplayFormat"/> class.
    /// </summary>
    /// <seealso cref="System.IComparable"/>
    [ComVisible(true)]
    [DebuggerDisplay(DebuggerDisplay.Default)]
    [Serializable]
    public class DebuggerDisplayFormat : IComparable
    {
        /// <summary>
        /// Specifies the default value for the <see cref="DebuggerDisplayFormat"/>, that represents
        /// the current object. This <see langword="static"/> field is read-only.
        /// </summary>
        public static DebuggerDisplayFormat Default = new DebuggerDisplayFormat(DebuggerText.GroupSpacingSeparator, DebuggerText.ObjectValueSeparator, DebuggerText.Prefix, DebuggerText.Suffix);

        /// <summary>
        /// Gets the empty value for the <see cref="DebuggerDisplayFormat"/>, that represents the
        /// current object. This <see langword="static"/> field is read-only.
        /// </summary>
        public static DebuggerDisplayFormat Empty = new DebuggerDisplayFormat(string.Empty, string.Empty, string.Empty, string.Empty);

        /// <summary>
        /// The <see cref="DebuggerText"/> class.
        /// </summary>
        public class DebuggerText
        {
            /// <summary>
            /// Specifies the default value for the group spacing formatting.
            /// </summary>
            public const string GroupSpacingSeparator = ", ";

            /// <summary>
            /// Specifies the default value for the object value formatting.
            /// </summary>
            public const string ObjectValueSeparator = " = ";

            /// <summary>
            /// Specifies the default value for the prefix formatting.
            /// </summary>
            public const string Prefix = "[";

            /// <summary>
            /// Specifies the default value for the suffix formatting.
            /// </summary>
            public const string Suffix = "]";
        }

        private string groupSpacingSeparator;
        private string objectValueSeparator;
        private string prefix;
        private string suffix;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerDisplayFormat"/> class.
        /// </summary>
        public DebuggerDisplayFormat()
        {
            groupSpacingSeparator = string.Empty;
            objectValueSeparator = string.Empty;
            prefix = string.Empty;
            suffix = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerDisplayFormat"/> class.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        public DebuggerDisplayFormat(string prefix, string suffix) : this(DebuggerText.GroupSpacingSeparator, DebuggerText.ObjectValueSeparator, prefix, suffix)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerDisplayFormat"/> class.
        /// </summary>
        /// <param name="objectValueSeparator">The name Value Separator.</param>
        /// <param name="groupSpacingSeparator">The group Spacing Separator.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        public DebuggerDisplayFormat(string objectValueSeparator, string groupSpacingSeparator, string prefix, string suffix) : this()
        {
            this.objectValueSeparator = objectValueSeparator;
            this.groupSpacingSeparator = groupSpacingSeparator;
            this.prefix = prefix;
            this.suffix = suffix;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get
            {
                if (this == Empty)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets the group spacing formatting.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string GroupSpacingSeparator
        {
            get
            {
                return groupSpacingSeparator;
            }

            set
            {
                groupSpacingSeparator = value;
            }
        }

        /// <summary>
        /// Gets or sets the object value formatting.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ObjectValueSeparator
        {
            get
            {
                return objectValueSeparator;
            }

            set
            {
                objectValueSeparator = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix formatting.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Prefix
        {
            get
            {
                return prefix;
            }

            set
            {
                prefix = value;
            }
        }

        /// <summary>
        /// Gets or sets the suffix formatting.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Suffix
        {
            get
            {
                return suffix;
            }

            set
            {
                suffix = value;
            }
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            if (Equals(obj))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            switch (obj)
            {
                case DebuggerDisplayFormat debuggerDisplayFormat:
                    {
                        bool equal;

                        // Validate the properties
                        if ((debuggerDisplayFormat.GroupSpacingSeparator == GroupSpacingSeparator) &&
                            (debuggerDisplayFormat.ObjectValueSeparator == ObjectValueSeparator) &&
                            (debuggerDisplayFormat.Prefix == Prefix) &&
                            (debuggerDisplayFormat.Suffix == Suffix))
                        {
                            equal = true;
                        }
                        else
                        {
                            equal = false;
                        }

                        return equal;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data
        /// structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
    }
}