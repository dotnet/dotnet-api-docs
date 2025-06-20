' <Snippet1>

Imports System.Collections.Specialized
Imports System.Web

Public Class Sample
    Public Shared Sub Main()
        ' Parse the URL and get the query string
        Dim url As String = "https://www.microsoft.com?name=John&age=30&location=USA"
        Dim parsedUrl As String = url.Split("?")(1)

        ' The ParseQueryString method will parse the query string and return a NameValueCollection
        Dim paramsCollection As NameValueCollection = HttpUtility.ParseQueryString(parsedUrl)

        ' The For Each loop will iterate over the params collection and print the key and value for each param
        For Each key As String In paramsCollection.AllKeys
            Console.WriteLine($"Key: {key} => Value: {paramsCollection(key)}")
        Next
    End Sub
End Class

' The example displays the following output:
' Key: name => Value: John
' Key: age => Value: 30
' Key: location => Value: USA

' </Snippet1>