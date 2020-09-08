﻿using System;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1:Form
{
	protected Button button1;
	protected TextBox textBox1;

// <Snippet1>
private void ContainsAttribute() {
    // Creates a new collection and assigns it the attributes for button1.
    AttributeCollection attributes;
    attributes = TypeDescriptor.GetAttributes(button1);

    // Sets an Attribute to the specific attribute.
    BrowsableAttribute myAttribute = BrowsableAttribute.Yes;

    if (attributes.Contains(myAttribute))
       textBox1.Text = "button1 has a browsable attribute.";
    else
       textBox1.Text = "button1 does not have a browsable attribute.";
 }
// </Snippet1>
// <Snippet2>
private void GetAttributeValue() {
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
