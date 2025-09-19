using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;

    protected void Method() =>
        // <Snippet1>
        _ = TypeDescriptor.GetAttributes(button1);
    // </Snippet1>
}
