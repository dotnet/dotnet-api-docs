using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void MatchesAttribute()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection attributes;
        attributes = TypeDescriptor.GetAttributes(button1);

        // Checks to see if the browsable attribute is true.
        textBox1.Text = attributes.Matches(BrowsableAttribute.Yes) ? "button1 is browsable." : "button1 is not browsable.";
    }
    // </Snippet1>
}
