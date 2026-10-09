using System.ComponentModel;
using System.Windows.Forms;

public class Form2 : Form
{
    protected TextBox textBox1;
    // <Snippet1>
    [Bindable(BindableSupport.Yes)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int MyProperty
    {
        get =>
            // Insert code here.
            0;
        set
        {
            // Insert code here.
        }
    }
    // </Snippet1>
}
