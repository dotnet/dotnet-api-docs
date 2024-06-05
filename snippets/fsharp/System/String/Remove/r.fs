module r

//<snippet1>
// This example demonstrates the String.Remove() method.
let s = "abc---def"

printfn "Index: 012345678"
printfn $"1)     {s}"
printfn $"2)     {s.Remove 3}"
printfn $"3)     {s.Remove(3, 3)}"
(*
This example produces the following results:

Index: 012345678
1)     abc---def
2)     abc
3)     abcdef

*)
//</snippet1>