using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form2 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void ContainsAttributes()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection myCollection;
        myCollection = TypeDescriptor.GetAttributes(button1);

        // Checks to see whether the attributes in myCollection are the attributes for textBox1.
        Attribute[] myAttrArray = new Attribute[100];
        TypeDescriptor.GetAttributes(textBox1).CopyTo(myAttrArray, 0);
        textBox1.Text = myCollection.Contains(myAttrArray) ? "Both the button and text box have the same attributes." : "The button and the text box do not have the same attributes.";
    }
    // </Snippet1>
}
