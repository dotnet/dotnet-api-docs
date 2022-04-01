module lastixany2.fs
//<snippet1>
// Sample for String.LastIndexOfAny(Char[], Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."
let target = "is"
let anyOf = target.ToCharArray()

let start = (str.Length - 1) / 2
printfn $"The last character occurrence  from position {start} to 0."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf $"A character in '{target}' occurs at position: "

let at = str.LastIndexOfAny(anyOf, start)
if at > -1 then
    printf $"{at}"
else
    printf "(not found)"
printf $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
(*
This example produces the following results:
The last character occurrence  from position 33 to 0.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'is' occurs at position: 12


*)
//</snippet1>

