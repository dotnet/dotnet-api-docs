// This example demonstrates StringBuilder.Replace()
//<snippet1>
open System.Text

let show (sbs: StringBuilder) =
    let rule1 = "0----+----1----+----2----+----3----+----4---"
    let rule2 = "01234567890123456789012345678901234567890123"
    printfn $"{rule1}\n{rule2}\n{sbs}\n"

//         0----+----1----+----2----+----3----+----4---
//         01234567890123456789012345678901234567890123
let str = "The quick br!wn d#g jumps #ver the lazy cat."
let sb = StringBuilder str

printfn "StringBuilder.Replace method\n"

printfn "Original value:"
show sb

sb.Replace('#', '!', 15, 29) |> ignore // Some '#' -> '!'
show sb
sb.Replace('!', 'o') |> ignore // All '!' -> 'o'
show sb
sb.Replace("cat", "dog") |> ignore // All "cat" -> "dog"
show sb
sb.Replace("dog", "fox", 15, 20) |> ignore // Some "dog" -> "fox"

printfn "Final value:"
show sb

// This example produces the following results:
//       StringBuilder.Replace method
//
//       Original value:
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick br!wn d#g jumps #ver the lazy cat.
//
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick br!wn d!g jumps !ver the lazy cat.
//
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick brown dog jumps over the lazy cat.
//
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick brown dog jumps over the lazy dog.
//
//       Final value:
//       0----+----1----+----2----+----3----+----4---
//       01234567890123456789012345678901234567890123
//       The quick brown fox jumps over the lazy dog.
//</snippet1>
