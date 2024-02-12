using System;
using System.Data;
using System.Security.Principal;


public class Form1
{
 protected void Method()
 {
// <Snippet1>
UriBuilder uBuild = new UriBuilder("http://www.contoso.com/");
uBuild.Path = "index.htm";
uBuild.Fragment = "main";

Uri myUri = uBuild.Uri;

// </Snippet1>
 }
}
