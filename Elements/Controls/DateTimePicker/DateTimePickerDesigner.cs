using Elements.Designer;
using System.Collections;

namespace Elements.Controls.DateTimePicker
{
    internal class DateTimePickerDesigner : ControlDesignerBase
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            //properties.Remove("ImeMode");

            base.PreFilterProperties(properties);
        }
    }
}