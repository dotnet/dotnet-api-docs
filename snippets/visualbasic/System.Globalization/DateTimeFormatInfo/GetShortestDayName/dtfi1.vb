Imports System.Globalization

Class Sample
    Public Shared Sub Main()
        '<snippet1>
        Dim myDateTimePatterns() As String = {"MM/dd/yy", "MM/dd/yyyy"}
        Dim name As String = ""

        ' Get the en-US culture.
        Dim ci As New CultureInfo("en-US")
        ' Get the DateTimeFormatInfo for the en-US culture.
        Dim dtfi As DateTimeFormatInfo = ci.DateTimeFormat

        ' Display the effective culture.
        Console.WriteLine("This code example uses the {0} culture.", ci.Name)

        ' Display the native calendar name.    
        Console.WriteLine(vbCrLf & "NativeCalendarName...")
        Console.WriteLine("""{0}""", dtfi.NativeCalendarName)

        ' Display month genitive names.
        Console.WriteLine(vbCrLf & "MonthGenitiveNames...")
        For Each name In dtfi.MonthGenitiveNames
            Console.WriteLine("""{0}""", name)
        Next name

        ' Display abbreviated month genitive names.
        Console.WriteLine(vbCrLf & "AbbreviatedMonthGenitiveNames...")
        For Each name In dtfi.AbbreviatedMonthGenitiveNames
            Console.WriteLine("""{0}""", name)
        Next name

        ' Display shortest day names.
        Console.WriteLine(vbCrLf & "ShortestDayNames...")
        For Each name In dtfi.ShortestDayNames
            Console.WriteLine("""{0}""", name)
        Next name

        ' Display shortest day name for a particular day of the week.
        Console.WriteLine(vbCrLf & "GetShortestDayName(DayOfWeek.Sunday)...")
        Console.WriteLine("""{0}""", dtfi.GetShortestDayName(DayOfWeek.Sunday))

        ' Display the initial DateTime format patterns for the 'd' format specifier.
        Console.WriteLine(vbCrLf & "Initial DateTime format patterns for " &
                          "the 'd' format specifier...")
        For Each name In dtfi.GetAllDateTimePatterns("d"c)
            Console.WriteLine("""{0}""", name)
        Next name

        ' Change the initial DateTime format patterns for the 'd' DateTime format specifier.
        Console.WriteLine(vbCrLf & "Change the initial DateTime format patterns for the " &
                          vbCrLf & "'d' format specifier to my format patterns...")
        dtfi.SetAllDateTimePatterns(myDateTimePatterns, "d"c)

        ' Display the new DateTime format patterns for the 'd' format specifier.
        Console.WriteLine(vbCrLf &
                          "New DateTime format patterns for the 'd' format specifier...")
        For Each name In dtfi.GetAllDateTimePatterns("d"c)
            Console.WriteLine("""{0}""", name)
        Next name

        'Output:
        '
        'This code example uses the en-US culture.
        '
        'NativeCalendarName...
        '"Gregorian Calendar"
        '
        'MonthGenitiveNames...
        '"January"
        '"February"
        '"March"
        '"April"
        '"May"
        '"June"
        '"July"
        '"August"
        '"September"
        '"October"
        '"November"
        '"December"
        '""
        '
        'AbbreviatedMonthGenitiveNames...
        '"Jan"
        '"Feb"
        '"Mar"
        '"Apr"
        '"May"
        '"Jun"
        '"Jul"
        '"Aug"
        '"Sep"
        '"Oct"
        '"Nov"
        '"Dec"
        '""
        '
        'ShortestDayNames...
        '"S"
        '"M"
        '"T"
        '"W"
        '"T"
        '"F"
        '"S"
        '
        'GetShortestDayName(DayOfWeek.Sunday)...
        '"S"
        '
        'Initial DateTime format patterns for the 'd' format specifier...
        '"M/d/yyyy"
        '"MMM d, yyyy"
        '"M/d/yy"
        '
        'Change the initial DateTime format patterns for the
        ''d' format specifier to my format patterns...
        '
        'New DateTime format patterns for the 'd' format specifier...
        '"MM/dd/yy"
        '"MM/dd/yyyy"
        '
        '</snippet1>
    End Sub
End Class
