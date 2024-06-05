open System
open System.Globalization

let constructWithDateTime () =
    // <Snippet1>
    let localNow = DateTime.Now
    let localOffset = DateTimeOffset localNow
    printfn $"{localOffset}"

    let utcNow = DateTime.UtcNow
    let utcOffset = DateTimeOffset utcNow
    printfn "{utcOffset}"

    let unspecifiedNow = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified)
    let unspecifiedOffset = DateTimeOffset unspecifiedNow
    printfn $"{unspecifiedOffset}"

    // The code produces the following output if run on Feb. 23, 2007, on
    // a system 8 hours earlier than UTC:
    //   2/23/2007 4:21:58 PM -08:00
    //   2/24/2007 12:21:58 AM +00:00
    //   2/23/2007 4:21:58 PM -08:00
    // </Snippet1>

let constructWithTicks () =
    // <Snippet2>
    let dateWithoutOffset = DateTime(2007, 7, 16, 13, 32, 00)
    let timeFromTicks = DateTimeOffset(dateWithoutOffset.Ticks, TimeSpan(-5, 0, 0))
    printfn $"{timeFromTicks}"
    // The code produces the following output:
    //    7/16/2007 1:32:00 PM -05:00
    // </Snippet2>

let constructWithDateAndOffset () =
    // <Snippet3>
    let localTime = DateTime(2007, 07, 12, 06, 32, 00)
    let dateAndOffset = DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset localTime)
    printfn $"{dateAndOffset}"
    // The code produces the following output:
    //    7/12/2007 6:32:00 AM -07:00
    // </Snippet3>

let constructNonLocalWithLocalTicks () =
    // <Snippet4>
    let localTime = DateTime.Now
    let nonLocalDateWithOffset = DateTimeOffset(localTime.Ticks, TimeSpan(2, 0, 0))
    printfn $"{nonLocalDateWithOffset}"
    // The code produces the following output if run on Feb. 23, 2007:
    //    2/23/2007 4:37:50 PM +02:00
    // </Snippet4>

let constructWithDateElements () =
    // <Snippet5>
    let specificDate = DateTime(2008, 5, 1, 06, 32, 00)
    let offsetDate = DateTimeOffset(specificDate.Year,
                                    specificDate.Month,
                                    specificDate.Day,
                                    specificDate.Hour,
                                    specificDate.Minute,
                                    specificDate.Second,
                                    TimeSpan(-5, 0, 0))
    printfn $"Current time: {offsetDate}"
    printfn $"Corresponding UTC time: {offsetDate.UtcDateTime}"
    // The code produces the following output:
    //    Current time: 5/1/2008 6:32:00 AM -05:00
    //    Corresponding UTC time: 5/1/2008 11:32:00 AM
    // </Snippet5>

let constructWithDateElements2 () =
    // <Snippet6>
    let specificDate = DateTime(2008, 5, 1, 6, 32, 05)
    let offsetDate = DateTimeOffset(specificDate.Year - 1,
                                    specificDate.Month,
                                    specificDate.Day,
                                    specificDate.Hour,
                                    specificDate.Minute,
                                    specificDate.Second,
                                    0,
                                    TimeSpan(-5, 0, 0))
    printfn $"Current time: {offsetDate}"
    printfn $"Corresponding UTC time: {offsetDate.UtcDateTime}"
    // The code produces the following output:
    //    Current time: 5/1/2007 6:32:05 AM -05:00
    //    Corresponding UTC time: 5/1/2007 11:32:05 AM
    // </Snippet6>

let constructWithDateElements3 () =
    // <Snippet7>
    let fmt = "dd MMM yyyy HH:mm:ss"
    let thisDate = DateTime(2007, 06, 12, 19, 00, 14, 16)
    let offsetDate = DateTimeOffset(thisDate.Year,
                                    thisDate.Month,
                                    thisDate.Day,
                                    thisDate.Hour,
                                    thisDate.Minute,
                                    thisDate.Second,
                                    thisDate.Millisecond,
                                    TimeSpan(2, 0, 0))
    printfn $"Current time: {offsetDate.ToString fmt}:{offsetDate.Millisecond}"
    // The code produces the following output:
    //    Current time: 12 Jun 2007 19:00:14:16
    // </Snippet7>

let constructWithCalendar () =
    // <Snippet8>
    // Instantiate DateTimeOffset with Hebrew calendar
    let year = 5770
    let cal = HebrewCalendar()
    let fmt = CultureInfo "he-IL"
    fmt.DateTimeFormat.Calendar <- cal
    let dateInCal = DateTimeOffset(year, 7, 12,
                                   15, 30, 0, 0,
                                   cal,
                                   TimeSpan(2, 0, 0))
    // Display the date in the Hebrew calendar
    printfn $"Date in Hebrew Calendar: {dateInCal.ToString fmt:g}"
    // Display the date in the Gregorian calendar
    printfn $"Date in Gregorian Calendar: {dateInCal:g}\n"

    // Instantiate DateTimeOffset with Hijri calendar
    let year = 1431
    let cal = HijriCalendar()
    let fmt = CultureInfo "ar-SA"
    fmt.DateTimeFormat.Calendar <- cal
    let dateInCal = DateTimeOffset(year, 7, 12,
                                   15, 30, 0, 0,
                                   cal,
                                   TimeSpan(2, 0, 0))
    // Display the date in the Hijri calendar
    printfn $"Date in Hijri Calendar: {dateInCal.ToString fmt:g}"
    // Display the date in the Gregorian calendar
    printfn $"Date in Gregorian Calendar: {dateInCal:g}\n"
    // </Snippet8>

constructWithDateTime ()
printfn ""
constructWithTicks ()
printfn ""
constructWithDateAndOffset ()
printfn ""
constructNonLocalWithLocalTicks ()
printfn ""
constructWithDateElements ()
printfn ""
constructWithDateElements2 ()
printfn ""
constructWithDateElements3 ()
printfn ""
constructWithCalendar ()