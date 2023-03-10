namespace Elements.Constants
{
    /// <summary>
    /// The <see cref="EventCategory" /> class.
    /// </summary>
    /// <seealso cref="CategoryBase" />
#pragma warning disable 1591

    public class EventCategory : CategoryBase
    {
#if DEBUG

        public const string Action = DefaultName;
        public const string Appearance = DefaultName;
        public const string Behavior = DefaultName;
        public const string Data = DefaultName;
        public const string DragDrop = DefaultName;
        public const string Focus = DefaultName;
        public const string Key = DefaultName;
        public const string Layout = DefaultName;
        public const string Misc = DefaultName;
        public const string Mouse = DefaultName;
        public const string PropertyChanged = DefaultName;

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