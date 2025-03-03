using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    // <Snippet1>

    [MergableProperty(true)]
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
