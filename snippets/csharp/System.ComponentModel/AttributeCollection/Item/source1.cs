using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Form2 : Form
{
    protected Button button1;
    protected TextBox textBox1;

    // <Snippet1>
    void PrintIndexItem2()
    {
        // Creates a new collection and assigns it the attributes for button1.
        AttributeCollection attributes;
        attributes = TypeDescriptor.GetAttributes(button1);

        // Gets the designer attribute from the collection.
        DesignerAttribute myDesigner;
        myDesigner = (DesignerAttribute)attributes[typeof(DesignerAttribute)];
        textBox1.Text = myDesigner.DesignerTypeName;
    }
    // </Snippet1>
}
