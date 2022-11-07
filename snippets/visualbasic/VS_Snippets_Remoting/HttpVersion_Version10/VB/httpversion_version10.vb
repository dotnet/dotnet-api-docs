'System.Net.HttpVersion.Version10
'This program demonstrates the  'Version10' field of the 'HttpVersion' Class.
'The 'Version'  property of 'HttpRequestMessage' class identifies the Version of HTTP being used.
'Then the default value of 'Version' property is displayed to the console.
'The 'Version10' field of the 'HttpVersion' class is assigned to the 'Version' property of the 'HttpRequestMessage' Class.
'The changed Version and the 'Version' of the response object are displayed.
'

Imports System.IO
Imports System.Net
Imports System.Net.Http

Class HttpVersion_Version10
    
    Public Shared Sub Main()
        Try
' <Snippet1>
			' HttpClient lifecycle management best practices:
			' https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
			Using client As New HttpClient()
                Using request As New HttpRequestMessage(HttpMethod.Get, "http://www.microsoft.com")
                    Console.WriteLine("Default HTTP request version is {0}", request.Version)

                    request.Version = HttpVersion.Version10
                    Console.WriteLine("Request version after assignment is {0}", request.Version)

                    Using response As HttpResponseMessage = client.Send(request)
                        Console.WriteLine("Response HTTP version {0}", response.Version)
                    End Using
                End Using
            End Using
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue..............")
            Console.Read()
        Catch e As HttpRequestException
            Console.WriteLine("WebException Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Console.WriteLine("Source  :{0} ", e.Source)
        Catch e As Exception
            Console.WriteLine("Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub
End Class


