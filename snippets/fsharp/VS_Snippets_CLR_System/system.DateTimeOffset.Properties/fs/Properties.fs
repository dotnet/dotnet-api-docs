open System
open System.Globalization

let showDateFormats () =
    // <Snippet1>
    // Illustrate Date property and date formatting
    let thisDate = DateTimeOffset(2008, 3, 17, 1, 32, 0, TimeSpan(-5, 0, 0))

    // Display date only using "D" format specifier
    // For en-us culture, displays:
    //   'D' format specifier: Monday, March 17, 2008
    let fmt = "D"
    printfn $"'{fmt}' format specifier: {thisDate.Date.ToString fmt}"

    // Display date only using "d" format specifier
    // For en-us culture, displays:
    //   'd' format specifier: 3/17/2008
    let fmt = "d"
    printfn $"'{fmt}' format specifier: {thisDate.Date.ToString fmt}"

    // Display date only using "Y" (or "y") format specifier
    // For en-us culture, displays:
    //   'Y' format specifier: March, 2008
    let fmt = "Y"
    printfn $"'{fmt}' format specifier: {thisDate.Date.ToString fmt}"

    // Display date only using custom format specifier
    // For en-us culture, displays:
    //   'dd MMM yyyy' format specifier: 17 Mar 2008
    let fmt = "dd MMM yyyy"
    printfn $"'{fmt}' format specifier: {thisDate.Date.ToString fmt}"
    // </Snippet1>

let convertToDateTime () =
    // <Snippet2>
    let offsetDate = DateTimeOffset.Now
    let regularDate = offsetDate.DateTime
    printfn $"{offsetDate} converts to {regularDate}, Kind {regularDate.Kind}."

    let offsetDate = DateTimeOffset.UtcNow
    let regularDate = offsetDate.DateTime
    printfn $"{offsetDate} converts to {regularDate}, Kind {regularDate.Kind}."

    // If run on 3/6/2007 at 17:11, produces the following output:
    //
    //   3/6/2007 5:11:22 PM -08:00 converts to 3/6/2007 5:11:22 PM, Kind Unspecified.
    //   3/7/2007 1:11:22 AM +00:00 converts to 3/7/2007 1:11:22 AM, Kind Unspecified.
    // </Snippet2>

let showFirstOfMonth () =
    // <Snippet3>
    let mutable startOfMonth = DateTimeOffset(2008, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset)
    let year = startOfMonth.Year

    while startOfMonth.Year = year do
        printfn $"""{startOfMonth.ToString "MMM d, yyyy"} is a {startOfMonth.DayOfWeek}."""
        startOfMonth <- startOfMonth.AddMonths 1

    // This example writes the following output to the console:
    //    Jan 1, 2008 is a Tuesday.
    //    Feb 1, 2008 is a Friday.
    //    Mar 1, 2008 is a Saturday.
    //    Apr 1, 2008 is a Tuesday.
    //    May 1, 2008 is a Thursday.
    //    Jun 1, 2008 is a Sunday.
    //    Jul 1, 2008 is a Tuesday.
    //    Aug 1, 2008 is a Friday.
    //    Sep 1, 2008 is a Monday.
    //    Oct 1, 2008 is a Wednesday.
    //    Nov 1, 2008 is a Saturday.
    //    Dec 1, 2008 is a Monday.
    // </Snippet3>

    // <Snippet4>
    let displayDate = DateTimeOffset(2008, 1, 1, 13, 18, 00, DateTimeOffset.Now.Offset)
    printfn $"{displayDate:D}"                          // Output: Tuesday, January 01, 2008
    printfn $"{displayDate:d} is a {displayDate:dddd}." // Output: 1/1/2008 is a Tuesday.
    // </Snippet4>

    // <Snippet5>
    let thisDate = DateTimeOffset(2007, 6, 1, 6, 15, 0, DateTimeOffset.Now.Offset)
    let weekdayName = thisDate.ToString("dddd", CultureInfo "fr-fr")
    printfn $"{weekdayName}"                  // Displays vendredi
    // </Snippet5>

let showHour () =
    // <Snippet6>
    let theTime = DateTimeOffset(2008, 3, 1, 14, 15, 00, DateTimeOffset.Now.Offset)
    printfn $"The hour component of {theTime} is {theTime.Hour}."

    printfn $"""The hour component of {theTime} is{theTime.ToString " H"}."""

    printfn $"The hour component of {theTime} is {theTime:HH}."

    // The example produces the following output:
    //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
    //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
    //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
    // </Snippet6>

