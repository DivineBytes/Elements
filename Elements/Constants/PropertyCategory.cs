namespace Elements.Constants
{
    /// <summary>
    /// The <see cref="PropertyCategory" /> class.
    /// </summary>
    /// <seealso cref="CategoryBase" />
#pragma warning disable 1591
    public class PropertyCategory : CategoryBase
    {
#if DEBUG

        public const string Accessibility = DefaultName;
        public const string Appearance = DefaultName;
        public const string Behavior = DefaultName;
        public const string Layout = DefaultName;
        public const string Data = DefaultName;
        public const string Design = DefaultName;
        public const string Focus = DefaultName;
        public const string WindowStyle = DefaultName;

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