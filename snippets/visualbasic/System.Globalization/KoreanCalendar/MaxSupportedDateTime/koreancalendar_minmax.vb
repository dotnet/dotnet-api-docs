﻿' The following code example gets the minimum date and the maximum date of the calendar.

' <snippet1>
Imports System.Globalization

Public Class SamplesCalendar   

   Public Shared Sub Main()

      ' Create an instance of the calendar.
      Dim myCal As New KoreanCalendar()
      Console.WriteLine(myCal.ToString())

      ' Create an instance of the GregorianCalendar.
      Dim myGre As New GregorianCalendar()

      ' Display the MinSupportedDateTime and its equivalent in the GregorianCalendar.
      Dim myMin As DateTime = myCal.MinSupportedDateTime
      Console.Write("MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMin), myCal.GetDayOfMonth(myMin), myCal.GetYear(myMin))
      Console.WriteLine(" (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre.GetMonth(myMin), myGre.GetDayOfMonth(myMin), myGre.GetYear(myMin))

      ' Display the MaxSupportedDateTime and its equivalent in the GregorianCalendar.
      Dim myMax As DateTime = myCal.MaxSupportedDateTime
      Console.Write("MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMax), myCal.GetDayOfMonth(myMax), myCal.GetYear(myMax))
      Console.WriteLine(" (in Gregorian, {0:D2}/{1:D2}/{2:D4})", myGre.GetMonth(myMax), myGre.GetDayOfMonth(myMax), myGre.GetYear(myMax))

   End Sub

End Class


'This code produces the following output.
'
'System.Globalization.KoreanCalendar
'MinSupportedDateTime: 01/01/2334 (in Gregorian, 01/01/0001)
'MaxSupportedDateTime: 12/31/12332 (in Gregorian, 12/31/9999)

' </snippet1>
