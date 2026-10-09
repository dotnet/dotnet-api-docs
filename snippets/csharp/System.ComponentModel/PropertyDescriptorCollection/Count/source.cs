using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void GetCount()
    {
        // Creates a new collection and assigns it the properties for button1.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);

        // Prints the number of properties on button1 in a textbox.
        textBox1.Text = $"{properties.Count}";
    }

    // </Snippet1>
}
