Imports System.Net
Imports System.Net.Http

Public Class Sample  
    
    Public Shared Sub Main()
        ' <Snippet1>
        Dim proxyObject As New WebProxy("http://proxyserver:80/", True)

        ' HttpClient lifecycle management best practices:
        ' https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        Dim client As New HttpClient(New HttpClientHandler With
        {
            .Proxy = proxyObject
        })
        ' </Snippet1>
    End Sub
End Class
