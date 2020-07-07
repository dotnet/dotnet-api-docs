﻿' System.Net.WebClient.UploadFile(String,String)

'This program demonstrates the 'UploadFile(String,String)' method of "WebClient" class.
'It accepts an Uri and the path of a file to be uploaded to the Uri. This file is uploaded to the Uri 
'provided as input using the 'UploadFile(String,String)' method. The custom made site responds back 
'with whatever was posted to it. Thus the contents of the file are displayed to the console.
'
'Note : The results described were obtained using a custom made site. This behavior may not be the
'same with all other sites. Also certain sites would not accept "Post" method thereby leading to 
'an error. It is advisable to construct a site using files accompanying this and provide
'url name of this site to the program.
'

Imports System.Net
Imports System.Text

Public Class WebClient_UpLoadFile
    
    Public Shared Sub Main()
        Try
' <Snippet1>						

            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            Console.WriteLine(ControlChars.Cr & _
                "Please enter the fully qualified path of the file to be uploaded to the URI")

            Dim fileName As String = Console.ReadLine()
            Console.WriteLine("Uploading {0} to {1} ...", fileName, uriString)

            ' Upload the file to the URI.
            ' The 'UploadFile(uriString,fileName)' method implicitly uses HTTP POST method. 
            Dim responseArray As Byte() = myWebClient.UploadFile(uriString, fileName)

            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr & "Response Received. The contents of the file uploaded are: " & _
                ControlChars.Cr & "{0}", System.Text.Encoding.ASCII.GetString(responseArray))

' </Snippet1>
        Catch e As WebException
            Console.WriteLine(("The following exception was raised: " & e.Message))
        Catch e As Exception
            Console.WriteLine(("The following exception was raised: " & e.Message))
        End Try
    End Sub
End Class
