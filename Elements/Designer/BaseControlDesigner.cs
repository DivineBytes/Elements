using System.Collections;
using System.Windows.Forms.Design;

namespace Elements.Designer
{
    internal class BaseControlDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("AutoEllipsis");

            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");

            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("ImeMode");

            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");

            properties.Remove("UseCompatibleTextRendering");
            properties.Remove("UseVisualStyleBackColor");

            properties.Remove("RightToLeft");

            properties.Remove("TextImageRelation");

            base.PreFilterProperties(properties);
        }
    }
}