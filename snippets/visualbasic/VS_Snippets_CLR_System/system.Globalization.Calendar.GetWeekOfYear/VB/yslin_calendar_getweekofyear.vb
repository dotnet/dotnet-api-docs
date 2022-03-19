﻿' The following code example shows how the result of GetWeekOfYear varies depending on the FirstDayOfWeek and the CalendarWeekRule used.
' If the specified date is the last day of the year, GetWeekOfYear returns the total number of weeks in that year.

' <snippet1>
Imports System.Globalization

Public Class SamplesCalendar

   Public Shared Sub Main()
      
      ' Gets the Calendar instance associated with a CultureInfo.
      Dim myCI As New CultureInfo("en-US")
      Dim myCal As Calendar = myCI.Calendar
      
      ' Gets the DTFI properties required by GetWeekOfYear.
      Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
      Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
      
      ' Displays the number of the current week relative to the beginning of the year.
      Console.WriteLine("The CalendarWeekRule used for the en-US culture is {0}.", myCWR)
      Console.WriteLine("The FirstDayOfWeek used for the en-US culture is {0}.", myFirstDOW)
      Console.WriteLine("Therefore, the current week is Week {0} of the current year.", myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW))
      
      ' Displays the total number of weeks in the current year.
      Dim LastDay = New System.DateTime(DateTime.Now.Year, 12, 31)
      Console.WriteLine("There are {0} weeks in the current year ({1}).", myCal.GetWeekOfYear(LastDay, myCWR, myFirstDOW), LastDay.Year)
   End Sub
End Class


'This code produces the following output.  Results vary depending on the system date.
'
'The CalendarWeekRule used for the en-US culture is FirstDay.
'The FirstDayOfWeek used for the en-US culture is Sunday.
'Therefore, the current week is Week 1 of the current year.
'There are 53 weeks in the current year (2001).

' </snippet1>