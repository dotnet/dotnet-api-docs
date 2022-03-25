module ixany2.fs
//<snippet1>
// Sample for String.IndexOfAny(Char[], Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."
let target = "is"
let anyOf = target.ToCharArray()

let start = str.Length/2
printfn $"\nThe first character occurrence from position {start} to {str.Length - 1}."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf $"A character in '{target}' occurs at position: "

let at = str.IndexOfAny(anyOf, start)
if at > -1 then
    printfn $"{at}"
else
    printfn "(not found)"
(*

The first character occurrence from position 33 to 66.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'is' occurs at position: 49

*)
//</snippet1>
