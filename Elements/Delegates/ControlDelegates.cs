using Elements.Events;

namespace Elements.Delegates
{
    /// <summary>
    /// The <see cref="ControlDelegates"/> class.
    /// </summary>
    public class ControlDelegates
    {
        /// <summary>
        /// The <see cref="BackColorStateChangedEventHandler"/>.
        /// </summary>
        /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
        public delegate void BackColorStateChangedEventHandler(ColorEventArgs e);
    }
}