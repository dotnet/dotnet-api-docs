module Methods

open System

let showSchedule () =
    // <Snippet1>
    let takeOff = DateTimeOffset(2007, 6, 1, 7, 55, 0, TimeSpan(-5, 0, 0))
    let mutable currentTime = takeOff
    let flightTimes = [| TimeSpan(2, 25, 0); TimeSpan(1, 48, 0) |]
    printfn $"Takeoff is scheduled for {takeOff:d} at {takeOff:T}."
                    
    for i = 0 to flightTimes.Length - 1 do
        currentTime <- currentTime.Add flightTimes[i]
        printfn $"Destination #{i + 1} at {currentTime}."
    // </Snippet1>

let showStartOfWorkWeek () =
    // <Snippet2>
    let workDay = DateTimeOffset(2008, 3, 1, 9, 0, 0, DateTimeOffset.Now.Offset)
    let month = workDay.Month

    // Start with the first Monday of the month
    let mutable workDay = 
        match workDay.DayOfWeek with
        | DayOfWeek.Monday ->
            workDay
        | DayOfWeek.Sunday ->
            workDay.AddDays 1
        | _ ->
            workDay.AddDays(8. - float workDay.DayOfWeek)

    printfn $"Beginning of Work Week In {workDay:MMMM} {workDay:yyyy}:"
    
    // Add one week to the current date
    while workDay.Month = month do
        printfn $"   {workDay:dddd}, {workDay:MMMM}{workDay: d}"
        workDay <- workDay.AddDays 7

    // The example produces the following output:
    //    Beginning of Work Week In March 2008:
    //       Monday, March 3
    //       Monday, March 10
    //       Monday, March 17
    //       Monday, March 24
    //       Monday, March 31
    // </Snippet2>

let showShiftStartTimes () =
    // <Snippet3>
    let shiftLength = 8

    let startTime = DateTimeOffset(2007, 8, 6, 0, 0, 0, DateTimeOffset.Now.Offset)
    let mutable startOfShift = startTime.AddHours shiftLength

    printfn $"Shifts for the week of {startOfShift:D}"
    while startOfShift.DayOfWeek <> DayOfWeek.Saturday &&
          startOfShift.DayOfWeek <> DayOfWeek.Sunday do
        // Exclude third shift
        if startOfShift.Hour > 6 then
            printfn $"   {startOfShift:d} at {startOfShift:T}"

        startOfShift <- startOfShift.AddHours shiftLength

    // The example produces the following output:
    //
    //    Shifts for the week of Monday, August 06, 2007
    //       8/6/2007 at 8:00:00 AM
    //       8/6/2007 at 4:00:00 PM
    //       8/7/2007 at 8:00:00 AM
    //       8/7/2007 at 4:00:00 PM
    //       8/8/2007 at 8:00:00 AM
    //       8/8/2007 at 4:00:00 PM
    //       8/9/2007 at 8:00:00 AM
    //       8/9/2007 at 4:00:00 PM
    //       8/10/2007 at 8:00:00 AM
    //       8/10/2007 at 4:00:00 PM
    // </Snippet3>

let showQuarters () =
    // <Snippet4>
    let mutable quarterDate = DateTimeOffset(2007, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset)
    for i = 1 to 4 do
        printfn $"""Quarter {i}: {quarterDate.ToString "MMMM d"}"""
        quarterDate <- quarterDate.AddMonths 3

    // This example produces the following output:
    //       Quarter 1: January 1
    //       Quarter 2: April 1
    //       Quarter 3: July 1
    //       Quarter 4: October 1
    // </Snippet4>


let showLegalLicenseAge () =
    // <Snippet6>
    let minimumAge = 16
    let dateToday = DateTimeOffset.Now
    let latestBirthday = dateToday.AddYears(-1 * minimumAge)
    printfn $"To possess a driver's license, you must have been born on or before {latestBirthday:d}."
    // </Snippet6>

