namespace Elements.Constants
{
    /// <summary>
    /// The <see cref="PropertyCategory" /> class.
    /// </summary>
    /// <seealso cref="Elements.Constants.CategoryBase" />
#pragma warning disable 1591
    public class PropertyCategory : CategoryBase
    {
#if DEBUG

        public const string Accessibility = DefaultCategory;
        public const string Appearance = DefaultCategory;
        public const string Behavior = DefaultCategory;
        public const string Layout = DefaultCategory;
        public const string Data = DefaultCategory;
        public const string Design = DefaultCategory;
        public const string Focus = DefaultCategory;
        public const string WindowStyle = DefaultCategory;

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