let convertToLocalTime () =
    // <Snippet7>
    // Current time
    let dto = DateTimeOffset.Now
    printfn $"{dto.LocalDateTime}"
    // UTC time
    let dto = DateTimeOffset.UtcNow
    printfn $"{dto.LocalDateTime}"

    // Transition to DST in local time zone occurs on 3/11/2007 at 2:00 AM
    let dto = DateTimeOffset(2007, 3, 11, 3, 30, 0, TimeSpan(-7, 0, 0))
    printfn $"{dto.LocalDateTime}"
    let dto = DateTimeOffset(2007, 3, 11, 2, 30, 0, TimeSpan(-7, 0, 0))
    printfn $"{dto.LocalDateTime}"
    // Invalid time in local time zone
    let dto = DateTimeOffset(2007, 3, 11, 2, 30, 0, TimeSpan(-8, 0, 0))
    printfn $"{TimeZoneInfo.Local.IsInvalidTime dto.DateTime}"
    printfn $"{dto.LocalDateTime}"

    // Transition from DST in local time zone occurs on 11/4/07 at 2:00 AM
    // This is an ambiguous time
    let dto = DateTimeOffset(2007, 11, 4, 1, 30, 0, TimeSpan(-7, 0, 0))
    printfn $"{TimeZoneInfo.Local.IsAmbiguousTime dto}"
    printfn $"{dto.LocalDateTime}"
    let dto = DateTimeOffset(2007, 11, 4, 2, 30, 0, TimeSpan(-7, 0, 0))
    printfn $"{TimeZoneInfo.Local.IsAmbiguousTime dto}"
    printfn $"{dto.LocalDateTime}"
    // This is also an ambiguous time
    let dto = DateTimeOffset(2007, 11, 4, 1, 30, 0, TimeSpan(-8, 0, 0))
    printfn $"{TimeZoneInfo.Local.IsAmbiguousTime dto}"
    printfn $"{dto.LocalDateTime}"

    // If run on 3/8/2007 at 4:56 PM, the code produces the following
    // output:
    //    3/8/2007 4:56:03 PM
    //    3/8/2007 4:56:03 PM
    //    3/11/2007 3:30:00 AM
    //    3/11/2007 1:30:00 AM
    //    True
    //    3/11/2007 3:30:00 AM
    //    True
    //    11/4/2007 1:30:00 AM
    //    11/4/2007 1:30:00 AM
    //    True
    //    11/4/2007 1:30:00 AM
    // </Snippet7>

let showMinute () =
    // <Snippet8>
    let theTime = DateTimeOffset(2008, 5, 1, 10, 3, 0, DateTimeOffset.Now.Offset)
    printfn $"The minute component of {theTime} is {theTime.Minute}."

    printfn $"""The minute component of {theTime} is{theTime.ToString " m"}."""

    printfn $"The minute component of {theTime} is {theTime:mm}."

    // The example produces the following output:
    //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
    //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
    //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 03.
    // </Snippet8>

let showMonth () =
    // <Snippet9>
    let theTime = DateTimeOffset(2008, 9, 7, 11, 25, 0, DateTimeOffset.Now.Offset)
    printfn $"The month component of {theTime} is {theTime.Month}."

    printfn $"""The month component of {theTime} is{theTime.ToString " M"}."""

    printfn $"""The month component of {theTime} is {theTime.ToString "MM"}."""

    // The example produces the following output:
    //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
    //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
    //    The month component of 9/7/2008 11:25:00 AM -08:00 is 09.
    // </Snippet9>

let showDay () =
    // <Snippet10>
    let theTime = DateTimeOffset(2007, 5, 1, 16, 35, 0, DateTimeOffset.Now.Offset)
    printfn $"The day component of {theTime} is {theTime.Day}."

    printfn $"""The day component of {theTime} is{theTime.ToString " d"}."""

    printfn $"The day component of {theTime} is {theTime:dd}."

    // The example produces the following output:
    //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
    //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
    //    The day component of 5/1/2007 4:35:00 PM -08:00 is 01.
    // </Snippet10>

let showResolution () =
    // <Snippet11>
    let mutable ms = 0
    for _ = 0 to 99 do
        let dto = DateTimeOffset.Now
        if dto.Millisecond <> ms then
            ms <- dto.Millisecond
            printfn $"""{dto.ToString "M/d/yyyy h:mm:ss"}:{ms:d3} ms. {dto:zzz}"""      
    // </Snippet11>

let showMilliseconds () =
    // <Snippet12>
    let date1 = DateTimeOffset(2008, 3, 5, 5, 45, 35, 649, TimeSpan(-7, 0, 0))
    printfn $"""Milliseconds value of {date1.ToString "MM/dd/yyyy hh:mm:ss.fff"} is {date1.Millisecond}."""
                    
    // The example produces the following output:
    //
    // Milliseconds value of 03/05/2008 05:45:35.649 is 649.
    // </Snippet12>

let showLocalOffset () =
    // <Snippet13>
    let localTime = DateTimeOffset.Now        
    printfn $"""The local time zone is {abs localTime.Offset.Hours} hours and {localTime.Offset.Minutes} minutes {if localTime.Offset.Hours < 0 then "earlier" else "later"} than UTC."""

    // The example displays output similar to the following for a system in the
    // U.S. Pacific Standard Time zone:
    //       The local time zone is 8 hours and 0 minutes earlier than UTC.
    // </Snippet13>

