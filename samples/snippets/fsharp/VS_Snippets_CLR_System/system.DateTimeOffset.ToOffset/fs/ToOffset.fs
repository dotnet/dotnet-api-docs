// <Snippet1>
open System

let sourceTime = DateTimeOffset(2007, 9, 1, 9, 30, 0, TimeSpan(-5, 0, 0))

let showDateAndTimeInfo newTime =
    printfn $"{sourceTime} converts to {newTime}"
    printfn $"{sourceTime} and {newTime} are equal: {sourceTime.Equals newTime}"
    printfn $"{sourceTime} and {newTime} are identical: {sourceTime.EqualsExact newTime}\n"

[<EntryPoint>]
let main _ =
    // Convert to same time (return sourceTime unchanged)
    let targetTime = sourceTime.ToOffset(TimeSpan(-5, 0, 0))
    showDateAndTimeInfo targetTime

    // Convert to UTC (0 offset)
    let targetTime = sourceTime.ToOffset TimeSpan.Zero
    showDateAndTimeInfo targetTime

    // Convert to 8 hours behind UTC
    let targetTime = sourceTime.ToOffset(TimeSpan(-8, 0, 0))
    showDateAndTimeInfo targetTime

    // Convert to 3 hours ahead of UTC
    let targetTime = sourceTime.ToOffset(TimeSpan(3, 0, 0))
    showDateAndTimeInfo targetTime

    0

// The example displays the following output:
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 9:30:00 AM -05:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are identical: True
//
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 2:30:00 PM +00:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are identical: False
//
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 6:30:00 AM -08:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are identical: False
//
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 5:30:00 PM +03:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are identical: False
// </Snippet1>