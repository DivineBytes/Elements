using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elements.Constants
{
    /// <summary>
    ///     The <see cref="EventCategory" /> class.
    /// </summary>
    public class EventCategory
    {

#if DEBUG

        public const string Action = Defaults.DefaultCategory;
        public const string Appearance = Defaults.DefaultCategory;
        public const string Behavior = Defaults.DefaultCategory;
        public const string Data = Defaults.DefaultCategory;
        public const string DragDrop = Defaults.DefaultCategory;
        public const string Focus = Defaults.DefaultCategory;
        public const string Key = Defaults.DefaultCategory;
        public const string Layout = Defaults.DefaultCategory;
        public const string Misc = Defaults.DefaultCategory;
        public const string Mouse = Defaults.DefaultCategory;
        public const string PropertyChanged = Defaults.DefaultCategory;

#else

        public const string Action = "Action";
        public const string Appearance = "Appearance";
        public const string Behavior = "Behavior";
        public const string Data = "Data";
        public const string DragDrop = "Drag Drop";
        public const string Focus = "Focus";
        public const string Key = "Key";
        public const string Layout = "Layout";
        public const string Misc = "Misc";
        public const string Mouse = "Mouse";
        public const string PropertyChanged = "Property Changed";

#endif

    }
}
