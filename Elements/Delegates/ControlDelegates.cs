using Elements.Events;
using System;

namespace Elements.Delegates
{
    /// <summary>
    /// The <see cref="ColorChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ColorChangedEventHandler(object source, EventArgs e);

    /// <summary>
    /// The <see cref="ColorStateChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="ColorEventArgs"/> instance containing the event data.</param>
    public delegate void ColorStateChangedEventHandler(object source, ColorEventArgs e);
    /// <summary>
    /// The <see cref="ControlBoxEventHandler" />.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ControlBoxEventArgs" /> instance containing the event data.</param>
    public delegate void ControlBoxEventHandler(object sender, ControlBoxEventArgs e);

    /// <summary>
    /// The <see cref="MouseStateChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="MouseStateEventArgs"/> instance containing the event data.</param>
    public delegate void MouseStateChangedEventHandler(object source, MouseStateEventArgs e);

    /// <summary>
    /// The <see cref="RoundingChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void RoundingChangedEventHandler(object source, EventArgs e);

    /// <summary>
    /// The <see cref="ShapeChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ShapeChangedEventHandler(object source, EventArgs e);

    /// <summary>
    /// The <see cref="ThicknessChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ThicknessChangedEventHandler(object source, EventArgs e);

    /// <summary>
    /// The <see cref="ToggleChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="ToggleEventArgs"/> instance containing the event data.</param>
    public delegate void ToggleChangedEventHandler(object source, ToggleEventArgs e);

    /// <summary>
    /// The <see cref="TypeChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void TypeChangedEventHandler(object source, EventArgs e);
    /// <summary>
    /// The <see cref="ValueChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="ValueChangedEventArgs"/> instance containing the event data.</param>
    public delegate void ValueChangedEventHandler(object source, ValueChangedEventArgs e);

    /// <summary>
    /// The <see cref="VisibleChangedEventHandler"/>.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void VisibleChangedEventHandler(object source, EventArgs e);
}