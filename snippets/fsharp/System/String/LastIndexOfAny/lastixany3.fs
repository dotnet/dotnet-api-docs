module lastixany3.fs
//<snippet1>
// Sample for String.LastIndexOfAny(Char[], Int32, Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."
let target = "aid"
let anyOf = target.ToCharArray()

let start = ((str.Length - 1) * 2) / 3
let count = (str.Length - 1) / 3
printfn $"The last character occurrence from position {start} for {count} characters."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf $"A character in '{target}' occurs at position: "

let at = str.LastIndexOfAny(anyOf, start, count)
if at > -1 then
    printf $"{at}"
else
    printf "(not found)"
printf $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
(*
This example produces the following results:
The last character occurrence from position 44 for 22 characters.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'aid' occurs at position: 27
*)
//</snippet1>
