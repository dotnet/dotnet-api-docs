using System;
using System.Windows.Forms;

public class UriBuilderConstructorForm2 : Form
{
    protected void Method()
    {
        // <Snippet1>
        UriBuilder myUri = new("http", "www.contoso.com", 8080, "index.htm");

        // </Snippet1>
    }
}
