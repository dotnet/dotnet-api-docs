module ixany3.fs
//<snippet1>
// Sample for String.IndexOfAny(Char[], Int32, Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."
let target = "aid"
let anyOf = target.ToCharArray()

let start = (str.Length - 1) / 3
let count = (str.Length - 1) / 4
printfn $"\nThe first character occurrence from position {start} for {count} characters."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf $"A character in '{target}' occurs at position: "

let at = str.IndexOfAny(anyOf, start, count)
if at > -1 then
    printfn $"{at}"
else
    printfn "(not found)"
(*

The first character occurrence from position 22 for 16 characters.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'aid' occurs at position: 27

*)
//</snippet1>
