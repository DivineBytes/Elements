using System;
using System.ComponentModel;
using System.Globalization;

namespace Elements.Controls.Label
{
    /// <summary>
    /// The <see cref="LabelReflectionTypeConverter"/> class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter"/>
    public class LabelReflectionTypeConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Can convert context from source type.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="sourceType">The source type.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Sets the property to read only.
            return false;
        }

        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "Reflection Settings";
        }
    }
}