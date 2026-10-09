using System;




public class Form1
{
    protected void Method()
    {
        // <Snippet1>
        UriBuilder uBuild = new("http://www.contoso.com/")
        {
            Path = "index.htm",
            Fragment = "main"
        };

        Uri myUri = uBuild.Uri;

        // </Snippet1>
    }
}
