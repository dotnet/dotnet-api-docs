module parseexactexample4

// <Snippet4>
open System
open System.Globalization

let inputs = 
    [| "3"; "16:42"; "1:6:52:35.0625"; "1:6:52:35,0625" |] 
let formats = [| "%h"; "g"; "G" |]
let culture = CultureInfo "de-DE"

// Parse each string in inputs using formats and the de-DE culture.
for input in inputs do
    try
        let interval = 
            TimeSpan.ParseExact(input, formats, culture, TimeSpanStyles.AssumeNegative)
        printfn $"{input} --> {interval:c}"
    with
    | :? FormatException ->
        printfn $"{input} --> Bad Format"
    | :? OverflowException ->
        printfn $"{input} --> Overflow"
// The example displays the following output:
//       3 --> -03:00:00
//       16:42 --> 16:42:00
//       1:6:52:35.0625 --> Bad Format
//       1:6:52:35,0625 --> 1.06:52:35.0625000
// </Snippet4>