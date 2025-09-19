module round3

// <Snippet2>
open System

let values = [| 2.125; 2.135; 2.145; 3.125; 3.135; 3.145 |]
for value in values do
    printfn $"{value} --> {Math.Round(value, 2)}"
// The example displays the following output:
//       2.125 --> 2.12
//       2.135 --> 2.13
//       2.145 --> 2.14
//       3.125 --> 3.12
//       3.135 --> 3.14
//       3.145 --> 3.14
// </Snippet2>