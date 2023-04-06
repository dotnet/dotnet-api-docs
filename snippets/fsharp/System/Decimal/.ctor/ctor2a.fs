module ctor2a

// <Snippet1>
open System

let values = [ 1234.96m; -1234.96m ]
for value in values do
    let parts = Decimal.GetBits value
    let sign = (parts[3] &&& 0x80000000) <> 0

    let scale = (parts[3] >>> 16) &&& 0x7F |> byte
    let newValue = Decimal(parts[0], parts[1], parts[2], sign, scale)
    printfn $"{value} --> {newValue}"

// The example displays the following output:
//       1234.96 --> 1234.96
//       -1234.96 --> -1234.96
// </Snippet1> 