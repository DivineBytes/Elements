using Elements.Events;
using System;

namespace Elements.Delegates
{
    /// <summary>
    /// The <see cref="ColorStateChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
    public delegate void ColorStateChangedEventHandler(object source, ColorEventArgs e);

    /// <summary>
    /// The <see cref="ColorChangedEventHandler"/>.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ColorChangedEventHandler(EventArgs e);

    /// <summary>
    /// The <see cref="RoundingChangedEventHandler"/>.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void RoundingChangedEventHandler(EventArgs e);

    /// <summary>
    /// The <see cref="ThicknessChangedEventHandler"/>.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ThicknessChangedEventHandler(EventArgs e);

    /// <summary>
    /// The <see cref="TypeChangedEventHandler"/>.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void TypeChangedEventHandler(EventArgs e);

    /// <summary>
    /// The <see cref="VisibleChangedEventHandler"/>.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void VisibleChangedEventHandler(EventArgs e);

    /// <summary>
    /// The <see cref="MouseStateChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="MouseStateEventArgs"/> instance containing the event data.</param>
    public delegate void MouseStateChangedEventHandler(object source, MouseStateEventArgs e);
}