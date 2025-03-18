Imports System.Net
Imports System.Net.Http

Public Class Sample
        
    Public Shared Sub Main()
dim SecurelyStoredUserName as String = ""
dim SecurelyStoredPassword as String = ""
dim SecurelyStoredDomain as String = ""
        
' <Snippet1>
Dim myCred As New NetworkCredential(SecurelyStoredUserName, SecurelyStoredPassword, SecurelyStoredDomain)

Dim myCache As New CredentialCache()

myCache.Add(New Uri("http://www.contoso.com"), "Basic", myCred)
myCache.Add(New Uri("http://app.contoso.com"), "Basic", myCred)
       
' HttpClient lifecycle management best practices:
' https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
Dim client As New HttpClient(New HttpClientHandler With
{
    .Credentials = myCache
})
' </Snippet1>
    End Sub
End Class
