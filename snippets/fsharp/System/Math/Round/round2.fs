module round2

// <Snippet1>
open System

let roundValueAndAdd (value: float) =
    printfn $"{value} --> {Math.Round value}"
    value + 0.1

let mutable value = 11.1

for _ = 0 to 5 do
    value <- roundValueAndAdd value

printfn ""

value <- 11.5
roundValueAndAdd value
|> ignore

// The example displays the following output:
//       11.1 --> 11
//       11.2 --> 11
//       11.3 --> 11
//       11.4 --> 11
//       11.5 --> 11
//       11.6 --> 12
//
//       11.5 --> 12
// </Snippet1>