let compareForEquality1 () =
    // <Snippet9>
    let firstTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-7, 0, 0))

    let secondTime = firstTime
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-6, 0, 0))
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = DateTimeOffset(2007, 9, 1, 8, 45, 0, TimeSpan(-5, 0, 0))
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    // The example displays the following output to the console:
    //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
    //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
    //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True
    // </Snippet9>

// <Snippet10>
let compareForEquality2 () =
    let firstTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-7, 0, 0))

    let secondTime: obj = firstTime
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-6, 0, 0))
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = DateTimeOffset(2007, 9, 1, 8, 45, 0, TimeSpan(-5, 0, 0))
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = null
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"

    let secondTime = DateTime(2007, 9, 1, 6, 45, 00)
    printfn $"{firstTime} = {secondTime}: {firstTime.Equals secondTime}"
                    
    // The example displays the following output to the console:
    //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
    //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
    //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True
    //       9/1/2007 6:45:00 AM -07:00 = : False
    //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM: False
    // </Snippet10>

let compareForEquality3 () =
    // <Snippet11>
    let firstTime = DateTimeOffset(2007, 11, 15, 11, 35, 00, DateTimeOffset.Now.Offset)
    let secondTime = firstTime
    printfn $"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}"

    // The value of firstTime remains unchanged
    let secondTime = DateTimeOffset(firstTime.DateTime, TimeSpan.FromHours(firstTime.Offset.Hours + 1 |> float))
    printfn $"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}"

    // value of firstTime remains unchanged
    let secondTime = DateTimeOffset(firstTime.DateTime + TimeSpan.FromHours 1, TimeSpan.FromHours(firstTime.Offset.Hours + 1 |> float))
    printfn $"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}"

    // The example produces the following output:
    //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -07:00: True
    //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -06:00: False
    //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 12:35:00 PM -06:00: True
    // </Snippet11>

let compareExactly () =
    // <Snippet12>
    let instanceTime = DateTimeOffset(2007, 10, 31, 0, 0, 0, DateTimeOffset.Now.Offset)

    let otherTime = instanceTime
    printfn $"{instanceTime} = {otherTime}: {instanceTime.EqualsExact otherTime}"

    let otherTime = DateTimeOffset(instanceTime.DateTime, TimeSpan.FromHours(instanceTime.Offset.Hours + 1 |> float))
    printfn $"{instanceTime} = {otherTime}: {instanceTime.EqualsExact otherTime}"

    let otherTime = DateTimeOffset(instanceTime.DateTime + TimeSpan.FromHours 1, TimeSpan.FromHours(instanceTime.Offset.Hours + 1 |> float))
    printfn $"{instanceTime} = {otherTime}: {instanceTime.EqualsExact otherTime}"

    // The example produces the following output:
    //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -07:00: True
    //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -06:00: False
    //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 1:00:00 AM -06:00: False
    // </Snippet12>

let subtract1 () =
    // <Snippet13>
    let firstDate = DateTimeOffset(2018, 10, 25, 18, 0, 0, TimeSpan(-7, 0, 0))
    let secondDate = DateTimeOffset(2018, 10, 25, 18, 0, 0, TimeSpan(-5, 0, 0))
    let thirdDate = DateTimeOffset(2018, 9, 28, 9, 0, 0, TimeSpan(-7, 0, 0))

    let difference = firstDate.Subtract secondDate
    printfn $"({firstDate}) - ({secondDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}"

    let difference = firstDate.Subtract thirdDate
    printfn $"({firstDate}) - ({thirdDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}"

    // The example produces the following output:
    //    (10/25/2018 6:00:00 PM -07:00) - (10/25/2018 6:00:00 PM -05:00): 0 days, 2:00
    //    (10/25/2018 6:00:00 PM -07:00) - (9/28/2018 9:00:00 AM -07:00): 27 days, 9:00
    // </Snippet13>

