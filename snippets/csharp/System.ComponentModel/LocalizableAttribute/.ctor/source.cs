using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    // <Snippet1>

    [Localizable(true)]
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
