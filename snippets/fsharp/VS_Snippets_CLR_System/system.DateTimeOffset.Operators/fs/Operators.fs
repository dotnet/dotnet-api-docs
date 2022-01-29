open System

let showAddition () =
    // <Snippet1>
    let date1 =
        DateTimeOffset(2008, 1, 1, 13, 32, 45, TimeSpan(-5, 0, 0))

    let interval1 = TimeSpan(202, 3, 30, 0)
    let interval2 = TimeSpan(5, 0, 0, 0)

    printfn $"{date1}" // Displays 1/1/2008 1:32:45 PM -05:00
    let date2 = date1 + interval1
    printfn $"{date2}" // Displays 7/21/2008 5:02:45 PM -05:00
    let date2 = date2 + interval2
    printfn $"{date2}" // Displays 7/26/2008 5:02:45 PM -05:00
    // </Snippet1>

let showEquality () =
    // <Snippet2>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-6, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-6, 0, 0))

    printfn $"{date1 = date2}" // Displays True
    printfn $"{date1 = date3}" // Displays False
    // </Snippet2>

let showGreaterThan () =
    // <Snippet3>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-6, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-6, 0, 0))

    printfn $"{date1 > date2}" // Displays False
    printfn $"{date1 > date3}" // Displays True
// </Snippet3>

let showGreaterThanOrEqualTo () =
    // <Snippet5>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-7, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-6, 0, 0))

    let date4 = date1
    printfn $"{date1 >= date2}" // Displays False
    printfn $"{date1 >= date3}" // Displays True
    printfn $"{date1 >= date4}" // Displays True
    // </Snippet5>

let showImplicitConversions () =
    // <Snippet7>
    let timeWithOffset = DateTime(2008, 7, 3, 18, 45, 0)
    printfn $"{timeWithOffset}"

    let timeWithOffset = DateTime.UtcNow
    printfn $"{timeWithOffset}"

    let timeWithOffset =
        DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified)

    printfn $"{timeWithOffset}"

    let timeWithOffset =
        DateTime(2008, 7, 1, 2, 30, 0)
        + TimeSpan(1, 0, 0, 0)

    printfn $"{timeWithOffset}"

    let timeWithOffset = DateTime(2008, 1, 1, 2, 30, 0)
    printfn $"{timeWithOffset}"

    // The example produces the following output if run on 3/20/2007
    // at 6:25 PM on a computer in the U.S. Pacific Daylight Time zone:
    //       7/3/2008 6:45:00 PM -07:00
    //       3/21/2007 1:25:52 AM +00:00
    //       3/20/2007 6:25:52 PM -07:00
    //       7/2/2008 2:30:00 AM -07:00
    //       1/1/2008 2:30:00 AM -08:00
    //
    // The last example shows automatic adaption to the U.S. Pacific Time
    // for winter dates.
    // </Snippet7>

let showInequality () =
    // <Snippet8>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-6, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-6, 0, 0))

    printfn $"{date1 <> date2}" // Displays False
    printfn $"{date1 <> date3}" // Displays True
    // </Snippet8>

let showLessThan () =
    // <Snippet10>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-6, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-8, 0, 0))

    printfn $"{date1 < date2}" // Displays False
    printfn $"{date1 < date3}" // Displays True
    // </Snippet10>

let showLessThanOrEqualTo () =
    // <Snippet12>
    let date1 =
        DateTimeOffset(2007, 6, 3, 14, 45, 0, TimeSpan(-7, 0, 0))

    let date2 =
        DateTimeOffset(2007, 6, 3, 15, 45, 0, TimeSpan(-7, 0, 0))

    let date3 =
        DateTimeOffset(date1.DateTime, TimeSpan(-6, 0, 0))

    let date4 = date1
    printfn $"{date1 <= date2}" // Displays True
    printfn $"{date1 <= date3}" // Displays False
    printfn $"{date1 <= date4}" // Displays True
    // </Snippet12>

let showSubtraction1 () =
    // <Snippet14>
    let firstDate =
        DateTimeOffset(2008, 3, 25, 18, 0, 0, TimeSpan(-7, 0, 0))

    let secondDate =
        DateTimeOffset(2008, 3, 25, 18, 0, 0, TimeSpan(-5, 0, 0))

    let thirdDate =
        DateTimeOffset(2008, 2, 28, 9, 0, 0, TimeSpan(-7, 0, 0))

    let difference = firstDate - secondDate
    printfn $"({firstDate}) - ({secondDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}"

    let difference = firstDate - thirdDate
    printfn $"({firstDate}) - ({secondDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}"
    // The example produces the following output:
    //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 0 days, 2:00
    //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 26 days, 9:00
    // </Snippet14>

let showSubtraction2 () =
    // <Snippet15>
    let offsetDate =
        DateTimeOffset(2007, 12, 3, 11, 30, 0, TimeSpan(-8, 0, 0))

    let duration = TimeSpan(7, 18, 0, 0)
    printfn $"{offsetDate - duration}" // Displays 11/25/2007 5:30:00 PM -08:00
    // </Snippet15>

showAddition ()
showEquality ()
showGreaterThan ()
showGreaterThanOrEqualTo ()
showImplicitConversions ()
showInequality ()
showLessThan ()
showLessThanOrEqualTo ()
showSubtraction1 ()
showSubtraction2 ()
