﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo
      
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      ' Find the index of the last soft hyphen.
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen))
      
      ' Find the index of the last soft hyphen followed by "n".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "n"))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "n"))
      
      ' Find the index of the last soft hyphen followed by "m".
      Console.WriteLine(ci.LastIndexOf(s1, softHyphen + "m"))
      Console.WriteLine(ci.LastIndexOf(s2, softHyphen + "m"))
   End Sub
End Module
' The example displays the following output:
'       6
'       5
'       1
'       1
'       4
'       3
' </Snippet2>

