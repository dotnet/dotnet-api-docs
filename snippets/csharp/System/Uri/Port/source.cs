using System;




public class Form1
{
    protected void Method()
    {
        // <Snippet1>
        Uri baseUri = new("http://www.contoso.com/");
        Uri myUri = new(baseUri, "catalog/shownew.htm?date=today");

        Console.WriteLine(myUri.Port);

        // </Snippet1>
    }
}
