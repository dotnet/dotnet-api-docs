module isinternedex1.fs
// <Snippet1>
open System

let str1 = "a"
let str2 = str1 + "b"
let str3 = str2 + "c"
let strings = 
    [| "value"; "part1" + "_" + "part2"; str3
       String.Empty; null |]
for value in strings do
    if value <> null then
        let interned = String.IsInterned(value) <> null
        if interned then
            printfn $"'{value}' is in the string intern pool."
        else
            printfn $"'{value}' is not in the string intern pool."
// The example displays the following output:
//       'value' is in the string intern pool.
//       'part1_part2' is in the string intern pool.
//       'abc' is not in the string intern pool.
//       '' is in the string intern pool.
// </Snippet1>
