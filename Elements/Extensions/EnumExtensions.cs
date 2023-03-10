using System;
using System.ComponentModel;
using System.Reflection;

namespace Elements.Extensions
{
    /// <summary>
    /// The <see cref="EnumExtensions"/> class.
    /// </summary>
    public static class EnumExtensions
    {
        #region Public Methods

        /// <summary>
        /// Gets the enum description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDescription(this Enum value)
        {
            if (value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

                if (fieldInfo != null)
                {
                    if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes)
                    {
                        if (attributes.Length > 0)
                        {
                            return attributes[0].Description;
                        }
                    }

                    return value.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the enum display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDisplayName(this Enum value)
        {
            if (value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

                if (fieldInfo != null)
                {
                    if (fieldInfo.GetCustomAttributes(typeof(Attributes.DisplayNameAttribute), false) is Attributes.DisplayNameAttribute[] attributes)
                    {
                        if (attributes.Length > 0)
                        {
                            return attributes[0].DisplayName;
                        }
                    }

                    return value.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Counts the specified enumerator.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int Count(this Enum enumerator)
        {
            return Enum.GetNames(enumerator.GetType()).Length;
        }

        /// <summary>Gets the <see cref="Enum" /> index by the value.</summary>
        /// <param name="enumerator">The enumerator.</param>
        /// <param name="value">Value to search.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int GetIndexByValue(this Enum enumerator, string value)
        {
            try
            {
                var indexCount = (int)Enum.Parse(enumerator.GetType(), value);
                return indexCount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        /// <summary>Gets the <see cref="Enum" /> value by the index.</summary>
        /// <typeparam name="T">Type parameter.</typeparam>
        /// <param name="enumerator">The enumerator.</param>
        /// <param name="index">The index to search.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string GetValueByIndex<T>(this Enum enumerator, int index) where T : struct
        {
            Type type = typeof(T);
            if (type.IsEnum && Enum.IsDefined(enumerator.GetType(), index))
            {
                return Enum.GetName(enumerator.GetType(), index);
            }
            else
            {
                return null;
            }
        }

        #endregion Public Methods
    }
}