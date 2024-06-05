module lastixof1.fs
//<snippet1>
// Sample for String.LastIndexOf(Char, Int32)
open System

let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-"
let br2 = "0123456789012345678901234567890123456789012345678901234567890123456"
let str = "Now is the time for all good men to come to the aid of their party."

let mutable start = str.Length - 1
printfn $"All occurrences of 't' from position {start} to 0."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf "The letter 't' occurs at position(s): "

let mutable at = 0
while (start > -1) && (at > -1) do
    at <- str.LastIndexOf('t', start)
    if at > -1 then
        printf $"{at} "
        start <- at - 1
printf $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}"
(*
This example produces the following results:
All occurrences of 't' from position 66 to 0.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

The letter 't' occurs at position(s): 64 55 44 41 33 11 7
*)
//</snippet1>