let subtract2 () =
    // <Snippet14>
    let offsetDate = DateTimeOffset(2007, 12, 3, 11, 30, 0, TimeSpan(-8, 0, 0))
    let duration = TimeSpan(7, 18, 0, 0)
    printfn $"{offsetDate.Subtract duration}"  // Displays 11/25/2007 5:30:00 PM -08:00
    // </Snippet14>

let convertToLocal () =
    // <Snippet15>
    // Local time changes on 3/11/2007 at 2:00 AM
    let originalTime = DateTimeOffset(2007, 3, 11, 3, 0, 0, TimeSpan(-6, 0, 0))
    let localTime = originalTime.ToLocalTime()
    printfn $"Converted {originalTime} to {localTime}."

    let originalTime = DateTimeOffset(2007, 3, 11, 4, 0, 0, TimeSpan(-6, 0, 0))
    let localTime = originalTime.ToLocalTime()
    printfn $"Converted {originalTime} to {localTime}."

    // Define a summer UTC time
    let originalTime = DateTimeOffset(2007, 6, 15, 8, 0, 0, TimeSpan.Zero)
    let localTime = originalTime.ToLocalTime()
    printfn $"Converted {originalTime} to {localTime}."

    // Define a winter time
    let originalTime = DateTimeOffset(2007, 11, 30, 14, 0, 0, TimeSpan(3, 0, 0))
    let localTime = originalTime.ToLocalTime()
    printfn $"Converted {originalTime} to {localTime}."

    // The example produces the following output:
    //    Converted 3/11/2007 3:00:00 AM -06:00 to 3/11/2007 1:00:00 AM -08:00.
    //    Converted 3/11/2007 4:00:00 AM -06:00 to 3/11/2007 3:00:00 AM -07:00.
    //    Converted 6/15/2007 8:00:00 AM +00:00 to 6/15/2007 1:00:00 AM -07:00.
    //    Converted 11/30/2007 2:00:00 PM +03:00 to 11/30/2007 3:00:00 AM -08:00.
    // </Snippet15>

let convertToUniversal () =
    // <Snippet16>
    // Define local time in local time zone
    let localTime = DateTimeOffset(DateTime(2007, 6, 15, 12, 0, 0))
    printfn $"Local time: {localTime}\n"

    // Convert local time to offset 0 and assign to otherTime
    let otherTime = localTime.ToOffset TimeSpan.Zero
    printfn $"Other time: {otherTime}"
    printfn $"{localTime} = {otherTime}: {localTime.Equals otherTime}"                    
    printfn $"{localTime} exactly equals {otherTime}: {localTime.EqualsExact otherTime}\n"

    // Convert other time to UTC
    let universalTime = localTime.ToUniversalTime()
    printfn $"Universal time: {universalTime}"
    printfn $"{otherTime} = {universalTime}: {universalTime.Equals otherTime}"                    
    printfn $"{otherTime} exactly equals {universalTime}: {universalTime.EqualsExact otherTime}\n"

    // The example produces the following output to the console:
    //    Local time: 6/15/2007 12:00:00 PM -07:00
    //
    //    Other time: 6/15/2007 7:00:00 PM +00:00
    //    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
    //    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
    //
    //    Universal time: 6/15/2007 7:00:00 PM +00:00
    //    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
    //    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True
    // </Snippet16>

showSchedule ()
printfn $"----------"
showStartOfWorkWeek ()
printfn $"----------"
showShiftStartTimes ()
printfn $"----------"
showQuarters ()
printfn $"----------"
showLegalLicenseAge ()
printfn $"----------"
compareForEquality1 ()
printfn $"----------"
compareForEquality2 ()
printfn $"----------"
compareForEquality3 ()
printfn $"----------"
compareExactly ()
printfn $"----------"
subtract1 ()
printfn $"----------"
subtract2 ()
printfn $"----------"
convertToLocal ()
printfn $"----------"
convertToUniversal ()
printfn $"----------"