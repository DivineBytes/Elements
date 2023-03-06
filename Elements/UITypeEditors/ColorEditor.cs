using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Elements.UITypeEditors
{
    /// <summary>
    /// The <see cref="ColorEditor"/> class.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor"/>
    /// <remarks>Use this on a property: <c>[Editor(typeof(ColorEditor), typeof(UITypeEditor))]</c></remarks>
    public class ColorEditor : UITypeEditor
    {
        #region Public Methods and Operators

        /// <summary>
        /// Edits the value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Color defaultDialogColor = Color.Black;

            if (value != null)
            {
                defaultDialogColor = (Color)value;
            }

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                defaultDialogColor = colorDialog.Color;
            }

            return defaultDialogColor;
        }

        /// <summary>
        /// Gets the edit style.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="UITypeEditorEditStyle"/>.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Gets the paint value supported.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paints the value.
        /// </summary>
        /// <param name="e">
        /// The <see cref="PaintValueEventArgs"/> instance containing the event data.
        /// </param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            Color color = (Color)e.Value;
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        }

        #endregion Public Methods and Operators
    }
}