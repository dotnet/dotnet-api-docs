module ixof1.fs
// Sample for String.IndexOf(Char, Int32)
open System

//<snippet1>
let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+---"
let br2 = "012345678901234567890123456789012345678901234567890123456789012345678"
let str = "Now is the time for all good men to come to the aid of their country."

printfn ""
printfn $"All occurrences of 't' from position 0 to {str.Length - 1}."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf "The letter 't' occurs at position(s): "

let mutable at = 0
let mutable start = 0
let mutable broken = false
while not broken && (start < str.Length) && (at > -1) do
    at <- str.IndexOf('t', start)
    if at = -1 then broken <- true
    else
        printf $"{at} "
        start <- at + 1
    printfn ""

(*
This example produces the following results:

All occurrences of 't' from position 0 to 68.
0----+----1----+----2----+----3----+----4----+----5----+----6----+---
012345678901234567890123456789012345678901234567890123456789012345678
Now is the time for all good men to come to the aid of their country.

The letter 't' occurs at position(s): 7 11 33 41 44 55 65

*)
//</snippet1>
