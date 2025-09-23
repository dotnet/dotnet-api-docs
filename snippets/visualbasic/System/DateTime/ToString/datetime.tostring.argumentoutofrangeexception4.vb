' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example4
    Public Sub Main()
        Dim arSA As New CultureInfo("ar-SA")
        arSA.DateTimeFormat.Calendar = New UmAlQuraCalendar()
        Dim date1 As Date = #09/10/1890#

        Try
            Console.WriteLine(date1.ToString("d", arSA))
        Catch e As ArgumentOutOfRangeException
            Console.WriteLine("{0:d} is earlier than {1:d} or later than {2:d}",
                           date1,
                           arSA.DateTimeFormat.Calendar.MinSupportedDateTime,
                           arSA.DateTimeFormat.Calendar.MaxSupportedDateTime)
        End Try
    End Sub
End Module

' The example displays the following output:
'    9/10/1890 is earlier than 4/30/1900 or later than 5/13/2029
' </Snippet4>
