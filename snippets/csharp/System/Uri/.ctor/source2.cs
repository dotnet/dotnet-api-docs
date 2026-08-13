using System;
using System.Windows.Forms;

public class UriConstructorForm2 : Form
{
    protected void Method()
    {
        // <Snippet1>
        Uri baseUri = new("http://www.contoso.com");
        Uri myUri = new(baseUri, "catalog/shownew.htm");

        Console.WriteLine(myUri.ToString());

        // </Snippet1>
    }
}