let showSeconds () =
    // <Snippet14>
    let theTime = DateTimeOffset(2008, 6, 12, 21, 16, 32, DateTimeOffset.Now.Offset)
    printfn $"The second component of {theTime} is {theTime.Second}."

    printfn $"""The second component of {theTime} is{theTime.ToString " s"}."""

    printfn $"The second component of {theTime} is {theTime:ss}."

    // The example produces the following output:
    //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
    //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
    //    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
    // </Snippet14>

let illustrateTicks () =
    // <Snippet15>
    // Attempt to initialize date to number of ticks
    // in July 1, 2008 1:23:07.
    //
    // There are 10,000,000 100-nanosecond intervals in a second
    let NSPerSecond = 10000000L
    let ticks = 7L * NSPerSecond                                  // Ticks in a 7 seconds
    let ticks = ticks + 23L * 60L * NSPerSecond                   // Ticks in 23 minutes
    let ticks = ticks + 1L * 60L * 60L * NSPerSecond              // Ticks in 1 hour
    let ticks = ticks + 60L * 60L * 24L * NSPerSecond             // Ticks in 1 day
    let ticks = ticks + 181L * 60L * 60L * 24L * NSPerSecond      // Ticks in 6 months
    let ticks = ticks + 2007L * 60L * 60L * 24L * 365L * NSPerSecond   // Ticks in 2007 years
    let ticks = ticks + 486L * 60L * 60L * 24L * NSPerSecond      // Adjustment for leap years
    let dto = DateTimeOffset(ticks, DateTimeOffset.Now.Offset)
    printfn $"There are {ticks:n0} ticks in {dto}."

    // The example displays the following output:
    //       There are 633,504,721,870,000,000 ticks in 7/1/2008 1:23:07 AM -08:00.
    // </Snippet15>

let showTime () =
    // <Snippet16>
    let currentDate = DateTimeOffset(2008, 5, 10, 5, 32, 16, DateTimeOffset.Now.Offset)
    let currentTime = currentDate.TimeOfDay
    printfn $"The current time is {currentTime}."
    // The example produces the following output:
    //       The current time is 05:32:16.
    // </Snippet16>

let convertToUtc() =
    // <Snippet17>
    let offsetTime = DateTimeOffset(2007, 11, 25, 11, 14, 00, TimeSpan(3, 0, 0))
    printfn $"{offsetTime} is equivalent to {offsetTime.UtcDateTime} {offsetTime.UtcDateTime.Kind}"
    // The example displays the following output:
    //       11/25/2007 11:14:00 AM +03:00 is equivalent to 11/25/2007 8:14:00 AM Utc
    // </Snippet17>

let compareUtcAndLocal () =
    // <Snippet18>
    let localTime = DateTimeOffset.Now
    let utcTime = DateTimeOffset.UtcNow

    printfn $"Local Time:          {localTime:T}"
    printfn $"Difference from UTC: {localTime.Offset}"
    printfn $"UTC:                 {utcTime:T}"

    // If run on a particular date at 1:19 PM, the example produces
    // the following output:
    //    Local Time:          1:19:43 PM
    //    Difference from UTC: -07:00:00
    //    UTC:                 8:19:43 PM
    // </Snippet18>

let showYear () =
    // <Snippet19>
    let theTime = DateTimeOffset(2008, 2, 17, 9, 0, 0, DateTimeOffset.Now.Offset)
    printfn $"The year component of {theTime} is {theTime.Year}."

    printfn $"""The year component of {theTime} is{theTime.ToString " y"}."""

    printfn $"The year component of {theTime} is {theTime:yy}."

    printfn $"The year component of {theTime} is {theTime:yyyy}."
    
    // The example produces the following output:
    //    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
    //    The year component of 2/17/2008 9:00:00 AM -07:00 is 8.
    //    The year component of 2/17/2008 9:00:00 AM -07:00 is 08.
    //    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
    // </Snippet19>

showDateFormats ()
printfn "----------"
convertToDateTime ()
printfn "----------"
showFirstOfMonth ()
printfn "----------"
showHour ()
printfn "----------"
convertToLocalTime ()
printfn "----------"
showMinute ()
printfn "----------"
showMonth ()
printfn "----------"
showDay ()
printfn "----------"
showResolution ()
printfn "----------"
showMilliseconds ()
printfn "----------"
showLocalOffset ()
printfn "----------"
showSeconds ()
printfn "----------"
illustrateTicks ()
printfn "----------"
showTime ()
printfn "----------"
convertToUtc ()
printfn "----------"
compareUtcAndLocal ()
printfn "----------"
showYear ()
printfn "----------"