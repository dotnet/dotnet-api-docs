// This example demonstrates StringBuilder.Remove()
//<snippet1>
open System.Text

let rule1 = "0----+----1----+----2----+----3----+----4---"
let rule2 = "01234567890123456789012345678901234567890123"
let str = "The quick brown fox jumps over the lazy dog."
let sb = StringBuilder str

printfn "StringBuilder.Remove method\n"
printfn "Original value:"
printfn $"{rule1}"
printfn $"{rule2}"
printfn $"{sb}\n"

sb.Remove(10, 6) |> ignore // Remove "brown "

printfn "New value:"
printfn $"{rule1}"
printfn $"{rule2}"
printfn $"{sb}"

// This example produces the following results:
//       StringBuilder.Remove method
//
//       Original value:
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick brown fox jumps over the lazy dog.
//
//       New value:
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick fox jumps over the lazy dog.
//</snippet1>
