// <Snippet1>
open System

let values = 
    [ 12.6m; 12.1m; 9.5m; 8.16m; 0.1m; -0.1m;  -1.1m; -1.9m; -3.9m ]

printfn "%-8s %10s %10s\n" "Value" "Ceiling" "Floor"

for value in values do
    printfn $"%-8O{value} %10O{Decimal.Ceiling value} %10O{Decimal.Floor value}"

// The example displays the following output:
//       Value       Ceiling      Floor
//
//       12.6             13         12
//       12.1             13         12
//       9.5              10          9
//       8.16              9          8
//       0.1               1          0
//       -0.1              0         -1
//       -1.1             -1         -2
//       -1.9             -1         -2
//       -3.9             -3         -4
// </Snippet1> 