﻿Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    ' <Snippet1>
    ' Class-level declaration.
    ' Create a TraceSwitch.
    Private Shared generalSwitch As New TraceSwitch("General", "Entire Application")
    
    
    Public Shared Sub MyErrorMethod(category As String)
        ' Write the message if the TraceSwitch level is set to Error or higher.
        If generalSwitch.TraceError Then
            Debug.Write("My error message. ")
        End If 
        ' Write a second message if the TraceSwitch level is set to Verbose.
        If generalSwitch.TraceVerbose Then
            Debug.WriteLine("My second error message.", category)
        End If
    End Sub
    ' </Snippet1>
End Class
