﻿' <Snippet1>
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        Try
            If File.Exists(path) Then
                File.Delete(path)
            End If

            Dim sw As StreamWriter = New StreamWriter(path)
            sw.WriteLine("This")
            sw.WriteLine("is some text")
            sw.WriteLine("to test")
            sw.WriteLine("Reading")
            sw.Close()

            Dim sr As StreamReader = New StreamReader(path)

            Do While sr.Peek() > -1
                Console.WriteLine(sr.ReadLine())
            Loop
            sr.Close()
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
