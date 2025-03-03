using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;

    // <Snippet1>
    void ContainsAttribute()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection attributes;
        attributes = TypeDescriptor.GetAttributes(button1);

        // Sets an Attribute to the specific attribute.
        BrowsableAttribute myAttribute = BrowsableAttribute.Yes;

        textBox1.Text = attributes.Contains(myAttribute) ? "button1 has a browsable attribute." : "button1 does not have a browsable attribute.";
    }
    // </Snippet1>
    // <Snippet2>
    void GetAttributeValue()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection attributes;
        attributes = TypeDescriptor.GetAttributes(button1);

        // Gets the designer attribute from the collection.
        DesignerAttribute myDesigner;
        myDesigner = (DesignerAttribute)attributes[typeof(DesignerAttribute)];

        // Prints the value of the attribute in a text box.
        textBox1.Text = myDesigner.DesignerTypeName;
    }
    // </Snippet2>
}
