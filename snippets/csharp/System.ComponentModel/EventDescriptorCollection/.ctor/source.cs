using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected TextBox textBox1;
    protected Button button1;

    protected void Method()
    {
        // <Snippet1>
        _ = TypeDescriptor.GetEvents(button1);
        // </Snippet1>
    }
}
