' The following code example retrieves the different names for each encoding
' and compares them with the equivalent Encoding names.

' <Snippet1>
Imports System.Text

Public Class SamplesEncoding

   Public Shared Sub Main()

      ' Print the header.
      Console.Write("Info.CodePage      ")
      Console.Write("Info.Name                    ")
      Console.Write("Info.DisplayName")
      Console.WriteLine()

      ' Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
      Dim ei As EncodingInfo
      For Each ei In  Encoding.GetEncodings()
         Dim e As Encoding = ei.GetEncoding()

         Console.Write("{0,-15}", ei.CodePage)
         If ei.CodePage = e.CodePage Then
            Console.Write("    ")
         Else
            Console.Write("*** ")
         End If

         Console.Write("{0,-25}", ei.Name)
         If ei.CodePage = e.CodePage Then
            Console.Write("    ")
         Else
            Console.Write("*** ")
         End If

         Console.Write("{0,-25}", ei.DisplayName)
         If ei.CodePage = e.CodePage Then
            Console.Write("    ")
         Else
            Console.Write("*** ")
         End If
         Console.WriteLine()
      Next ei

   End Sub

End Class

' The example displays the following output:
'
' Info.CodePage      Info.Name                    Info.DisplayName
' 1200               utf-16                       Unicode
' 1201               utf-16BE                     Unicode (Big-Endian)
' 12000              utf-32                       Unicode (UTF-32)
' 12001              utf-32BE                     Unicode (UTF-32 Big-Endian)
' 20127              us-ascii                     US-ASCII
' 28591              iso-8859-1                   Western European (ISO)
' 65000              utf-7                        Unicode (UTF-7)
' 65001              utf-8                        Unicode (UTF-8)

' </Snippet1>
