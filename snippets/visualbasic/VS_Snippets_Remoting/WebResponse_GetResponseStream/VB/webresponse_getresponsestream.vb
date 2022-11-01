' System.Net.WebResponse.GetResponseStream.

 ' This program demonstrates the 'GetResponseStream' method of the 'WebResponse' class.
'It creates a web request and queries for a response.
'It then gets the response stream. This response stream is piped to a higher level stream
' reader. The reader reads 256 characters at a time, writes them into a string and then displays the
'string in the console

Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Environment

Class WebResponseSnippet
    
    Public Shared Sub Main(args() As String)
        
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the Url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("WebResponse_GetResponseStream http://www.microsoft.com/net/")
        Else
            GetPage(args(1))
        End If 
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        
        Return
    End Sub
    
    
    Public Shared Sub GetPage(url As [String])
 
	Try
' <Snippet1>

            ' Create a 'WebRequest' object with the specified url 
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")

            ' Send the 'WebRequest' and wait for response.
            Using myWebResponse As WebResponse = myWebRequest.GetResponse()

                ' Call method 'GetResponseStream' to obtain stream associated with the response object
                Dim ReceiveStream As Stream = myWebResponse.GetResponseStream()
                
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")

                ' Pipe the stream to a higher level stream reader with the required encoding format.
                Dim readStream As New StreamReader(ReceiveStream, encode)
                Console.WriteLine(ControlChars.Cr + "Response stream received")
                Dim read(256) As [Char]

                ' Read 256 charcters at a time    .
                Dim count As Integer = readStream.Read(read, 0, 256)
                Console.WriteLine("HTML..." + ControlChars.Lf + ControlChars.Cr)
                While count > 0

                    ' Dump the 256 characters on a string and display the string onto the console.
                    Dim str As New [String](read, 0, count)
                    Console.Write(str)
                    count = readStream.Read(read, 0, 256)

                End While
                Console.WriteLine("")
            End Using
            
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception Raised. The following error occurred : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try

    End Sub
End Class
