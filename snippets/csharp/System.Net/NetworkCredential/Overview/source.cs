using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
string SecurelyStoredUserName = "";
string SecurelyStoredPassword = "";
string SecurelyStoredDomain = "";
// <Snippet1>
NetworkCredential myCred = new NetworkCredential(
	SecurelyStoredUserName,SecurelyStoredPassword,SecurelyStoredDomain);

CredentialCache myCache = new CredentialCache();

myCache.Add(new Uri("http://www.contoso.com"), "Basic", myCred);
myCache.Add(new Uri("http://app.contoso.com"), "Basic", myCred);

// HttpClient lifecycle management best practices:
// https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
HttpClient client = new HttpClient(new HttpClientHandler
{
	Credentials = myCache
});
// </Snippet1>
 }
}
