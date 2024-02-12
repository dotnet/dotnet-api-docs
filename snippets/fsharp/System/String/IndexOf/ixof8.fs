module ixof8.fs
// Sample for String.IndexOf(String, Int32, Int32)
open System

//<snippet1>
let br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+---"
let br2 = "012345678901234567890123456789012345678901234567890123456789012345678"
let str = "Now is the time for all good men to come to the aid of their country."

let last = str.Length
let mutable start = last / 2
printfn $"\nAll occurrences of 'he' from position {start} to {last - 1}."
printfn $"{br1}{Environment.NewLine}{br2}{Environment.NewLine}{str}{Environment.NewLine}"
printf "The string 'he' occurs at position(s): "

let mutable broken = false
let mutable at = 0
while (start <= last) && (at > -1) do
    // start+count must be a position within -str-.
    let count = last - start
    at <- str.IndexOf("he", start, count)
    if at = -1 then
        broken <- true
    else
        printf $"{at} "
        start <- at + 1
printfn ""

(*
This example produces the following results:

All occurrences of 'he' from position 34 to 68.
0----+----1----+----2----+----3----+----4----+----5----+----6----+---
012345678901234567890123456789012345678901234567890123456789012345678
Now is the time for all good men to come to the aid of their country.

The string 'he' occurs at position(s): 45 56

*)
//</snippet1>
