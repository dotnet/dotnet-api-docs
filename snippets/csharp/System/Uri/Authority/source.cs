using System;




public class Form1
{
    protected void Method()
    {
        // <Snippet1>
        Uri baseUri = new("http://www.contoso.com:8080/");
        Uri myUri = new(baseUri, "shownew.htm?date=today");

        Console.WriteLine(myUri.Authority);

        // </Snippet1>
    }
}
