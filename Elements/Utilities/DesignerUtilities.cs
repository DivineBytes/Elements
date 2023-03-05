using System.Collections;

namespace Elements.Utilities.Designer
{
    /// <summary>
    /// The <see cref="DesignerUtilities"/> class.
    /// </summary>
    public static class DesignerUtilities
    {
        #region Public Methods

        /// <summary>
        /// Configures the filter.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public static void ConfigureFilter(IDictionary properties)
        {
            if (properties == null)
            {
                return;
            }

            properties.Remove("AutoEllipsis");

            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("ImeMode");

            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");

            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("UseVisualStyleBackColor");

            properties.Remove("RightToLeft");
        }

        #endregion Public Methods
    }
}