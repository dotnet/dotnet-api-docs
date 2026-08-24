using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void MyEnumerator()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(button1);

        // Creates an enumerator for the collection.
        IEnumerator enumerator = attributes.GetEnumerator();

        // Prints the type of each attribute in the collection.
        while (enumerator.MoveNext())
        {
            textBox1.Text += $"{enumerator.Current}\n";
        }
    }
    // </Snippet1>
}
