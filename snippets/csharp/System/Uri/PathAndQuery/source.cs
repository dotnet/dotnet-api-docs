using System;
using System.Data;
using System.Security.Principal;


public class Form1
{
    protected void Method()
    {
        // <Snippet1>
        Uri baseUri = new Uri("http://www.contoso.com/");
        Uri myUri = new Uri(baseUri, "catalog/shownew.htm?date=today");

        Console.WriteLine(myUri.PathAndQuery);
        // </Snippet1>
    }

    public void Method2()
    {

        // <Snippet2>
        Uri baseUri = new Uri ("http://www.contoso.com/");
        Uri myUri = new Uri (baseUri, "catalog/shownew.htm?date=today");

        Console.WriteLine (myUri.Query);
        // </Snippet2>
    }
}