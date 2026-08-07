using System;
using System.Windows.Forms;

public class Form1 : Form
{
    protected void Method()
    {
        // <Snippet1>
        UriBuilder myUri = new("http", "www.contoso.com");

        // </Snippet1>
    }
}
