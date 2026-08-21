using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace ExampleControl
{
    //<Snippet1>
    [DesignerSerializerAttribute(typeof(ExampleSerializer), typeof(CodeDomSerializer))]
    public class ExampleControl : UserControl
    {
    }
    //</Snippet1>

    public class ExampleSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
            => null;

        public override object Serialize(IDesignerSerializationManager manager, object value)
            => null;
    }
}