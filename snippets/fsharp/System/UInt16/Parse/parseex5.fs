module parseex5

// <Snippet5>
open System

let values = 
    [| "-0"; "17"; "-12"; "185"; "66012"; "+0" 
       ""; null; "16.1"; "28.0"; "1,034" |]
for value in values do
    try
        let number = UInt16.Parse value
        printfn $"'{value}' --> {number}"
    with
    | :? FormatException ->
        printfn $"'{value}' --> Bad Format"
    | :? OverflowException ->
        printfn $"'{value}' --> OverflowException"
    | :? ArgumentNullException ->
        printfn $"'{value}' --> Null"
// The example displays the following output:
//       '-0' --> 0
//       '17' --> 17
//       '-12' --> OverflowException
//       '185' --> 185
//       '66012' --> OverflowException
//       '+0' --> 0
//       '' --> Bad Format
//       '' --> Null
//       '16.1' --> Bad Format
//       '28.0' --> Bad Format
//       '1,034' --> Bad Format
// </Snippet5>