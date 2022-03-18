﻿' The following code example shows that DTFI ignores the punctuation in the era name only if the calendar is Gregorian and the culture uses the era name "A.D.".

' <snippet1>
Imports System.Globalization

Public Class SamplesGregorianCalendar

   Public Shared Sub Main()

      ' Creates strings with punctuation and without.
      Dim strADPunc As [String] = "A.D."
      Dim strADNoPunc As [String] = "AD"
      Dim strCEPunc As [String] = "C.E."
      Dim strCENoPunc As [String] = "CE"

      ' Calls DTFI.GetEra for each culture that uses GregorianCalendar as the default calendar.
      Console.WriteLine("            ----- AD -----  ----- CE -----")
      Console.WriteLine("CULTURE     PUNC   NO PUNC  PUNC   NO PUNC  CALENDAR")
      Dim myCI As CultureInfo
      For Each myCI In  CultureInfo.GetCultures(CultureTypes.SpecificCultures)
         Console.Write("{0,-12}", myCI)
         Console.Write("{0,-7}{1,-9}", myCI.DateTimeFormat.GetEra(strADPunc), myCI.DateTimeFormat.GetEra(strADNoPunc))
         Console.Write("{0,-7}{1,-9}", myCI.DateTimeFormat.GetEra(strCEPunc), myCI.DateTimeFormat.GetEra(strCENoPunc))
         Console.Write("{0}", myCI.Calendar)
         Console.WriteLine()
      Next myCI

   End Sub

End Class


'This code produces the following output.  This output has been cropped for brevity.
'
'            ----- AD -----  ----- CE -----
'CULTURE     PUNC   NO PUNC  PUNC   NO PUNC  CALENDAR
'ar-SA       -1     -1       -1     -1       System.Globalization.HijriCalendar
'ar-IQ       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-EG       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-LY       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-DZ       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-MA       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-TN       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-OM       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-YE       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-SY       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-JO       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-LB       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-KW       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-AE       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-BH       1      1        -1     -1       System.Globalization.GregorianCalendar
'ar-QA       1      1        -1     -1       System.Globalization.GregorianCalendar
'bg-BG       1      1        -1     -1       System.Globalization.GregorianCalendar
'ca-ES       -1     -1       -1     -1       System.Globalization.GregorianCalendar
'zh-TW       -1     -1       -1     -1       System.Globalization.GregorianCalendar
'zh-CN       -1     -1       -1     -1       System.Globalization.GregorianCalendar
'zh-HK       -1     -1       -1     -1       System.Globalization.GregorianCalendar
'zh-SG       1      1        -1     -1       System.Globalization.GregorianCalendar
'zh-MO       1      1        -1     -1       System.Globalization.GregorianCalendar
'cs-CZ       -1     -1       -1     -1       System.Globalization.GregorianCalendar
'da-DK       1      1        -1     -1       System.Globalization.GregorianCalendar

' </snippet1>
