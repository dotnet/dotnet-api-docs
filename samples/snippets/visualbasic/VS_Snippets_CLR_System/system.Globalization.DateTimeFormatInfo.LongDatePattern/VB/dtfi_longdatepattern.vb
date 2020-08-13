' The following code example displays the value of LongDatePattern for selected cultures.

' <snippet1>
Imports System.Globalization

Public Class SamplesDTFI

   Public Shared Sub Main()

      ' Displays the values of the pattern properties.
      Console.WriteLine(" CULTURE    PROPERTY VALUE")
      PrintPattern("en-US")
      PrintPattern("ja-JP")
      PrintPattern("fr-FR")

   End Sub

   Public Shared Sub PrintPattern(myCulture As [String])

      Dim myDTFI As DateTimeFormatInfo = New CultureInfo(myCulture, False).DateTimeFormat
      Console.WriteLine("  {0}     {1}", myCulture, myDTFI.LongDatePattern)

   End Sub

End Class

'This code produces the following output:
'
' CULTURE    PROPERTY VALUE
'  en-US     dddd, MMMM d, yyyy
'  ja-JP     yyyy'年'M'月'd'日'
'  fr-FR     dddd d MMMM yyyy
'
' </snippet1>