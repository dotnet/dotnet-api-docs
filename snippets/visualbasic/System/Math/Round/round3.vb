' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim values() As Double = { 2.125, 2.135, 2.145, 3.125, 3.135, 3.145 }
      For Each value As Double In values
         Console.WriteLine("{0} --> {1}", value, Math.Round(value, 2))
      Next
   End Sub
End Module
' The example displays the following output on .NET 10 and earlier:
'       2.125 --> 2.12
'       2.135 --> 2.13
'       2.145 --> 2.14
'       3.125 --> 3.12
'       3.135 --> 3.14
'       3.145 --> 3.14
' On .NET 11 and later:
'       2.125 --> 2.12
'       2.135 --> 2.13
'       2.145 --> 2.15
'       3.125 --> 3.12
'       3.135 --> 3.13
'       3.145 --> 3.15
' </Snippet2>
