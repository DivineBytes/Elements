using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements.Constants
{
    /// <summary>
    ///     The <see cref="PropertyCategory" /> class.
    /// </summary>
    public class PropertyCategory
    {

#if DEBUG

        public const string Accessibility = Defaults.DefaultCategory;
        public const string Appearance = Defaults.DefaultCategory;
        public const string Behavior = Defaults.DefaultCategory;
        public const string Layout = Defaults.DefaultCategory;
        public const string Data = Defaults.DefaultCategory;
        public const string Design = Defaults.DefaultCategory;
        public const string Focus = Defaults.DefaultCategory;
        public const string WindowStyle = Defaults.DefaultCategory;

#else

        public const string Accessibility = "Accessibility";
        public const string Appearance = "Appearance";
        public const string Behavior = "Behavior";
        public const string Layout = "Layout";
        public const string Data = "Data";
        public const string Design = "Design";
        public const string Focus = "Focus";
        public const string WindowStyle = "Window style";

#endif

    }
}
