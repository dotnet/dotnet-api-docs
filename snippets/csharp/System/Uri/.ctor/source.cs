using System;
using System.Windows.Forms;

public class UriConstructorForm1 : Form
{
    protected void Method()
    {
        // <Snippet1>
        Uri myUri = new("http://www.contoso.com/");

        // </Snippet1>
    }
}
