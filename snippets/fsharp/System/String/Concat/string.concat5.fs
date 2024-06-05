module string.concat5

//<snippet1>
open System

let i = -123
let o: obj = i
let objs: obj[] = [| -123; -456; -789 |]

printfn "Concatenate 1, 2, and 3 objects:"
printfn $"1) {String.Concat o}"
printfn $"2) {String.Concat(o, o)}"
printfn $"3) {String.Concat(o, o, o)}"

printfn "\nConcatenate 4 objects and a variable length parameter list:"
printfn $"4) {String.Concat(o, o, o, o)}"
printfn $"5) {String.Concat(o, o, o, o, o)}"

printfn "\nConcatenate a 3-element object array:"
printfn $"6) {String.Concat objs}" 
// The example displays the following output:
//    Concatenate 1, 2, and 3 objects:
//    1) -123
//    2) -123-123
//    3) -123-123-123
//
//    Concatenate 4 objects and a variable length parameter list:
//    4) -123-123-123-123
//    5) -123-123-123-123-123
//
//    Concatenate a 3-element object array:
//    6) -123-456-789
// </snippet1>