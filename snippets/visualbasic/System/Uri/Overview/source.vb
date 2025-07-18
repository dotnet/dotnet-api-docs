Imports System.Data
Imports System.Net
Imports System.Net.Http

Public Class Program

    Public Shared Sub Main()
' <Snippet1>
Dim siteUri As New Uri("http://www.contoso.com/")

' HttpClient lifecycle management best practices:
' https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
Dim client As New HttpClient()
Dim request As New HttpRequestMessage(HttpMethod.Get, siteUri)
Dim response As HttpResponseMessage = client.Send(request)

' </Snippet1>
    End Sub
End Class
