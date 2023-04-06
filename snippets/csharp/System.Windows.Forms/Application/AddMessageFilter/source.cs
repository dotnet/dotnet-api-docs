using System;
using System.Windows.Forms;

public class Form1 : Form
{
    protected ListBox textBox1;

    public static void Main(string[] args)
    {
        // Do nothing.
    }
}

// <Snippet1>
// Creates a  message filter.
public class TestMessageFilter : IMessageFilter
{
    public bool PreFilterMessage(ref Message m)
    {
        // Blocks all the messages relating to the left mouse button.
        if (m.Msg >= 513 && m.Msg <= 515)
        {
            Console.WriteLine("Processing the messages : " + m.Msg);
            return true;
        }
        return false;
    }
}

// </Snippet1>
