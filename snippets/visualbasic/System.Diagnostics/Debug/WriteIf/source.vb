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
    
    
    Public Shared Sub MyErrorMethod()
        ' Write the message if the TraceSwitch level is set to Error or higher.
        Debug.WriteIf(generalSwitch.TraceError, "My error message. ")
        
        ' Write a second message if the TraceSwitch level is set to Verbose.
        Debug.WriteIf(generalSwitch.TraceVerbose, "My second error message.")
    End Sub
    ' </Snippet1>
End Class

