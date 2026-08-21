using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form2 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void MatchesAttributes()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection myCollection;
        myCollection = TypeDescriptor.GetAttributes(button1);

        // Checks to see whether the attributes in myCollection match the attributes for textBox1.
        Attribute[] myAttrArray = new Attribute[100];
        TypeDescriptor.GetAttributes(textBox1).CopyTo(myAttrArray, 0);
        textBox1.Text = myCollection.Matches(myAttrArray) ? "The attributes in the button and text box match." : "The attributes in the button and text box do not match.";
    }
    // </Snippet1>
}
