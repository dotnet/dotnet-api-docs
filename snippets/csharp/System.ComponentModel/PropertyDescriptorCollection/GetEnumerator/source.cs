﻿using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1 : Form
{
    protected Button button1;
    protected TextBox textBox1;
    // <Snippet1>
    void MyEnumerator()
    {
        // Creates a new collection and assigns it the properties for button1.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(button1);

        // Creates an enumerator.
        IEnumerator ie = properties.GetEnumerator();

        // Prints the name of each property in the collection.
        object myProperty;
        while (ie.MoveNext())
        {
            myProperty = ie.Current;
            textBox1.Text += myProperty.ToString() + '\n';
        }
    }

    // </Snippet1>
}
