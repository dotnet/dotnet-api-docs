﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
<Flags> Enum Colors As Integer
   None = 0
   Red = 1
   Green = 2
   Blue = 4
End Enum

Module Example
   Public Sub Main()
      Dim colorStrings() As String = {"0", "2", "8", "blue", "Blue", "Yellow", "Red, Green"}
      For Each colorString As String In colorStrings
         Try
            Dim colorValue As Colors = CType([Enum].Parse(GetType(Colors), colorString, True), Colors)        
            If [Enum].IsDefined(GetType(Colors), colorValue) Or colorValue.ToString().Contains(",") Then 
               Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString())
            Else
               Console.WriteLine("{0} is not an underlying value of the Colors enumeration.", colorString)            
            End If                    
         Catch e As ArgumentException
            Console.WriteLine("{0} is not a member of the Colors enumeration.", colorString)
         End Try
      Next
   End Sub
End Module
' The example displays the following output:
'       Converted '0' to None.
'       Converted '2' to Green.
'       8 is not an underlying value of the Colors enumeration.
'       Converted 'blue' to Blue.
'       Converted 'Blue' to Blue.
'       Yellow is not a member of the Colors enumeration.
'       Converted 'Red, Green' to Red, Green.
' </Snippet2>
