using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements.Models
{
    /// <summary>
    /// The <see cref="DebuggerDisplay"/> class.
    /// </summary>
    /// <remarks>Serializes <see cref="object" /> for the <c>ToDebug</c> attribute.</remarks>
    public static class DebuggerDisplay
    {
        /// <summary>Determines how a class or field is displayed in the debugger variable windows.</summary>
        public const string DefaultDebuggerDisplay = "{ToString(),nq}";

        /// <summary>Serializes the target to a more read able string for debugging.</summary>
        /// <param name="target">The target instance.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Serialize(object target, string propertyName)
        {
            return Serialize(target, propertyName, DebuggerDisplayFormat.Default);
        }

        /// <summary>Serializes the target to a more read able string for debugging.</summary>
        /// <param name="target">The target instance.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="format">The formatting display.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Serialize(object target, string propertyName, DebuggerDisplayFormat format)
        {
            // Load property value
            object valueResult = target.GetType().GetProperty(propertyName)?.GetValue(target, null);

            // Output data is null
            string valueData = Convert.ToString(valueResult);
            if (string.IsNullOrEmpty(valueData))
            {
                valueData = "null";
            }

            // Initialize defaults
            var targetID = new KeyValuePair<string, string>("Type", target.GetType().Name);
            var propertyNamePair = new KeyValuePair<string, string>("Name", propertyName);
            var propertyValuePair = new KeyValuePair<string, string>("Value", valueData);

            // Format types to string
            string objectFormat = GenerateID(targetID, format.ObjectValueSeparator);
            string propertyFormat = GenerateID(propertyNamePair, format.ObjectValueSeparator);
            string propertyValueFormat = GenerateID(propertyValuePair, format.ObjectValueSeparator);

            return string.Format("{0}{3}{2}{4}{2}{5}{1}", format.Prefix, format.Suffix, format.GroupSpacingSeparator, objectFormat, propertyFormat, propertyValueFormat);
        }

        /// <summary>Returns a string that represents the current object for debug details.</summary>
        /// <param name="target">The target instance.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string ToDebug(this object target, string propertyName)
        {
            return Serialize(target, propertyName);
        }

        /// <summary>Generate a single identification output with its value pair.</summary>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <param name="separatorFormat">The separator format.</param>
        /// <returns>The <see cref="string" />.</returns>
        private static string GenerateID(KeyValuePair<string, string> keyValuePair, string separatorFormat)
        {
            return string.Format("{1}{0}{2}", separatorFormat, keyValuePair.Key, keyValuePair.Value);
        }
    }
}
