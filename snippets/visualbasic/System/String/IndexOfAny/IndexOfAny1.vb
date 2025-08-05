﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example1
   Public Sub Run()
      Dim chars() As Char = { "a"c, "e"c, "i"c, "o"c, "u"c, "y"c,
                              "A"c, "E"c, "I"c, "O"c, "U"c, "Y"c }
      Dim s As String = "The long and winding road..."
      Console.WriteLine("The first vowel in {2}   {0}{2}is found at index {1}",
                        s, s.IndexOfAny(chars), vbCrLf)
   End Sub
End Module

' The example displays the following output:
'       The first vowel in
'          The long and winding road...
'       is found at index 2
' </Snippet1>
