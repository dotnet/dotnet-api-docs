// <Snippet1>
open System

printfn "Enter a date and time."

try
    let strDateTime = stdin.ReadLine()
    let localDateTime = DateTime.Parse strDateTime
    let univDateTime = localDateTime.ToUniversalTime()

    printfn $"{localDateTime} local time is {univDateTime} universal time."

with :? FormatException ->
    printfn "Invalid format."

printfn "Enter a date and time in universal time."

try
    let strDateTime = stdin.ReadLine()
    let univDateTime = DateTime.Parse strDateTime
    let localDateTime = univDateTime.ToLocalTime()

    printfn $"{univDateTime} universal time is {localDateTime} local time."

with :? FormatException ->
    printfn "Invalid format."

// The example displays output like the following when run on a
// computer whose culture is en-US in the Pacific Standard Time zone:
//     Enter a date and time.
//     12/10/2015 6:18 AM
//     12/10/2015 6:18:00 AM local time is 12/10/2015 2:18:00 PM universal time.
//     Enter a date and time in universal time.
//     12/20/2015 6:42:00
//     12/20/2015 6:42:00 AM universal time is 12/19/2015 10:42:00 PM local time.
// </Snippet1>