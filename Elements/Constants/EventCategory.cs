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

        public const string Action = DefaultCategory;
        public const string Appearance = DefaultCategory;
        public const string Behavior = DefaultCategory;
        public const string Data = DefaultCategory;
        public const string DragDrop = DefaultCategory;
        public const string Focus = DefaultCategory;
        public const string Key = DefaultCategory;
        public const string Layout = DefaultCategory;
        public const string Misc = DefaultCategory;
        public const string Mouse = DefaultCategory;
        public const string PropertyChanged = DefaultCategory;

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