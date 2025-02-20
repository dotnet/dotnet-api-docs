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
        AttributeCollection attributes;
        attributes = TypeDescriptor.GetAttributes(button1);

        // Creates an enumerator for the collection.
        var ie = attributes.GetEnumerator();

        // Prints the type of each attribute in the collection.
        object myAttribute;
        while (ie.MoveNext())
        {
            myAttribute = ie.Current;
            textBox1.Text += myAttribute.ToString();
            textBox1.Text += '\n';
        }
    }

    // </Snippet1>
}
