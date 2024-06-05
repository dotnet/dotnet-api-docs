//<snippet1>
// This code example demonstrates the
// Nullable<T>.ToString method.
open System

// Display the text representation of a nullable DateTime.
let display title dspDT =
    let msg = dspDT.ToString()

    printf $"{title} "
    if String.IsNullOrEmpty msg then
        printfn "The nullable DateTime has no defined value."
    else
        printfn $"The current date and time is {msg}."

[<EntryPoint>]
let main _ =
    // Display the current date and time.
    let nullableDate = Nullable DateTime.Now
    display "1)" nullableDate

    // Assign null (Nothing in Visual Basic) to nullableDate, then
    // display its value.
    let nullableDate = Nullable()
    display "2)" nullableDate
    0

// This code example produces the following results:
//     1) The current date and time is 4/19/2005 8:28:14 PM.
//     2) The nullable DateTime has no defined value.
//</snippet1>