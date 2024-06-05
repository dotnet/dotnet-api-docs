open System

[<EntryPoint>]
let main _ =
    // Addition operator
    // <Snippet1>
    let dTime = DateTime(1980, 8, 5)

    // tSpan is 17 days, 4 hours, 2 minutes and 1 second.
    let tSpan = TimeSpan(17, 4, 2, 1)

    // Result gets 8/22/1980 4:02:01 AM.
    let result = dTime + tSpan
    // </Snippet1>			

    printfn $"{result}"

    // Equality operator.
    // <Snippet2>
    let april19 = DateTime(2001, 4, 19)
    let otherDate = DateTime(1991, 6, 5)

    // areEqual gets false.
    let areEqual = april19 = otherDate

    let otherDate = DateTime(2001, 4, 19)
    // areEqual gets true.
    let areEqual = april19 = otherDate
    // </Snippet2>

    0