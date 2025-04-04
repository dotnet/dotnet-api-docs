using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected TextBox textBox1;
    protected Button button1;
    // <Snippet1>
    void MyEnumerator()
    {
        // Creates a new collection, and assigns to it the events for button1.
        EventDescriptorCollection events = TypeDescriptor.GetEvents(button1);

        // Creates an enumerator.
        IEnumerator ie = events.GetEnumerator();

        // Prints the name of each event in the collection.
        object myEvent;
        while (ie.MoveNext())
        {
            myEvent = ie.Current;
            textBox1.Text += myEvent.ToString() + '\n';
        }
    }

    // </Snippet1>
}
