using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace ArrayEditorExample
{
    public class ArrayEditorTestComponent : Component
    {
        //<Snippet1>
        [Editor(typeof(ArrayEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public object[] componentArray { get; set; }
        //</Snippet1>

        public ArrayEditorTestComponent()
        {
            componentArray = [new Component(), new Component(), this];
        }
    }
}