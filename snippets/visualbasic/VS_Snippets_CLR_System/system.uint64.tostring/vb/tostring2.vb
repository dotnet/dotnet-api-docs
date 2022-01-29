﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Define an array of CultureInfo objects.
      Dim ci() As CultureInfo = { New CultureInfo("en-US"), _
                                  New CultureInfo("fr-FR"), _
                                  CultureInfo.InvariantCulture } 
      Dim value As ULong = 18709243
      Console.WriteLine("  {0,12}   {1,12}   {2,12}", _
                        GetName(ci(0)), GetName(ci(1)), GetName(ci(2))) 
      Console.WriteLine("  {0,12}   {1,12}   {2,12}", _
                        value.ToString(ci(0)), value.ToString(ci(1)), value.ToString(ci(2)))            
      
   End Sub
   
   Private Function GetName(ci As CultureInfo) As String
      If ci.Equals(CultureInfo.InvariantCulture) Then
         Return "Invariant"
      Else
         Return ci.Name
      End If   
   End Function
End Module
' The example displays the following output:
'             en-US          fr-FR      Invariant
'          18709243       18709243       18709243
' </Snippet2>
