using System;
using System.Data;
using System.Security.Principal;


public class Form1
{
 protected void Method()
 {
// <Snippet1>
Console.WriteLine(Uri.CheckHostName("www.contoso.com"));

// </Snippet1>
 }
}
