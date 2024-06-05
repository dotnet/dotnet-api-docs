module precision1

// <Snippet7>
open System

let roundValueAndAdd (value: double) =
    printfn $"{value,5:N1} {value,20:R}  {Math.Round(value, MidpointRounding.ToEven),12} {Math.Round(value, MidpointRounding.AwayFromZero),15}"
    value + 0.1

printfn "%5s %20s  %12s %15s\n" "Value" "Full Precision" "ToEven" "AwayFromZero"
let mutable value = 11.1
for _ = 0 to 5 do
    value <- roundValueAndAdd value

printfn ""

value <- 11.5
roundValueAndAdd value
|> ignore

// The example displays the following output:
//       Value       Full Precision        ToEven    AwayFromZero
//
//        11.1                 11.1            11              11
//        11.2                 11.2            11              11
//        11.3   11.299999999999999            11              11
//        11.4   11.399999999999999            11              11
//        11.5   11.499999999999998            11              11
//        11.6   11.599999999999998            12              12
//
//        11.5                 11.5            12              12
// </Snippet7>