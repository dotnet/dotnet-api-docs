module isnullorwhitespace1.fs
// <Snippet1>
open System

let values = 
    [| null; String.Empty; "ABCDE"
       String(' ', 20); "  \t   "
       String('\u2000', 10) |]

for value in values do
    printfn $"{String.IsNullOrWhiteSpace value}"
// The example displays the following output:
//       True
//       True
//       False
//       True
//       True
//       True
// </Snippet1>
