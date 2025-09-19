﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "Dim values() As Integer = { 1, 2, 3 }" & vbCrLf & _
                            "For ctr As Integer = values.GetLowerBound(1) To values.GetUpperBound(1)" & vbCrLf & _
                            "   Console.Write(values(ctr))" & vbCrLf & _
                            "   If ctr < values.GetUpperBound(1) Then Console.Write("", "")" & vbCrLf & _
                            "Next" & vbCrLf & _
                            "Console.WriteLine()"   
      Dim pattern As String = "Console\.Write(Line)?"
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      For Each match As Match In matches
         Console.WriteLine("'{0}' found in the source code at position {1}.", _ 
                           match.Value, match.Index)       
      Next                            
   End Sub
End Module
' The example displays the following output:
'    'Console.Write' found in the source code at position 115.
'    'Console.Write' found in the source code at position 184.
'    'Console.WriteLine' found in the source code at position 211.
' </Snippet2>

Friend Class Test
   Public Sub Code()
      Dim values() As Integer = { 1, 2, 3 }
      For ctr As Integer = values.GetLowerBound(1) To values.GetUpperBound(1)
         Console.Write(values(ctr))
         If ctr < values.GetUpperBound(1) Then Console.Write(", ")
      Next
      Console.WriteLine()   
   End Sub
End Class
